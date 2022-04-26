using System;
using Package.BattlePassModule.Enums;

namespace Package.BattlePassModule.Models.DataTransport
{
	[Serializable]
	public class UserBattlePassRewardDto
	{
		public int RewardId;
		public int RewardBindingId;
		public EBattlePassRewardState State;

		public UserBattlePassRewardDto(int rewardId, int rewardBindingId, EBattlePassRewardState state)
		{
			RewardId = rewardId;
			RewardBindingId = rewardBindingId;
			State = state;
		}
	}
}