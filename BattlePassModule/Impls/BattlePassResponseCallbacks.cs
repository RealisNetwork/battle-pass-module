using System;
using Package.BattlePassModule.Interfaces;
using Package.BattlePassModule.Models.DataTransport;

namespace Package.BattlePassModule.Impls
{
	internal class BattlePassResponseCallbacks : IBattlePassResponseCallbacks, IBattlePassResponseListener
	{
		public Action<BattlePassDataDto> OnBattlePassData { get; set; }
		public Action<CurrentExperienceVo> OnCurrentBattlePassExperience { get; set; }
		public Action<SeasonInfoVo> OnBattlePassSeasonInfo { get; set; }
		public Action<PricesVo> OnBattlePassPrices { get; set; }
		public Action<int> OnBattlePassExperienceUpdatedNotification { get; set; }
		public Action<int> OnClaimBattlePassReward { get; set; }
		public Action<BattlePassRewardDto[]> OnClaimAllOldBattlePassRewards { get; set; }
		public Action<int> OnPurchaseBattlePassExperienceToLevelup { get; set; }
		public Action<int> OnUpgradeBattlePassType { get; set; }

		void IBattlePassResponseListener.OnBattlePassData(BattlePassDataDto progress)
			=> OnBattlePassData?.Invoke(progress);

		void IBattlePassResponseListener.OnCurrentBattlePassExperience(CurrentExperienceVo currentExperience)
			=> OnCurrentBattlePassExperience?.Invoke(currentExperience);

		void IBattlePassResponseListener.OnBattlePassSeasonInfo(SeasonInfoVo seasonInfo)
			=> OnBattlePassSeasonInfo?.Invoke(seasonInfo);

		void IBattlePassResponseListener.OnBattlePassPrices(PricesVo prices)
			=> OnBattlePassPrices?.Invoke(prices);

		void IBattlePassResponseListener.OnBattlePassExperienceUpdatedNotification(int balance)
			=> OnBattlePassExperienceUpdatedNotification?.Invoke(balance);

		void IBattlePassResponseListener.OnClaimBattlePassReward(int rewardBindingId)
			=> OnClaimBattlePassReward?.Invoke(rewardBindingId);

		void IBattlePassResponseListener.OnClaimAllOldBattlePassRewards(BattlePassRewardDto[] rewards)
			=> OnClaimAllOldBattlePassRewards?.Invoke(rewards);

		void IBattlePassResponseListener.OnPurchaseBattlePassExperienceToLevelup(int balance)
			=> OnPurchaseBattlePassExperienceToLevelup?.Invoke(balance);

		void IBattlePassResponseListener.OnUpgradeBattlePassType(int battlePassType)
			=> OnUpgradeBattlePassType?.Invoke(battlePassType);
	}
}