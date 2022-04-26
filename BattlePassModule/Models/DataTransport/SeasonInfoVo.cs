using System;
using Package.BattlePassModule.Enums;

namespace Package.BattlePassModule.Models.DataTransport
{
	[Serializable]
	public class SeasonInfoVo
	{
		public int SeasonId;
		public EBattlePassSeasonState State;
		public bool HasUnclaimedOldRewards;
		public long StateUpdateDate;

		public SeasonInfoVo(int seasonId, EBattlePassSeasonState state, bool hasUnclaimedOldRewards, long stateUpdateDate)
		{
			SeasonId = seasonId;
			State = state;
			HasUnclaimedOldRewards = hasUnclaimedOldRewards;
			StateUpdateDate = stateUpdateDate;
		}
	}
}