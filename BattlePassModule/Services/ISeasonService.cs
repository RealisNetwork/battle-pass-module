using Package.BattlePassModule.Enums;

namespace Package.BattlePassModule.Services
{
	public interface ISeasonService
	{
		int SeasonId { get; }
		EBattlePassSeasonState CurrentSeasonState { get; }
		long StateUpdateDateMs { get; }
	}
}