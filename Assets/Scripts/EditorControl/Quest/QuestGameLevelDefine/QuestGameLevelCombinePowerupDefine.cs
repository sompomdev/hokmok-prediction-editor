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
}
