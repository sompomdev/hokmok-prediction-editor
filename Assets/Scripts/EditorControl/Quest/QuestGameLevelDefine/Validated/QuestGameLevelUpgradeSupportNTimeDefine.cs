using System;
using Sompom.Inventory;

public class QuestGameLevelUpgradeSupportNTimeDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var upgradeLevelCount = questData.target;
		var supportId = questData.supportId;
		return GetGameLevelOnSupportUpgrateLevel(supportId, upgradeLevelCount + 1);//1 is unlock ready
	}

	public override int AppearLevelDefine()
	{
		var upgradeLevelCount = questData.target;
		var supportId = questData.supportId;
		var gameLevelUnlockSupport = GetGameLevelOnSupportUpgrateLevel(supportId, 1);
		return gameLevelUnlockSupport;
	}
}
