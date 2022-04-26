using Package.BattlePassModule.Interfaces;
using Zenject;

namespace Test
{
	public class TestBootstrap : IInitializable
	{
		private readonly IBattlePassService _battlePassService;

		public TestBootstrap(IBattlePassService battlePassService)
		{
			_battlePassService = battlePassService;
		}

		public void Initialize()
		{
			_battlePassService.Initialize<ERewardType, EBattleBassType>();
		}
	}
}