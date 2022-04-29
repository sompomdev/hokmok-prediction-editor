using System;
using Sompom.Inventory;

public class QuestGameLevelFullFlyingSupportDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var flySupportSkillData = EditorDatas.instance.GetSkillData(8);
		var costHeroUnlockFlySupportSkill = SMPHeroLevelConfiguration.GetCostOnLevel(5, 1,flySupportSkillData.Level_Unlock);
		var flyUnlockCount = SMPQuestTemplateConstance.MAX_FLYING_SUPPORT;
		var costFlySupportSkillUpdate = SMPActiveSkillLevelConfiguration.GetNextCostConfiguration(flySupportSkillData, flyUnlockCount);
		var totalCost = costHeroUnlockFlySupportSkill + costFlySupportSkillUpdate;
		UnityEngine.Debug.Log($"fly=> updateHero {costHeroUnlockFlySupportSkill}+ costFlySkill {costFlySupportSkillUpdate}");
		return GetGameLevelCanFarmForCost(totalCost);
	}
	public override int AppearLevelDefine()
	{
		var lv = GameLevelDefine() - 100;
		if (lv <= 0) lv = 1;
		return lv;
	}
}
