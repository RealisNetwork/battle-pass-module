using System;

namespace Package.BattlePassModule.Enums
{
	[Flags]
	public enum EResponseType
	{
		BattlePassData = 2,
		CurrentBattlePassExperience = 4,
		BattlePassSeasonInfo = 8,
		BattlePassPrices = 16,
		BattlePassExperienceUpdatedNotification = 32,
		ClaimBattlePassReward = 64,
		ClaimAllOldBattlePassRewards = 128,
		PurchaseBattlePassExperienceToLevelup = 256,
		UpgradeBattlePassType = 512
	}
}