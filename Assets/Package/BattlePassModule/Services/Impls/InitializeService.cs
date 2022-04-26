using Package.BattlePassModule.Enums;
using Package.BattlePassModule.Interfaces;

namespace Package.BattlePassModule.Services.Impls
{
	internal class InitializeService : IInitializeService

	{
		private readonly IBattlePassNetworkRequestsLayer _battlePassNetworkRequestsLayer;
		private readonly IBattlePassCallbacks _battlePassCallbacks;
		private readonly IBattlePassResponseCallbacks _battlePassResponseCallbacks;

		private bool _isInitializing;
		private EResponseType _responsesDone;
		private EResponseType _neededResponsesDone;

		public InitializeService
		(
			IBattlePassNetworkRequestsLayer battlePassNetworkRequestsLayer,
			IBattlePassCallbacks battlePassCallbacks,
			IBattlePassResponseCallbacks battlePassResponseCallbacks
		)
		{
			_battlePassNetworkRequestsLayer = battlePassNetworkRequestsLayer;
			_battlePassCallbacks = battlePassCallbacks;
			_battlePassResponseCallbacks = battlePassResponseCallbacks;
		}

		public void Initialize()
		{
			if (_isInitializing)
				return;

			_responsesDone = 0;
			_neededResponsesDone = EResponseType.BattlePassData | EResponseType.CurrentBattlePassExperience
			                                                    | EResponseType.BattlePassSeasonInfo
			                                                    | EResponseType.BattlePassPrices;

			_battlePassResponseCallbacks.OnBattlePassData += (_) => OnResponse(EResponseType.BattlePassData);
			_battlePassResponseCallbacks.OnCurrentBattlePassExperience += (_) => OnResponse(EResponseType.CurrentBattlePassExperience);
			_battlePassResponseCallbacks.OnBattlePassSeasonInfo += (_) => OnResponse(EResponseType.BattlePassSeasonInfo);
			_battlePassResponseCallbacks.OnBattlePassPrices += (_) => OnResponse(EResponseType.BattlePassPrices);


			_battlePassNetworkRequestsLayer.GetBattlePassData();
			_battlePassNetworkRequestsLayer.GetCurrentBattlePassExperience();
			_battlePassNetworkRequestsLayer.GetBattlePassSeasonInfo();
			_battlePassNetworkRequestsLayer.GetBattlePassPrices();

			_isInitializing = true;
		}

		private void OnResponse(EResponseType responseType)
		{
			_responsesDone |= responseType;
			CheckComplete();
		}


		private void CheckComplete()
		{
			if (_responsesDone != _neededResponsesDone)
				return;
			_isInitializing = false;
			_battlePassCallbacks.OnInitialized();
		}
	}
}