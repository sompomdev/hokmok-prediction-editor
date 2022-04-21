using System;
using Sompom.Inventory;

public class QuestGameLevelFullTeamDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var costUnlockSupport = GetCostAllSupportUnlock(SMPQuestTemplateConstance.MAX_ACTIVE_SUPPORT);
		var gameLevelUnlockPet = GetGameLevelPetUnlock(1);
		var gameLevelOnFullSupport = GetGameLevelCanFarmForCost(costUnlockSupport);
		return Math.Max(gameLevelOnFullSupport, gameLevelUnlockPet);
	}
}
