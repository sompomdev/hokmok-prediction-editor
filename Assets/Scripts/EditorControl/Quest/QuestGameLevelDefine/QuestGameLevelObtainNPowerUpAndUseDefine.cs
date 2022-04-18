using System;

public class QuestGameLevelObtainNPowerUpAndUseDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var powerUpCount = questData.target;
		var levelMaxForUnlock = 0;
		var costSkill = new SMPNum(0);
		for(int i=0;i<powerUpCount;i++)
		{
			var dataSkill = EditorDatas.instance.GetSkillData(i);
			costSkill += SMPActiveSkillLevelConfiguration.GetNextCostConfiguration(dataSkill, 1);
			levelMaxForUnlock = Math.Max(levelMaxForUnlock, dataSkill.Level_Unlock);
		}
		
		return GetGameLevelHeroCanReachLevel(levelMaxForUnlock, costSkill);
	}
}
