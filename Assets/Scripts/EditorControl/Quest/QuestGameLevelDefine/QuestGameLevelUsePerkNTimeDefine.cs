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
		else if(perkId == 2)//Power of Holding
		{
			return GameLevelPowerHoldingNTimeDefine();
		}

		return GameLevelPerkNTimeDefine(perkId);
	}

	public int GameLevelManaPotionNTimeDefine()
	{
		var perkUse = questData.target2;
		var perkData = EditorDatas.instance.GetShopSkillData(3);
		var diamondSkill = int.Parse(perkData.m_Gems_Count);
		var diamondNeed = diamondSkill * perkUse;
		var lvDiamondFarm = GetGameLevelByDiamondBossDrop(diamondNeed);

		//this skill have cooldown before next avaialble use
		var timeCooldown = SMPQuestTemplateConstance.MANA_POTION_DURATION_COOL_DOWN * (perkUse - 1);//-1 refer to the first is not cooldown
		var lvCoolDown = GetGameLevelCanReachBaseOnTime(timeCooldown);
		lvCoolDown += GetGameLevelByDiamondBossDrop(diamondSkill);//because the first one not include time cooldown

		return Math.Max(lvDiamondFarm, lvCoolDown);
	}

	public int GameLevelPowerHoldingNTimeDefine()
	{
		var perkUse = questData.target2;
		var perkData = EditorDatas.instance.GetShopSkillData(2);
		var diamondSkill = int.Parse(perkData.m_Gems_Count);
		var diamondNeed = diamondSkill * perkUse;
		var lvDiamondFarm = GetGameLevelByDiamondBossDrop(diamondNeed);

		//this skill have cooldown before next avaialble use
		var timeCooldown = SMPQuestTemplateConstance.POWER_HOLDING_DURATION_COOL_DOWN * (perkUse - 1);//-1 refer to the first is not cooldown
		var lvCoolDown = GetGameLevelCanReachBaseOnTime(timeCooldown);
		lvCoolDown += GetGameLevelByDiamondBossDrop(diamondSkill);//because the first one not include time cooldown

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
