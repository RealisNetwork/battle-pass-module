using System;
using System.Collections.Generic;
using System.Linq;
using Package.BattlePassModule.Enums;
using Package.BattlePassModule.Interfaces;
using Package.BattlePassModule.Models.Data;
using Package.BattlePassModule.Models.DataTransport;
using Package.BattlePassModule.Strategies;

namespace Package.BattlePassModule.Services.Impls
{
	internal class RewardService : IRewardService, IDisposable
	{
		private readonly List<IRewardStrategy> _rewardsStrategies;
		private readonly IBattlePassNetworkRequestsLayer _battlePassNetworkRequestsLayer;
		private readonly IBattlePassResponseCallbacks _battlePassResponseCallbacks;
		private readonly IBattlePassCallbacks _battlePassCallbacks;

		private readonly Dictionary<int, List<RewardVo>> _rewardList = new Dictionary<int, List<RewardVo>>();
		private RewardVo _finalReward;
		private int _finalRewardClaimed = 0;

		public Dictionary<int, List<RewardVo>> RewardList => _rewardList;
		public List<RewardVo> GetRewardsByBattlePassType(int battlePassType) => _rewardList[battlePassType];
		public RewardVo FinalReward => _finalReward;

		public RewardService
		(
			List<IRewardStrategy> rewardsStrategies,
			IBattlePassNetworkRequestsLayer battlePassNetworkRequestsLayer,
			IBattlePassResponseCallbacks battlePassResponseCallbacks,
			IBattlePassCallbacks battlePassCallbacks
		)
		{
			_rewardsStrategies = rewardsStrategies;
			_battlePassNetworkRequestsLayer = battlePassNetworkRequestsLayer;
			_battlePassResponseCallbacks = battlePassResponseCallbacks;
			_battlePassCallbacks = battlePassCallbacks;

			battlePassResponseCallbacks.OnBattlePassData += OnBattlePassData;
			battlePassResponseCallbacks.OnClaimBattlePassReward += OnClaimBattlePassReward;
			battlePassResponseCallbacks.OnClaimAllOldBattlePassRewards += OnClaimAllOldBattlePassRewards;
		}

		public void Dispose()
		{
			_battlePassResponseCallbacks.OnBattlePassData -= OnBattlePassData;
			_battlePassResponseCallbacks.OnClaimBattlePassReward -= OnClaimBattlePassReward;
			_battlePassResponseCallbacks.OnClaimAllOldBattlePassRewards -= OnClaimAllOldBattlePassRewards;
		}


		public bool ClaimReward(int rewardId)
		{
			_battlePassNetworkRequestsLayer.ClaimBattlePassReward(rewardId);
			return true;
		}

		public bool ClaimAllRewards()
		{
			_battlePassNetworkRequestsLayer.ClaimAllOldBattlePassRewards();
			return true;
		}

		public void OnLevelUp(int currentLevel)
		{
			var list = new List<RewardVo>();
			foreach (var rewards in _rewardList)
			{
				for (var i = 0; i < rewards.Value.Count; i++)
				{
					var reward = rewards.Value[i];
					if (reward.State == EBattlePassRewardState.Closed && currentLevel >= reward.Level)
					{
						reward.State = EBattlePassRewardState.Available;
						list.Add(reward);
					}
				}
			}

			_battlePassCallbacks.OnRewardUnlocked(list);
		}

		public void OnFinalRewardIntervals(int intervals)
		{
			var finalRewardAvailable = intervals - _finalRewardClaimed;
			
			if (finalRewardAvailable <= 0)
				return;
			
			_battlePassCallbacks.OnFinalRewardAvailableAmount(finalRewardAvailable);
		}

		public RewardVo GetRewardByRewardId(int rewardId)
		{
			foreach (var rewards in _rewardList)
			{
				for (var i = 0; i < rewards.Value.Count; i++)
				{
					var rewardsVo = rewards.Value[i];
					if (rewardsVo.RewardId == rewardId)
						return rewardsVo;
				}
			}

			throw new System.Exception($"[{nameof(RewardService)}] Not found reward with id: {rewardId}");
		}

		private void OnBattlePassData(BattlePassDataDto data)
		{
			_rewardList.Clear();

			foreach (var level in data.Progression.Levels)
			{
				foreach (var levelReward in level.RewardsList)
				{
					if (!_rewardList.ContainsKey(levelReward.BattlePassType))
						_rewardList.Add(levelReward.BattlePassType, new List<RewardVo>());


					var rewardDto = data.Rewards.FirstOrDefault(f => f.RewardId == levelReward.RewardId);
					var state = rewardDto?.State ?? EBattlePassRewardState.Closed;

					_rewardList[levelReward.BattlePassType].Add(new RewardVo
					{
						Level = level.Level,
						RewardId = levelReward.RewardId,
						State = state,
						ItemReward = levelReward.ItemReward
					});
				}
			}

			var finalRewardRewardId = data.Progression.FinalReward.RewardId;
			_finalReward = new RewardVo
			{
				RewardId = finalRewardRewardId,
				ItemReward = data.Progression.FinalReward.ItemReward
			};

			_finalRewardClaimed = data.Rewards.Count(f =>
				f.RewardId == finalRewardRewardId && f.State == EBattlePassRewardState.Claimed);

			_battlePassCallbacks.OnRewardList(_rewardList, _finalReward);
		}

		private void OnClaimBattlePassReward(int rewardId)
		{
			CheckClaimFinalReward(rewardId);
			var rewardVo = GetRewardByRewardId(rewardId);
			var rewardStrategy = GetRewardStrategy(rewardVo.ItemReward.RewardType);
			rewardStrategy.CreditReward(rewardVo.ItemReward);
		}

		private void OnClaimAllOldBattlePassRewards(BattlePassRewardDto[] rewards)
		{
			foreach (var reward in rewards)
			{
				CheckClaimFinalReward(reward.RewardId);
				var rewardStrategy = GetRewardStrategy(reward.ItemReward.RewardType);
				rewardStrategy.CreditReward(reward.ItemReward);
			}
		}

		private void CheckClaimFinalReward(int rewardId)
		{
			if (rewardId == _finalReward.RewardId)
				_finalRewardClaimed++;
		}

		private IRewardStrategy GetRewardStrategy(int rewardType)
		{
			for (var i = 0; i < _rewardsStrategies.Count; i++)
			{
				var rewardStrategy = _rewardsStrategies[i];
				if (rewardStrategy.RewardType == rewardType)
					return rewardStrategy;
			}

			throw new System.Exception($"[{nameof(RewardService)}] Not found reward strategy with type: {rewardType}");
		}
	}
}