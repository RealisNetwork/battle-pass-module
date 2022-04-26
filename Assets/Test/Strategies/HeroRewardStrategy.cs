using Package.BattlePassModule.Models.DataTransport;
using Package.BattlePassModule.Strategies;

namespace Test.Strategies
{
	public class HeroRewardStrategy : IRewardStrategy
	{
		public int RewardType => (int)ERewardType.Hero;

		public void CreditReward(ItemDto rewardVoItemReward)
		{
			UnityEngine.Debug.Log($"[{nameof(HeroRewardStrategy)}] Credited Hero");
		}
	}
}