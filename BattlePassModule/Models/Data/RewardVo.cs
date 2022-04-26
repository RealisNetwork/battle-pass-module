using System;
using Package.BattlePassModule.Enums;
using Package.BattlePassModule.Models.DataTransport;

namespace Package.BattlePassModule.Models.Data
{
	[Serializable]
	public class RewardVo
	{
		public int Level;
		public int RewardId;
		public EBattlePassRewardState State;
		public ItemDto ItemReward;
	}
}