using System;
using Sompom.Inventory;

public class QuestGameLevelFullSupportDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var supportNeedUnlock = QuestConstance.MAX_SUPPORT - QuestConstance.MAX_FLYING_SUPPORT;
		var costUnlockSupport = GetCostAllSupportUnlock(supportNeedUnlock);
		var flySupportSkillData = EditorDatas.instance.GetSkillData(8);
		var costHeroUnlockFlySupportSkill = SMPHeroLevelConfiguration.GetCostOnLevel(5, 1,flySupportSkillData.Level_Unlock);
		var flyUnlockCount = QuestConstance.MAX_FLYING_SUPPORT;
		var costFlySupportSkill = SMPActiveSkillLevelConfiguration.GetNextCostConfiguration(flySupportSkillData, flyUnlockCount);
		var totalCost = costUnlockSupport + costHeroUnlockFlySupportSkill + costFlySupportSkill;
		return GetGameLevelCanFarmForCost(totalCost);
	}
}
