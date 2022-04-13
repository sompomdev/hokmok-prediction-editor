using System;

public class QuestGameLevelUpgradePowerupNTimeDefine : QuestGameLevelBaseDefine
{
	private int skillIdSample = 0;

	public override int GameLevelDefine()
	{
		var skillData = EditorDatas.instance.GetSkillData(skillIdSample);
		var costHeroUnlockSkill = SMPHeroLevelConfiguration.GetCostOnLevel(5, 1, skillData.Level_Unlock);
		var upgradeTime = questData.target;
		var costSkillUpdate = SMPActiveSkillLevelConfiguration.GetNextCostConfiguration(skillData, upgradeTime);
		var totalCost = costHeroUnlockSkill + costSkillUpdate;
		return GetGameLevelCanFarmForCost(totalCost);
	}
}
