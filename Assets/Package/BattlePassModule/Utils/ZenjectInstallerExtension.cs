using System;
using Package.BattlePassModule.Impls;
using Package.BattlePassModule.Interfaces;
using Package.BattlePassModule.Services.Impls;
using Zenject;

namespace Package.BattlePassModule.Utils
{
	public static class ZenjectInstallerExtension
	{
		public static void BindBattlePass<TBattlePassCallbacks, TBattlePassNetworkRequestsLayer,
			TBattlePassValidationService>(this DiContainer diContainer, params Type[] rewardStrategies)
			where TBattlePassCallbacks : IBattlePassCallbacks
			where TBattlePassNetworkRequestsLayer : IBattlePassNetworkRequestsLayer
			where TBattlePassValidationService : IBattlePassValidationService
		{
			diContainer.BindInterfacesTo<TBattlePassCallbacks>().AsSingle();
			diContainer.BindInterfacesTo<TBattlePassNetworkRequestsLayer>().AsSingle();
			diContainer.BindInterfacesTo<TBattlePassValidationService>().AsSingle();

			diContainer.BindInterfacesTo<BattlePassResponseCallbacks>().AsSingle();
			diContainer.BindInterfacesTo<BattlePassConfigService>().AsSingle();
			diContainer.BindInterfacesTo<RewardService>().AsSingle();
			diContainer.BindInterfacesTo<StateService>().AsSingle();
			diContainer.BindInterfacesTo<ProgressService>().AsSingle();
			diContainer.BindInterfacesTo<SeasonService>().AsSingle();
			diContainer.BindInterfacesTo<InitializeService>().AsSingle();
			diContainer.BindInterfacesTo<BattlePassService>().AsSingle();

			for (var i = 0; i < rewardStrategies.Length; i++)
			{
				var rewardStrategy = rewardStrategies[i];
				diContainer.BindInterfacesTo(rewardStrategy).AsSingle();
			}
		}
	}
}