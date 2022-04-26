using Package.BattlePassModule.Models.DataTransport;
using Package.BattlePassModule.Strategies;

namespace Test.Strategies
{
	public class HardCurrencyRewardStrategy : IRewardStrategy
	{
		public int RewardType => (int)ERewardType.HardCurrency;

		public void CreditReward(ItemDto rewardVoItemReward)
		{
			UnityEngine.Debug.Log($"[{nameof(HeroRewardStrategy)}] Credited HardCurrency");
		}
	}
}