using Package.BattlePassModule.Models.DataTransport;

namespace Package.BattlePassModule.Strategies
{
	public interface IBattlePassRewardStrategy
	{
		int RewardType { get; }

		void CreditReward(ItemDto rewardVoItemReward);
	}
}