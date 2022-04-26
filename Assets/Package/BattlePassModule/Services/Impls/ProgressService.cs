using System;
using Package.BattlePassModule.Enums;
using Package.BattlePassModule.Interfaces;
using Package.BattlePassModule.Models.Data;
using Package.BattlePassModule.Models.DataTransport;
using UnityEngine;

namespace Package.BattlePassModule.Services.Impls
{
	internal class ProgressService : IProgressService, IDisposable
	{
		private readonly IRewardService _rewardService;
		private readonly IBattlePassResponseCallbacks _battlePassResponseCallbacks;
		private readonly IBattlePassCallbacks _battlePassCallbacks;

		// Storage
		private int _currentExperience;
		private int _currentLevel = 0;
		private int _maxLevel;
		private int _finalRewardExperienceInterval;

		private ExperienceVo[] _experienceProgression;
		//
		// Properties
		public int CurrentLevel => _currentLevel;
		public int CurrentExperience => _currentExperience;
		public ExperienceVo[] ExperienceProgression => _experienceProgression;
		//

		private readonly EResponseType _neededResponsesDone;
		private EResponseType _responsesDone;

		public ProgressService
		(
			IRewardService rewardService,
			IBattlePassResponseCallbacks battlePassResponseCallbacks,
			IBattlePassCallbacks battlePassCallbacks
		)
		{
			_rewardService = rewardService;
			_battlePassResponseCallbacks = battlePassResponseCallbacks;
			_battlePassCallbacks = battlePassCallbacks;
			
			_responsesDone = 0;
			_neededResponsesDone = EResponseType.BattlePassData | EResponseType.CurrentBattlePassExperience;

			_battlePassResponseCallbacks.OnBattlePassData += OnBattlePassData;
			_battlePassResponseCallbacks.OnCurrentBattlePassExperience += OnCurrentBattlePassExperience;
			_battlePassResponseCallbacks.OnBattlePassExperienceUpdatedNotification +=
				OnBattlePassExperienceUpdatedNotification;
		}

		public void Dispose()
		{
			_battlePassResponseCallbacks.OnBattlePassData -= OnBattlePassData;
			_battlePassResponseCallbacks.OnCurrentBattlePassExperience -= OnCurrentBattlePassExperience;
			_battlePassResponseCallbacks.OnBattlePassExperienceUpdatedNotification -=
				OnBattlePassExperienceUpdatedNotification;
		}

		private void OnBattlePassData(BattlePassDataDto data)
		{
			var progression = data.Progression.Levels;
			
			_finalRewardExperienceInterval = data.Progression.FinalRewardExperienceInterval;
			_maxLevel = progression[progression.Length - 1].Level;
			_experienceProgression = new ExperienceVo[progression.Length];

			for (int i = 0; i < progression.Length; i++)
			{
				var progress = progression[i];
				_experienceProgression[i] = new ExperienceVo
				{
					Level = progress.Level,
					Experience = progress.Experience
				};
			}

			_responsesDone |= EResponseType.BattlePassData;
			UpdateLevel();
		}

		private void OnCurrentBattlePassExperience(CurrentExperienceVo currentExperience)
		{
			_currentExperience = currentExperience.Amount;

			_responsesDone |= EResponseType.CurrentBattlePassExperience;
			UpdateLevel();
			_battlePassCallbacks.OnExperienceChanged(currentExperience.Amount);
		}

		private void OnBattlePassExperienceUpdatedNotification(int balance)
		{
			_currentExperience = balance;
			UpdateLevel();
			_battlePassCallbacks.OnExperienceChanged(balance);
		}

		private void UpdateLevel()
		{
			if (!IsInitialized())
				return;

			var level = GetLevelByExperience(_currentExperience);
			if (level == _maxLevel)
			{
				CheckFinalInterval();
			}
			if (level == _currentLevel)
				return;
			_currentLevel = level;
			_rewardService.OnLevelUp(_currentLevel);
			_battlePassCallbacks.OnLevelChanged(_currentLevel);
		}

		private void CheckFinalInterval()
		{
			var additionalExp = _currentExperience - _experienceProgression[_experienceProgression.Length - 1].Experience;
			var intervals = additionalExp / _finalRewardExperienceInterval;
			_rewardService.OnFinalRewardIntervals(intervals);
		}

		private int GetLevelByExperience(int exp)
		{
			for (var i = _experienceProgression.Length - 1; i >= 0; i--)
			{
				var experienceVo = _experienceProgression[i];
				if (exp >= experienceVo.Experience)
					return experienceVo.Level;
			}

			return 0;
		}

		private bool IsInitialized() => _responsesDone == _neededResponsesDone;

	}
}