using Package.BattlePassModule.Models.DataTransport;

namespace Package.BattlePassModule.Strategies
{
	public interface IRewardStrategy
	{
		int RewardType { get; }

		void CreditReward(ItemDto rewardVoItemReward);
	}
}