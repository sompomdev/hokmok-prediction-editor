using System;
using Sompom.Inventory;

public class QuestGameLevelFullSupportDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var supportNeedUnlock = SMPQuestTemplateConstance.MAX_SUPPORT - SMPQuestTemplateConstance.MAX_FLYING_SUPPORT;
		var costUnlockSupport = GetCostAllSupportUnlock(supportNeedUnlock);
		var flySupportSkillData = EditorDatas.instance.GetSkillData(8);
		var costHeroUnlockFlySupportSkill = SMPHeroLevelConfiguration.GetCostOnLevel(5, 1,flySupportSkillData.Level_Unlock);
		var flyUnlockCount = SMPQuestTemplateConstance.MAX_FLYING_SUPPORT;
		var costFlySupportSkill = SMPActiveSkillLevelConfiguration.GetNextCostConfiguration(flySupportSkillData, flyUnlockCount);
		UnityEngine.Debug.Log($"full=> unlock16Support {costUnlockSupport}+ updateHero {costHeroUnlockFlySupportSkill}+ costFlySkill {costFlySupportSkill}" );
		var totalCost = costUnlockSupport + costHeroUnlockFlySupportSkill + costFlySupportSkill;
		return GetGameLevelCanFarmForCost(totalCost);
	}
}
