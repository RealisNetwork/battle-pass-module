using System.Collections.Generic;
using Package.BattlePassModule.Models.Data;

namespace Package.BattlePassModule.Services
{
	public interface IRewardService
	{
		Dictionary<int, List<RewardVo>> RewardList { get; }
		RewardVo FinalReward { get; }
		List<RewardVo> GetRewardsByBattlePassType(int battlePassType);
		bool ClaimReward(int rewardId);
		bool ClaimAllRewards();
		RewardVo GetRewardByRewardId(int rewardId);
		void OnLevelUp(int currentLevel);
		void OnFinalRewardIntervals(int intervals);
	}
}