using System;
using Sompom.Inventory;

public class QuestGameLevelHireNSupportCounterDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var supportNeedUnlock = questData.target;
		var costUnlockSupport = GetCostAllSupportUnlock(supportNeedUnlock);
		
		//add extra cost for user have used to update hero for game level
		costUnlockSupport += 80;
		
		return GetGameLevelCanFarmForCost(costUnlockSupport);
	}

	public override int AppearLevelDefine()
	{
		var gameLevel = GameLevelDefine();
		
		//add 3 levels before appear
		gameLevel -= 3;

		return gameLevel;
	}
}
