using Package.BattlePassModule.Enums;
using Package.BattlePassModule.Interfaces;
using Package.BattlePassModule.Models.DataTransport;

namespace Package
{
	public class BattlePassNetworkRequestsLayer : IBattlePassNetworkRequestsLayer
	{
		private readonly IBattlePassResponseListener _battlePassResponseListener;

		public BattlePassNetworkRequestsLayer(IBattlePassResponseListener battlePassResponseListener)
		{
			_battlePassResponseListener = battlePassResponseListener;
		}

		public void GetBattlePassData()
		{
			var userBattlePassRewardDto = new UserBattlePassRewardDto[]
			{
				new UserBattlePassRewardDto(2, 3, EBattlePassRewardState.Available)
			};

			var battlePassRewardDto = new BattlePassRewardDto[]
			{
				new BattlePassRewardDto(9, 10, new ItemDto(11, 12, 1))
			};
			var battlePassLevelDto = new BattlePassLevelDto[]
			{
				new BattlePassLevelDto(8, 7, battlePassRewardDto)
			};
			var battlePassProgressionDto =
				new BattlePassProgressionDto(battlePassLevelDto, 4, 
					new BattlePassRewardDto(20, 1, new ItemDto(1, 2, 52)));


			_battlePassResponseListener.OnBattlePassData(new BattlePassDataDto(battlePassProgressionDto,
				userBattlePassRewardDto, new []{1}));
		}

		public void GetCurrentBattlePassExperience()
		{
			_battlePassResponseListener.OnCurrentBattlePassExperience(new CurrentExperienceVo(20));
		}

		public void GetBattlePassSeasonInfo()
		{
			_battlePassResponseListener.OnBattlePassSeasonInfo(new SeasonInfoVo(1, EBattlePassSeasonState.Open, true,
				228));
		}

		public void GetBattlePassPrices()
		{
			var battlePassPrice = new BattlePassPriceDto[]
			{
				new BattlePassPriceDto(7, "4415")
			};

			_battlePassResponseListener.OnBattlePassPrices(new PricesVo("144", battlePassPrice));
		}

		public void ClaimBattlePassReward(int rewardBindingId)
		{
			_battlePassResponseListener.OnClaimBattlePassReward(rewardBindingId);
		}

		public void ClaimAllOldBattlePassRewards()
		{
			_battlePassResponseListener.OnClaimAllOldBattlePassRewards(new BattlePassRewardDto[0]);
		}

		public void PurchaseBattlePassExperienceToLevelup()
		{
			_battlePassResponseListener.OnPurchaseBattlePassExperienceToLevelup(1771);
		}

		public void UpgradeBattlePassType(int battlePassType)
		{
			_battlePassResponseListener.OnUpgradeBattlePassType(battlePassType);
		}
	}
}