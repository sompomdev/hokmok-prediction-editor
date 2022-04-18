
public class QuestGameLevelUnlockNHeroPowerUpDefine : QuestGameLevelBaseDefine
{
	//count_update_powerup_each_hero

	public override int GameLevelDefine()
	{
		var heroCount = questData.target;
		var dataSkill = EditorDatas.instance.GetSkillData(0);
		var costSkill = SMPActiveSkillLevelConfiguration.GetNextCostConfiguration(dataSkill, 1) * heroCount;
		var heroLvTarget = dataSkill.Level_Unlock;
		return GetGameLevelHeroCanReachLevel(heroLvTarget, costSkill);
	}
}
