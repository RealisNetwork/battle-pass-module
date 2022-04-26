using Package.BattlePassModule.Models.DataTransport;
using Package.BattlePassModule.Strategies;

namespace Test.Strategies
{
	public class ItemRewardStrategy : IRewardStrategy
	{
		public int RewardType => (int)ERewardType.Item;

		public void CreditReward(ItemDto rewardVoItemReward)
		{
			UnityEngine.Debug.Log($"[{nameof(HeroRewardStrategy)}] Credited Item");
		}
	}
}