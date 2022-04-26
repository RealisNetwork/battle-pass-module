using System.Collections.Generic;
using Package.BattlePassModule.Interfaces;
using Package.BattlePassModule.Models.Data;

namespace Test.Impls
{
	public class BattlePassCallbacks : IBattlePassCallbacks
	{
		public void OnInitialized()
		{
			UnityEngine.Debug.Log($"[{nameof(BattlePassCallbacks)}] On Initialized");
		}

		public void OnLevelChanged(int level)
		{
			UnityEngine.Debug.Log($"[{nameof(BattlePassCallbacks)}] Level changed: {level}");
		}

		public void OnExperienceChanged(int currentExperience)
		{
			UnityEngine.Debug.Log($"[{nameof(BattlePassCallbacks)}] Experience changed: {currentExperience}");
		}

		public void OnUpgradeBattlePass(int battlePassType)
		{
			UnityEngine.Debug.Log($"[{nameof(BattlePassCallbacks)}] Upgraded battle pass");
		}

		public void OnRewardList(Dictionary<int, List<RewardVo>> rewardsList, RewardVo finalReward)
		{
				UnityEngine.Debug.Log($"[{nameof(BattlePassCallbacks)}] Rewards");
			foreach (var reward in rewardsList)
			{
				UnityEngine.Debug.Log($"[{nameof(BattlePassCallbacks)}] BattlePassType {reward.Key}");
				foreach (var rewardVo in reward.Value)
				{
					UnityEngine.Debug.Log($"[{nameof(BattlePassCallbacks)}] RewardId: {rewardVo.RewardId}, rewardType : {rewardVo.ItemReward.RewardType}");
				}
			}
		}

		public void OnRewardUnlocked(List<RewardVo> list)
		{

			UnityEngine.Debug.Log($"[{nameof(BattlePassCallbacks)}] Reward Unlocked:");
			foreach (var reward in list)
			{
				UnityEngine.Debug.Log($"[{nameof(BattlePassCallbacks)}] RewardID: {reward.RewardId}");
			}
		}

		public void OnFinalRewardAvailableAmount(int finalRewardAvailableAmount)
		{
			UnityEngine.Debug.Log($"[{nameof(BattlePassCallbacks)}] Final reward available amount: {finalRewardAvailableAmount}");
		}
	}
}