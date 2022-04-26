using Package.BattlePassModule.Interfaces;

namespace Test.Impls
{
	public class BattlePassValidationService : IBattlePassValidationService
	{
		private readonly float _currencyAmount;

		public BattlePassValidationService(float currencyAmount)
		{
			_currencyAmount = currencyAmount;
		}


		public bool IsCurrencyEnough(float amount) => _currencyAmount >= amount;
	}
}