using Package.BattlePassModule.Models.Data;

namespace Package.BattlePassModule.Services
{
	public interface IProgressService
	{
		int CurrentLevel { get; }
		int CurrentExperience { get; }
		ExperienceVo[] ExperienceProgression { get; }
	}
}