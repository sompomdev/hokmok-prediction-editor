using System;
using Sompom.Inventory;
using UnityEditor;

public class QuestGameLevelUpgradeSupportNRankDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var rankType = (RankType)questData.target;
		var upgradeLevelCount = Helper.GetSupportMinLevelMatchingRankType(rankType);
		var supportId = questData.supportId;
		return GetGameLevelOnSupportUpgrateLevel(supportId, upgradeLevelCount);
	}
	
	public override int AppearLevelDefine()
	{
		/* Formula to get appear gameLevel*/
		var rankType = (RankType)questData.target;
		var upgradeLevelCount = Helper.GetSupportMinLevelMatchingRankType(rankType);
		
		//Appear before level of support reach to target 100 level
		upgradeLevelCount -= 100;
		
		var supportId = questData.supportId;
		return GetGameLevelOnSupportUpgrateLevel(supportId, upgradeLevelCount);
	}
}
