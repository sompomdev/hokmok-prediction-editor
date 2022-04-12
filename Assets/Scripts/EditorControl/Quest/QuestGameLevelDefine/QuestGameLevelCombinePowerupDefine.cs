using UnityEngine;

public class QuestGameLevelCombinePowerupDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var targetCombine = questData.target;
		var costSkill = new SMPNum(0);
		var heroLvTarget = 0;//EditorDatas.instance.GetSkillData(targetCombine).Level_Unlock;
		for(int i=0;i<targetCombine;i++)
		{
			var skillData = EditorDatas.instance.GetSkillData(i);
			heroLvTarget = Mathf.Max(heroLvTarget, skillData.Level_Unlock);
			costSkill += SMPActiveSkillLevelConfiguration.GetNextCostConfiguration(skillData, 1);
		}
		
		return GetGameLevelHeroCanReachLevel(heroLvTarget, costSkill);
	}

	private int GetGameLevelHeroCanReachLevel(int heroLv, SMPNum skillCosts)
	{
		var gameLv = 0;
		var goldEarning = new SMPNum(0);
		var goldNeed = SMPHeroLevelConfiguration.GetCostOnLevel(5, 0, heroLv) + skillCosts;
		do
		{
			gameLv++;
			goldEarning += EditorController.instance.GetGoldToDrop(gameLv) * QuestConstance.GHOST_PER_WAVE + 1;//ghost and boss gold drop
		}
		while (goldEarning < goldNeed);

		return gameLv;
	}
}
