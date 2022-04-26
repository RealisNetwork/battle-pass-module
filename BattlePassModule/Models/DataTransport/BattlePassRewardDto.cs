using System;

namespace Package.BattlePassModule.Models.DataTransport
{
	[Serializable]
	public class BattlePassRewardDto
	{
		public int RewardId;
		public int BattlePassType;
		public ItemDto ItemReward;

		public BattlePassRewardDto(int rewardId, int battlePassType, ItemDto itemReward)
		{
			RewardId = rewardId;
			BattlePassType = battlePassType;
			ItemReward = itemReward;
		}
	}
}