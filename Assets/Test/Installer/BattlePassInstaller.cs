using Package;
using Package.BattlePassModule.Utils;
using Test.Impls;
using Test.Strategies;
using Zenject;

namespace Test.Installer
{
	public class BattlePassInstaller : MonoInstaller
	{
		public override void InstallBindings()
		{
			BindStrategies();

			Container.BindInterfacesTo<BattlePassCallbacks>().AsSingle();
			Container.BindInterfacesTo<BattlePassNetworkRequestsLayer>().AsSingle();
			Container.BindInterfacesTo<BattlePassValidationService>().AsSingle().WithArguments(100f);
			Container.BindBattlePass();

			Container.BindInterfacesTo<TestBootstrap>().AsSingle().NonLazy();
		}

		public void BindStrategies()
		{
			Container.BindInterfacesTo<HeroRewardStrategy>().AsSingle();
			Container.BindInterfacesTo<ItemRewardStrategy>().AsSingle();
			Container.BindInterfacesTo<LootboxRewardStrategy>().AsSingle();
			Container.BindInterfacesTo<HardCurrencyRewardStrategy>().AsSingle();
		}
	}
}