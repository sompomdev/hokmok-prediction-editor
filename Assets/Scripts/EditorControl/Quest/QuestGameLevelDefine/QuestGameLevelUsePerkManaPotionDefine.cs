using System;

public class QuestGameLevelUsePerkManaPotionDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var manaPerk = EditorDatas.instance.GetShopSkillData(3);
		var diamondNeed = int.Parse(manaPerk.m_Gems_Count);
		var lvDiamondFarm = GetGameLevelByDiamondBossDrop(diamondNeed);

		var firstSkill = EditorDatas.instance.GetSkillData(0);
		var costSkill = SMPActiveSkillLevelConfiguration.GetNextCostConfiguration(firstSkill, 1);
		var heroLvTarget = firstSkill.Level_Unlock;
		var gameLevelHeroCanReachLevel = GetGameLevelHeroCanReachLevel(heroLvTarget, costSkill);
		

		return Math.Max(lvDiamondFarm, gameLevelHeroCanReachLevel);
	}
}
