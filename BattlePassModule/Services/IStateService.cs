using System.Collections.Generic;

namespace Package.BattlePassModule.Services
{
	public interface IStateService
	{
		List<int> AvailableBattlePassTypes { get; }
		bool IsHaveBattlePassType(int type);
		float GetBattlePassTypePrice(int type);
		bool BuyBattlePassType(int type);
	}
}