using Package.BattlePassModule.Models.DataTransport;
using Package.BattlePassModule.Strategies;

namespace Test.Strategies
{
	public class LootboxBattlePassRewardStrategy : IBattlePassRewardStrategy
	{
		public int RewardType => (int)ERewardType.Lootbox;

		public void CreditReward(ItemDto rewardVoItemReward)
		{
			UnityEngine.Debug.Log($"[{nameof(HeroBattlePassRewardStrategy)}] Credited Lootbox");
		}
	}
}