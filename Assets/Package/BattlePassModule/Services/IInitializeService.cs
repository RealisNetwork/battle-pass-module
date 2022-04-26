using System;

namespace Package.BattlePassModule.Services
{
	public interface IInitializeService 
	{
		void Initialize();
		void Initialize(Action onInitialized);
	}
}