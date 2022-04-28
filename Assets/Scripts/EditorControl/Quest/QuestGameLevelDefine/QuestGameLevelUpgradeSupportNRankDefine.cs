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
}
