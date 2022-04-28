
public class QuestGameLevelTrainPowerUpOfNHeroDefine : QuestGameLevelBaseDefine
{
	//count_update_powerup_each_hero

	public override int GameLevelDefine()
	{
		var heroCount = questData.target;
		var dataSkill = EditorDatas.instance.GetSkillData(0);
		var costSkill = SMPActiveSkillLevelConfiguration.GetNextCostConfiguration(dataSkill, 2) * heroCount;
		var heroLvTarget = dataSkill.Level_Unlock;
		return GetGameLevelHeroCanReachLevel(heroLvTarget, costSkill);
	}

	public override int AppearLevelDefine()
	{
		var lv = GameLevelDefine() - 20;
		if (lv < 0) lv = 1;
		return lv;
	}
}
