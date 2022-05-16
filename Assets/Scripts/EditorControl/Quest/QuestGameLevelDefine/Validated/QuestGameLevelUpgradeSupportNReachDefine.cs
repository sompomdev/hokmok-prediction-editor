using System;
using Sompom.Inventory;

public class QuestGameLevelUpgradeSupportNReachDefine : QuestGameLevelBaseDefine
{
	private int gameLevelStart = 11;
	public override int GameLevelDefine()
	{
		var upgradeLevelCount = questData.target;
		var supportId = questData.supportId;
		return Math.Max(gameLevelStart, GetGameLevelOnSupportUpgrateLevel(supportId, upgradeLevelCount));
	}

	public override int AppearLevelDefine()
	{
		return GameLevelDefine() - 1;
	}
}
