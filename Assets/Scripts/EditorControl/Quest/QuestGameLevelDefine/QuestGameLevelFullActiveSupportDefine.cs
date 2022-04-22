using System;
using Sompom.Inventory;

public class QuestGameLevelFullActiveSupportDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var costUnlockSupport = GetCostAllSupportUnlock(SMPQuestTemplateConstance.MAX_ACTIVE_SUPPORT);
		return GetGameLevelCanFarmForCost(costUnlockSupport);
	}
}
