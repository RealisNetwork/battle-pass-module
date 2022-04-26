using System;

namespace Package.BattlePassModule.Models.DataTransport
{
	[Serializable]
	public class BattlePassProgressionDto
	{
		public BattlePassLevelDto[] Levels;
		public int FinalRewardExperienceInterval;
		public BattlePassRewardDto FinalReward;

		public BattlePassProgressionDto(BattlePassLevelDto[] levels, int finalRewardExperienceInterval,
			BattlePassRewardDto finalReward)
		{
			Levels = levels;
			FinalRewardExperienceInterval = finalRewardExperienceInterval;
			FinalReward = finalReward;
		}
	}
}