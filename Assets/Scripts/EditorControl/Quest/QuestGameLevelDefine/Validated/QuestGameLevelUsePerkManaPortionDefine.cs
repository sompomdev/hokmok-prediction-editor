using System;

public class QuestGameLevelUsePerkManaPortionDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var perkCount = questData.target;
		var manaPerk = EditorDatas.instance.GetShopSkillData(3);
		var diamondNeed = int.Parse(manaPerk.m_Gems_Count) * perkCount;
		var lvDiamondFarm = GetGameLevelByDiamondBossDrop(diamondNeed);

		var firstSkill = EditorDatas.instance.GetSkillData(0);
		var costSkill = SMPActiveSkillLevelConfiguration.GetNextCostConfiguration(firstSkill, 1);
		var heroLvTarget = firstSkill.Level_Unlock;
		var gameLevelHeroCanReachLevel = GetGameLevelHeroCanReachLevel(heroLvTarget, costSkill);


		return Math.Max(lvDiamondFarm, gameLevelHeroCanReachLevel);
	}
	
	public override int AppearLevelDefine()
	{
		return GameLevelDefine();
	}
}
