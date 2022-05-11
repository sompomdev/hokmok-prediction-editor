using System;

public class QuestGameLevelUpgradePowerupNTimeDefine : QuestGameLevelBaseDefine
{
	private int skillIdSample = 0;

	public override int GameLevelDefine()
	{
		var skillData = EditorDatas.instance.GetSkillData(skillIdSample);
		var costHeroUnlockSkill = SMPHeroLevelConfiguration.GetCostOnLevel(5, 1, skillData.Level_Unlock);
		var upgradeTime = questData.target;
		
		//unlock skill
		skillData.is_unlocked = false;
		costHeroUnlockSkill += SMPActiveSkillLevelConfiguration.GetNextCostConfiguration(skillData,1);
		
		//upgrade
		skillData.m_iLv = 1;
		skillData.is_unlocked = true;
		var costSkillUpdate = SMPActiveSkillLevelConfiguration.GetNextCostConfiguration(skillData, upgradeTime);
		
		
		var totalCost = costHeroUnlockSkill + costSkillUpdate;
		return GetGameLevelCanFarmForCost(totalCost);
	}

	public override int AppearLevelDefine()
	{
		return GameLevelDefine() - 1;
	}
}
