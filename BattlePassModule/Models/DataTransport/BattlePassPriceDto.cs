using System;

namespace Package.BattlePassModule.Models.DataTransport
{
	[Serializable]
	public class BattlePassPriceDto
	{
		public int BattlePassType;
		public string Price;

		public BattlePassPriceDto(int battlePassType, string price)
		{
			BattlePassType = battlePassType;
			Price = price;
		}
	}
}