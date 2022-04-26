using System;
using System.Collections.Generic;
using Package.BattlePassModule.Enums;
using Package.BattlePassModule.Interfaces;
using Package.BattlePassModule.Models.Data;
using Package.BattlePassModule.Services;

namespace Package.BattlePassModule.Impls
{
	public class BattlePassService : IBattlePassService
	{
		private readonly IInitializeService _initializeService;
		private readonly IBattlePassConfigService _battlePassConfigService;
		private readonly IProgressService _progressService;
		private readonly IStateService _stateService;
		private readonly IRewardService _rewardService;
		private readonly ISeasonService _seasonService;

		public BattlePassService
		(
			IInitializeService initializeService,
			IBattlePassConfigService battlePassConfigService,
			IProgressService progressService,
			IStateService stateService,
			IRewardService rewardService,
			ISeasonService seasonService
		)
		{
			_initializeService = initializeService;
			_battlePassConfigService = battlePassConfigService;
			_progressService = progressService;
			_stateService = stateService;
			_rewardService = rewardService;
			_seasonService = seasonService;
		}

		// public void Initialize<TRewardType, TBattlePassType>()
		// 	where TRewardType : Enum
		// 	where TBattlePassType : Enum
		// {
		// 	_battlePassConfigService.SetTypes<TRewardType, TBattlePassType>();
		// 	_initializeService.Initialize();
		// }


		public void Initialize() => _initializeService.Initialize();
		public void Initialize(Action onInitialized) => _initializeService.Initialize(onInitialized);

		public int CurrentLevel => _progressService.CurrentLevel;
		public int CurrentExperience => _progressService.CurrentExperience;
		public ExperienceVo[] ExperienceProgression => _progressService.ExperienceProgression;

		public List<int> AvailableBattlePassTypes => _stateService.AvailableBattlePassTypes;
		public bool IsHaveBattlePassType(int type) => _stateService.IsHaveBattlePassType(type);
		public float GetBattlePassTypePrice(int type) => _stateService.GetBattlePassTypePrice(type);
		public bool BuyBattlePassType(int type) => _stateService.BuyBattlePassType(type);

		public bool ClaimReward(int rewardId) => _rewardService.ClaimReward(rewardId);
		public bool ClaimAllReward() => _rewardService.ClaimAllRewards();
		public RewardVo GetRewardByRewardId(int rewardId) => _rewardService.GetRewardByRewardId(rewardId);

		public int SeasonId => _seasonService.SeasonId;
		public EBattlePassSeasonState CurrentSeasonState => _seasonService.CurrentSeasonState;
		public long StateUpdateDateMs => _seasonService.StateUpdateDateMs;
	}
}