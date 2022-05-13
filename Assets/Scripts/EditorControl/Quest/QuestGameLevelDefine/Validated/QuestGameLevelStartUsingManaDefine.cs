
public class QuestGameLevelStartUsingManaDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var dataSkill = EditorDatas.instance.GetSkillData(0);
		var costSkill = SMPActiveSkillLevelConfiguration.GetNextCostConfiguration(dataSkill, 1);
		var heroLvTarget = dataSkill.Level_Unlock;
		var gameLevelHeroCanReachLevel = GetGameLevelHeroCanReachLevel(heroLvTarget, costSkill);

		var manaConsume = SMPActiveSkillLevelConfiguration.GetNextManaConsumtion(dataSkill, 1);
		var manaFarmingPerminute = SMPManaLevelConfiguration.GetManaPerMinutes();
		var totalTimeMana = (manaFarmingPerminute / 60);
		var gameLevelOnFarmingMana = GetGameLevelCanReachBaseOnTime(totalTimeMana);

		return gameLevelHeroCanReachLevel + gameLevelOnFarmingMana;
	}

	public override int AppearLevelDefine()
	{
		return GameLevelDefine() - 5;
	}
}
