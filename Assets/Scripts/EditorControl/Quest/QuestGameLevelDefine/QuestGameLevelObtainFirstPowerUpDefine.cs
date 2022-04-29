
public class QuestGameLevelObtainFirstPowerUpDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var dataSkill = EditorDatas.instance.GetSkillData(0);
		var costSkill = SMPActiveSkillLevelConfiguration.GetNextCostConfiguration(dataSkill, 1);
		var heroLvTarget = dataSkill.Level_Unlock;
		return GetGameLevelHeroCanReachLevel(heroLvTarget, costSkill);
	}

	public override int AppearLevelDefine()
	{
		var lv = GameLevelDefine() - 20;
		if (lv <= 0) lv = 1;
		return lv;
	}
}
