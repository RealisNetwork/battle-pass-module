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
			Container.BindBattlePass<BattlePassCallbacks, BattlePassNetworkRequestsLayer, BattlePassValidationService>(
				typeof(HeroBattlePassRewardStrategy),
				typeof(ItemBattlePassRewardStrategy),
				typeof(LootboxBattlePassRewardStrategy),
				typeof(HardCurrencyBattlePassRewardStrategy));
			
			Container.BindInterfacesTo<TestBootstrap>().AsSingle().NonLazy();
		}
	}
}