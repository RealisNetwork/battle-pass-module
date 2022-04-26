using Package.BattlePassModule.Models.DataTransport;
using Package.BattlePassModule.Strategies;

namespace Test.Strategies
{
	public class HeroBattlePassRewardStrategy : IBattlePassRewardStrategy
	{
		public int RewardType => (int)ERewardType.Hero;

		public void CreditReward(ItemDto rewardVoItemReward)
		{
			UnityEngine.Debug.Log($"[{nameof(HeroBattlePassRewardStrategy)}] Credited Hero");
		}
	}
}