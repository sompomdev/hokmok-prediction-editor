using System;

public class QuestGameLevelUseNSkillNTimeDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var nSkill = questData.target;
		var nTime = questData.target2;

		var manaNeedTotal = 0.0;
		var skillCostTotal = new SMPNum(0);
		var maxLevelUnlock = 0;
		for (int i = 0; i < nSkill; i++)
		{
			var skillTargetId = i;
			var skillData = EditorDatas.instance.GetSkillData(skillTargetId);
			var skillCost = SMPActiveSkillLevelConfiguration.GetNextCostConfiguration(skillData, 1);
			skillCostTotal += skillCost;
			maxLevelUnlock = Math.Max(maxLevelUnlock, skillData.Level_Unlock);
			
			var manaConsume = SMPActiveSkillLevelConfiguration.GetNextManaConsumtion(skillData, 1);
			var manaNeed = manaConsume * nTime;
			manaNeedTotal += manaNeed;
		}
		var manaFarmingPerminute = SMPManaLevelConfiguration.GetManaPerMinutes();
		var totalTimeMana = manaNeedTotal / (manaFarmingPerminute / 60);
		var gameLevelOnFarmingMana = GetGameLevelCanReachBaseOnTime(totalTimeMana);

		var gameLevelUnlockSkill = GetGameLevelHeroCanReachLevel(maxLevelUnlock, skillCostTotal);

		return Math.Max(gameLevelUnlockSkill, gameLevelOnFarmingMana);
	}

	public override int AppearLevelDefine()
	{
		return GameLevelDefine();
	}
}
