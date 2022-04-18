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
}
