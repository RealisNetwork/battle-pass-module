using System;
using Package.BattlePassModule.Models.DataTransport;

namespace Package.BattlePassModule.Interfaces
{
	internal interface IBattlePassResponseCallbacks
	{
		Action<BattlePassDataDto> OnBattlePassData {get; set;}
		Action<CurrentExperienceVo> OnCurrentBattlePassExperience {get; set;}
		Action<SeasonInfoVo> OnBattlePassSeasonInfo {get; set;}
		Action<PricesVo> OnBattlePassPrices {get; set;}

		Action<int> OnBattlePassExperienceUpdatedNotification {get; set; }
		
		Action<int> OnClaimBattlePassReward {get; set;}
		Action<BattlePassRewardDto[]> OnClaimAllOldBattlePassRewards {get; set;}
		Action<int> OnPurchaseBattlePassExperienceToLevelup {get; set;}
		Action<int> OnUpgradeBattlePassType {get; set;}
	}
}