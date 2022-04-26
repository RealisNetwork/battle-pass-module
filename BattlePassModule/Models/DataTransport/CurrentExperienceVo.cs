using System;

namespace Package.BattlePassModule.Models.DataTransport
{
	[Serializable]
	public class CurrentExperienceVo
	{
		public int Amount;

		public CurrentExperienceVo(int amount)
		{
			Amount = amount;
		}
	}
}