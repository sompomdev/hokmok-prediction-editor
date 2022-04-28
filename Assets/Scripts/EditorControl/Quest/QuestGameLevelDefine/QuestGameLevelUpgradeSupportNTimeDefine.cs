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
}
