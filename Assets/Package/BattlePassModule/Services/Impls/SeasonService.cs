using System;
using System.Threading;
using Package.BattlePassModule.Enums;
using Package.BattlePassModule.Interfaces;
using Package.BattlePassModule.Models.DataTransport;

namespace Package.BattlePassModule.Services.Impls
{
	internal class SeasonService : ISeasonService, IDisposable
	{
		private readonly IBattlePassResponseCallbacks _battlePassResponseCallbacks;
		private readonly IRewardService _rewardService;

		private int _seasonId;
		private EBattlePassSeasonState _currentState;
		private long _stateUpdateDate;
		private Timer _timer;

		public int SeasonId => _seasonId;
		public EBattlePassSeasonState CurrentSeasonState => _currentState;
		public long StateUpdateDateMs => _stateUpdateDate;

		public SeasonService
		(
			IBattlePassResponseCallbacks battlePassResponseCallbacks,
			IRewardService rewardService
		)
		{
			_battlePassResponseCallbacks = battlePassResponseCallbacks;
			_rewardService = rewardService;

			_battlePassResponseCallbacks.OnBattlePassSeasonInfo += OnBattlePassSeasonInfo;
		}

		public void Dispose()
		{
			_battlePassResponseCallbacks.OnBattlePassSeasonInfo -= OnBattlePassSeasonInfo;
			DisposeTimer();
		}

		private void OnBattlePassSeasonInfo(SeasonInfoVo vo)
		{
			_seasonId = vo.SeasonId;
			_currentState = vo.State;
			_stateUpdateDate = vo.StateUpdateDate;

			if (_currentState != EBattlePassSeasonState.Close)
			{
				DisposeTimer();
				var timerCallback = new TimerCallback(TimerCallback);
				_timer = new Timer(timerCallback, 0, 0, 1000);
			}

			if (vo.HasUnclaimedOldRewards)
				_rewardService.ClaimAllRewards();
		}

		private void TimerCallback(object state)
		{
			var utcNowMillisecond = TimeSpan.FromTicks(DateTime.UtcNow.Ticks).TotalMilliseconds;
			if (utcNowMillisecond >= _stateUpdateDate)
				ChangeState();
		}

		private void ChangeState()
		{
			switch (_currentState)
			{
				case EBattlePassSeasonState.Open:
					_currentState = EBattlePassSeasonState.Close;
					break;
				case EBattlePassSeasonState.Close:
				case EBattlePassSeasonState.Pause:
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		private void DisposeTimer() => _timer?.Dispose();
	}
}