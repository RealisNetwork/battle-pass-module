using Package.BattlePassModule.Impls;
using Package.BattlePassModule.Services.Impls;
using Zenject;

namespace Package.BattlePassModule.Utils
{
	public static class ZenjectInstallerExtension
	{
		public static void BindBattlePass(this DiContainer diContainer)
		{
			diContainer.BindInterfacesTo<BattlePassResponseCallbacks>().AsSingle();
			diContainer.BindInterfacesTo<BattlePassConfigService>().AsSingle();
			diContainer.BindInterfacesTo<RewardService>().AsSingle();
			diContainer.BindInterfacesTo<StateService>().AsSingle();
			diContainer.BindInterfacesTo<ProgressService>().AsSingle();
			diContainer.BindInterfacesTo<SeasonService>().AsSingle();
			diContainer.BindInterfacesTo<InitializeService>().AsSingle();
			diContainer.BindInterfacesTo<BattlePassService>().AsSingle();
		}
	}
}