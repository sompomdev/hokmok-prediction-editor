
using System;

public class QuestGameLevelObtainFirstPowerUpDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var dataSkill = EditorDatas.instance.GetSkillData(0);
		dataSkill.m_iLv = 0;
		var costSkill = SMPActiveSkillLevelConfiguration.GetNextCostConfiguration(dataSkill, 1);
		var heroLvTarget = dataSkill.Level_Unlock;
		return GetGameLevelHeroCanReachLevel(heroLvTarget, costSkill);
	}

	public override int AppearLevelDefine()
	{
		var lv = GameLevelDefine() - 5;
		lv = Math.Max(1, lv);
		return lv;
	}
}
