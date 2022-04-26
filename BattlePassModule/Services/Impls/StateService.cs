using System;
using System.Collections.Generic;
using System.Globalization;
using Package.BattlePassModule.Interfaces;
using Package.BattlePassModule.Models.Data;
using Package.BattlePassModule.Models.DataTransport;

namespace Package.BattlePassModule.Services.Impls
{
	internal class StateService : IStateService, IDisposable
	{
		private readonly IBattlePassNetworkRequestsLayer _battlePassNetworkRequestsLayer;
		private readonly IBattlePassResponseCallbacks _battlePassResponseCallbacks;
		private readonly IBattlePassValidationService _battlePassValidationService;
		private readonly IBattlePassCallbacks _battlePassCallbacks;

		private readonly List<int> _availableBattlePassTypes = new List<int>();
		private BattlePassTypePriceVo[] _prices;

		public List<int> AvailableBattlePassTypes => _availableBattlePassTypes;

		public StateService(
			IBattlePassNetworkRequestsLayer battlePassNetworkRequestsLayer,
			IBattlePassResponseCallbacks battlePassResponseCallbacks,
			IBattlePassValidationService battlePassValidationService,
			IBattlePassCallbacks battlePassCallbacks
		)
		{
			_battlePassNetworkRequestsLayer = battlePassNetworkRequestsLayer;
			_battlePassResponseCallbacks = battlePassResponseCallbacks;
			_battlePassValidationService = battlePassValidationService;
			_battlePassCallbacks = battlePassCallbacks;

			battlePassResponseCallbacks.OnBattlePassData += OnBattlePassData;
			battlePassResponseCallbacks.OnBattlePassPrices += OnBattlePassPrices;
			battlePassResponseCallbacks.OnUpgradeBattlePassType += OnUpgradeBattlePassType;
		}

		public void Dispose()
		{
			_battlePassResponseCallbacks.OnBattlePassData -= OnBattlePassData;
			_battlePassResponseCallbacks.OnBattlePassPrices -= OnBattlePassPrices;
			_battlePassResponseCallbacks.OnUpgradeBattlePassType -= OnUpgradeBattlePassType;
		}

		private void OnBattlePassData(BattlePassDataDto battlePassDataDto)
		{
			for (var i = 0; i < battlePassDataDto.AvailableBattlePassTypes.Length; i++)
			{
				var availableBattlePassType = battlePassDataDto.AvailableBattlePassTypes[i];
				_availableBattlePassTypes.Add(availableBattlePassType);
			}
		}

		private void OnUpgradeBattlePassType(int battlePassType)
		{
			_availableBattlePassTypes.Add(battlePassType);
			_battlePassCallbacks.OnUpgradeBattlePass(battlePassType);
		}

		private void OnBattlePassPrices(PricesVo prices)
		{
			_prices = new BattlePassTypePriceVo[prices.Prices.Length];
			for (var i = 0; i < prices.Prices.Length; i++)
			{
				var price = prices.Prices[i];
				_prices[i] = new BattlePassTypePriceVo
				{
					Type = price.BattlePassType,
					Price = float.Parse(price.Price, CultureInfo.InvariantCulture)
				};
			}
		}

		public bool BuyBattlePassType(int type)
		{
			if (IsHaveBattlePassType(type))
				return false;
			
			var price = GetBattlePassTypePrice(type);
			if (!_battlePassValidationService.IsCurrencyEnough(price))
				return false;

			_battlePassNetworkRequestsLayer.UpgradeBattlePassType(type);
			return true;
		}

		public float GetBattlePassTypePrice(int type)
		{
			for (var i = 0; i < _prices.Length; i++)
			{
				var priceDto = _prices[i];
				if (priceDto.Type == type)
					return priceDto.Price;
			}

			return 0f;
		}

		public bool IsHaveBattlePassType(int type) => _availableBattlePassTypes.Contains(type);
	}
}