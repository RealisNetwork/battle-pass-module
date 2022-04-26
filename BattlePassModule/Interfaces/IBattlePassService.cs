using System;
using System.Collections.Generic;
using Package.BattlePassModule.Enums;
using Package.BattlePassModule.Models.Data;

namespace Package.BattlePassModule.Interfaces
{
	public interface IBattlePassService
	{
		// void Initialize<TRewardType, TBattlePassType>()
		// 	where TRewardType : Enum
		// 	where TBattlePassType : Enum;
		
		void Initialize();
		void Initialize(Action onInitialized);

		
		// Progress
		int CurrentLevel { get; }
		int CurrentExperience { get; }
		ExperienceVo[] ExperienceProgression { get; }
		
		// Battle pass type
		List<int> AvailableBattlePassTypes { get; }
		bool IsHaveBattlePassType(int type);
		float GetBattlePassTypePrice(int type);
		bool BuyBattlePassType(int type);
		
		// Rewards
 		bool ClaimReward(int rewardId);
		bool ClaimAllReward();
		RewardVo GetRewardByRewardId(int rewardId);
		
		
		// Season
		int SeasonId { get; }
		EBattlePassSeasonState CurrentSeasonState { get; }
		long StateUpdateDateMs { get; }
	}
}