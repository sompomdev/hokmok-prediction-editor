using System;
using Sompom.Inventory;

public class QuestGameLevelHireNSupportDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var supportNeedUnlock = questData.target;
		var costUnlockSupport = GetCostAllSupportUnlock(supportNeedUnlock);
		return GetGameLevelCanFarmForCost(costUnlockSupport);
	}

	public override int AppearLevelDefine()
	{
		var gameLevel = GameLevelDefine();
		
		//add 1 level before appear
		gameLevel -= 1;

		return gameLevel;
	}
}
