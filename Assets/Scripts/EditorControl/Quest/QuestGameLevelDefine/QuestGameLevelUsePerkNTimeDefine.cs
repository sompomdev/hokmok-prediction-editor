using System;

public class QuestGameLevelUsePerkNTimeDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var perkId = questData.target;
		if(perkId == 3)//Mana potion perk
		{
			return GameLevelManaPotionNTimeDefine();
		}

		return GameLevelPerkNTimeDefine(perkId);
	}

	public int GameLevelManaPotionNTimeDefine()
	{
		var perkUse = questData.target;
		var perkData = EditorDatas.instance.GetShopSkillData(3);
		var diamondNeed = int.Parse(perkData.m_Gems_Count) * perkUse;
		var lvDiamondFarm = GetGameLevelByDiamondBossDrop(diamondNeed);

		//this skill have cooldown before next avaialble use
		var timeCooldown = QuestConstance.MANA_POTION_DURATION_COOL_DOWN * (perkUse - 1);//-1 refer to the first is not cooldown
		var lvCoolDown = GetGameLevelCanReachBaseOnTime(timeCooldown);
		lvCoolDown += GetGameLevelByDiamondBossDrop(int.Parse(perkData.m_Gems_Count));//because the first one not include time cooldown

		return Math.Max(lvDiamondFarm, lvCoolDown);
	}

	public int GameLevelPerkNTimeDefine(int perkId)
	{
		var perkUse = questData.target2;
		var perkData = EditorDatas.instance.GetShopSkillData(perkId);
		var diamondNeed = int.Parse(perkData.m_Gems_Count) * perkUse;
		var lvDiamondFarm = GetGameLevelByDiamondBossDrop(diamondNeed);
		return lvDiamondFarm;
	}
}
