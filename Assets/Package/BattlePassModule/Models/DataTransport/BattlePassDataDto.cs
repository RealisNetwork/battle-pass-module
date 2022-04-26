using System;

namespace Package.BattlePassModule.Models.DataTransport
{
	[Serializable]
	public class BattlePassDataDto
	{
		public BattlePassProgressionDto Progression;
		public UserBattlePassRewardDto[] Rewards;
		public int[] AvailableBattlePassTypes;

		public BattlePassDataDto(BattlePassProgressionDto progression, UserBattlePassRewardDto[] rewards, int[] availableBattlePassTypes)
		{
			Progression = progression;
			Rewards = rewards;
			AvailableBattlePassTypes = availableBattlePassTypes;
		}
	}
}