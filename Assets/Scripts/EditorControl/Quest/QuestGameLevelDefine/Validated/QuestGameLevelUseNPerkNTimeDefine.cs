using System;

public class QuestGameLevelUseNPerkNTimeDefine : QuestGameLevelBaseDefine
{
	private int gameLevelAppear = 100;
	public override int GameLevelDefine()
	{
		var nPerk = Math.Min(questData.target, 4);//Perk we have only 4
		var nTime = questData.target2;

		var diamondNeed = 0;
		var timeCoolDownPowerHolding = 0f;
		var timeCoolDownManaPotion = 0f;
		for(int i=0;i<nPerk;i++)
		{
			diamondNeed += int.Parse(EditorDatas.instance.GetShopSkillData(i).m_Gems_Count) * nTime;
			if (i == 2)//Power of holding
			{
				timeCoolDownPowerHolding += SMPQuestTemplateConstance.POWER_HOLDING_DURATION_COOL_DOWN * (nTime - 1);
			}
			else if(i == 3)//Mana Potion
			{
				timeCoolDownManaPotion += SMPQuestTemplateConstance.MANA_POTION_DURATION_COOL_DOWN * (nTime - 1);
			}
		}

		var maxTimeCooldown = 0;
		var gameLevelCooldown = 0;
		if (nTime > 1)
		{
			Math.Max(timeCoolDownPowerHolding, timeCoolDownManaPotion);
			gameLevelCooldown = GetGameLevelCanReachBaseOnTime(maxTimeCooldown);
		}
		
		var gameLevelFarmDiamond = GetGameLevelByDiamondBossDrop(diamondNeed);
		
		UnityEngine.Debug.Log($"MaxCoolTime {maxTimeCooldown} DaimondNeed {diamondNeed}");

		return gameLevelFarmDiamond + gameLevelCooldown;
	}

	public override int AppearLevelDefine()
	{
		return gameLevelAppear;
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
