
public class QuestGameLevelUseSkillNTimeDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var skillTargetId = questData.powerUpType;
		var skillData = EditorDatas.instance.GetSkillData(skillTargetId);
		var skillCost = SMPActiveSkillLevelConfiguration.GetNextCostConfiguration(skillData, 1);
		var gameLevelUnlockSkill = GetGameLevelHeroCanReachLevel(skillData.Level_Unlock, skillCost);

		var useTime = questData.target;
		int gameLevelOnFarmingMana = 0;
		if (useTime > 1)
		{
			var manaConsume = SMPActiveSkillLevelConfiguration.GetNextManaConsumtion(skillData, 1);
			var manaFarmingPerminute = SMPManaLevelConfiguration.GetManaPerMinutes();
			var manaNeed = manaConsume * useTime;
			var totalTimeMana = manaNeed / (manaFarmingPerminute / 60);
			gameLevelOnFarmingMana = GetGameLevelCanReachBaseOnTime(totalTimeMana);
		}
		
		//add game level by skill id
		gameLevelUnlockSkill += skillTargetId;

		return gameLevelUnlockSkill + gameLevelOnFarmingMana;
	}

	public override int AppearLevelDefine()
	{
		return GameLevelDefine();
	}
}
