using System.Collections.Generic;
using Package.BattlePassModule.Models.Data;

namespace Package.BattlePassModule.Interfaces
{
	public interface IBattlePassCallbacks
	{
		void OnInitialized();
		void OnLevelChanged(int level);
		void OnExperienceChanged(int currentExperience);
		void OnUpgradeBattlePass(int battlePassType);
		void OnRewardList(Dictionary<int,List<RewardVo>> rewardsList, RewardVo finalReward);
		void OnRewardUnlocked(List<RewardVo> list);
		void OnFinalRewardAvailableAmount(int finalRewardAvailableAmount);
	}
}