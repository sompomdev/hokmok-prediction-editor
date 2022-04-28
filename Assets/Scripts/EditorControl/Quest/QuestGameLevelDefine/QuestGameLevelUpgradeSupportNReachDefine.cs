using System;
using Sompom.Inventory;

public class QuestGameLevelUpgradeSupportNReachDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var upgradeLevelCount = questData.target;
		var supportId = questData.supportId;
		return GetGameLevelOnSupportUpgrateLevel(supportId, upgradeLevelCount);
	}
}
