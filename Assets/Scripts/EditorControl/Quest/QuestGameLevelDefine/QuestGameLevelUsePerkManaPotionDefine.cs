
public class QuestGameLevelUsePerkManaPotionDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var dataSkill = EditorDatas.instance.GetSkillData(0);
		var costSkill = SMPActiveSkillLevelConfiguration.GetNextCostConfiguration(dataSkill, 1);
		var heroLvTarget = dataSkill.Level_Unlock;
		var gameLevelHeroCanReachLevel = GetGameLevelHeroCanReachLevel(heroLvTarget, costSkill);

		return gameLevelHeroCanReachLevel;
	}
}
