using System;
using System.Collections.Generic;
using Package.BattlePassModule.Models.Config;

namespace Package.BattlePassModule.Services.Impls
{
	[Serializable]
	public class BattlePassConfigService : IBattlePassConfigService
	{
		public static EnumTypeVo RewardType;
		public static EnumTypeVo BattlePassType;

		public void SetTypes<TRewardType, TBattlePassType>()
			where TRewardType : Enum
			where TBattlePassType : Enum
		{
			SetEnumValues<TRewardType>(ref RewardType);
			SetEnumValues<TBattlePassType>(ref BattlePassType);
		}

		private void SetEnumValues<TEnum>(ref EnumTypeVo vo)
			where TEnum : Enum
		{
			vo = new EnumTypeVo();
			vo.Type = typeof(TEnum);

			var values = Enum.GetValues(vo.Type);

			vo.Values = new List<int>(values.Length);
			foreach (var value in values) 
				vo.Values.Add((int)value);
		}
	}
}