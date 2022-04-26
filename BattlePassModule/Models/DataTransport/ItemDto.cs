using System;

namespace Package.BattlePassModule.Models.DataTransport
{
	[Serializable]
	public class ItemDto
	{
		public int RewardType;
		public int ItemId;
		public int Amount;

		public ItemDto(int rewardType, int itemId, int amount)
		{
			RewardType = rewardType;
			ItemId = itemId;
			Amount = amount;
		}
	}
}