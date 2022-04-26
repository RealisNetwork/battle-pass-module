using System;

namespace Package.BattlePassModule.Models.DataTransport
{
	[Serializable]
	public class PricesVo
	{
		public string ExperiencePrice;
		public BattlePassPriceDto[] Prices;

		public PricesVo(string experiencePrice, BattlePassPriceDto[] prices)
		{
			ExperiencePrice = experiencePrice;
			Prices = prices;
		}
	}
}