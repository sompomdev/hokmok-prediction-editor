using System;
using Sompom.Inventory;
using UnityEditor;
using UnityEngine;

public class QuestGameLevelUnlockAllSupportNEvolveDefine : QuestGameLevelBaseDefine
{
	//All supports reach evolve [n]
	public override int GameLevelDefine()
	{
		var evolveCounter = questData.target;
		var levelTarget = evolveCounter * SMPQuestTemplateConstance.PER_LEVEL_SUPPORT_EVOLVE;
		
		var supportId = 1;
		var totalCost = new SMPNum(0);
		for (int i = 0; i < SMPQuestTemplateConstance.MAX_SUPPORT; i++)
		{
			totalCost += GetCostToUnlockSupportAndUpdateIncludeEvolve(supportId, levelTarget, 0, 0);
			supportId++;
		}
		
		//cost to unlock all fly support
		var flySupportSkillData = EditorDatas.instance.GetSkillData(8);
		var costHeroUnlockFlySupportSkill =
			SMPHeroLevelConfiguration.GetCostOnLevel(5, 1, flySupportSkillData.Level_Unlock);
		var flyUnlockCount = 4;
		var costFlySupportSkillUpdate = SMPActiveSkillLevelConfiguration.GetNextCostConfiguration(flySupportSkillData, flyUnlockCount);
		totalCost += costHeroUnlockFlySupportSkill + costFlySupportSkillUpdate;

		return GetGameLevelCanFarmForCost(totalCost);
	}
}
