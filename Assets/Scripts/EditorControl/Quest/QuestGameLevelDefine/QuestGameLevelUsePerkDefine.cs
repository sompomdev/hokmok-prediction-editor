using System;

public class QuestGameLevelUsePerkDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var perkId = questData.target;
		if (perkId == 3)//Mana potion perk
		{
			return GameLevelManaPotionDefine();
		}

		return GameLevelPerkDefine(perkId);
	}

	public int GameLevelManaPotionDefine()
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

	public int GameLevelPerkDefine(int perkId)
	{
		var perkData = EditorDatas.instance.GetShopSkillData(perkId);
		var diamondNeed = int.Parse(perkData.m_Gems_Count);
		var lvDiamondFarm = GetGameLevelByDiamondBossDrop(diamondNeed);
		return lvDiamondFarm;
	}
}
