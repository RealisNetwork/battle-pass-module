using Package.BattlePassModule.Interfaces;

namespace Test.Impls
{
	public class BattlePassValidationService : IBattlePassValidationService
	{
		private readonly float _currencyAmount;

		public BattlePassValidationService()
		{
			_currencyAmount = 100f;
		}


		public bool IsCurrencyEnough(float amount) => _currencyAmount >= amount;
	}
}