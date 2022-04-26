using System;

namespace Package.BattlePassModule.Services
{
	public interface IBattlePassConfigService
	{
		void SetTypes<TRewardType, TBattlePassType>() 
			where TRewardType : Enum 
			where TBattlePassType : Enum;
	}
}