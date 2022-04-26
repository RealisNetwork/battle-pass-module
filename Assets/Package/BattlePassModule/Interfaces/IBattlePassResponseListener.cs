using Package.BattlePassModule.Models.DataTransport;

namespace Package.BattlePassModule.Interfaces
{
	public interface IBattlePassResponseListener
	{
		void OnBattlePassData(BattlePassDataDto progress);
		void OnCurrentBattlePassExperience(CurrentExperienceVo currentExperience);
		void OnBattlePassSeasonInfo(SeasonInfoVo seasonInfo);
		void OnBattlePassPrices(PricesVo prices);

		void OnBattlePassExperienceUpdatedNotification(int balance);
		
		void OnClaimBattlePassReward(int rewardBindingId);
		void OnClaimAllOldBattlePassRewards(BattlePassRewardDto[] rewards);
		void OnPurchaseBattlePassExperienceToLevelup(int balance);
		void OnUpgradeBattlePassType(int battlePassType);
	}
}