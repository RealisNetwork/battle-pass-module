using System;

namespace Package.BattlePassModule.Models.DataTransport
{
	[Serializable]
	public class BattlePassLevelDto
	{
		public int Level;
		public int Experience;
		public BattlePassRewardDto[] RewardsList;

		public BattlePassLevelDto(int level, int experience, BattlePassRewardDto[] rewardsList)
		{
			Level = level;
			Experience = experience;
			RewardsList = rewardsList;
		}
	}
}