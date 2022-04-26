namespace Package.BattlePassModule.Interfaces
{
	public interface IBattlePassNetworkRequestsLayer
	{
		void GetBattlePassData();
		void GetCurrentBattlePassExperience();
		void GetBattlePassSeasonInfo();
		void GetBattlePassPrices();
		
		void ClaimBattlePassReward(int rewardBindingId);
		void ClaimAllOldBattlePassRewards();
		void PurchaseBattlePassExperienceToLevelup();
		void UpgradeBattlePassType(int battlePassType);
	}
}