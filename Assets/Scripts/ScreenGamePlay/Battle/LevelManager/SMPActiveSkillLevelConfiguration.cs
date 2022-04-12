using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SMPActiveSkillLevelConfiguration
{
    public int level;
    public SMPNum nextCost;
    public double manaConsumtion;
    public double manaCapBonus;

    public static SMPActiveSkillLevelConfiguration GetLevelConfiguration(SMPUserSkillData skillData, int lvAdd = 1)
    {
        /*
         * From:
         * https://www.reddit.com/r/TapTitans/comments/4d6sh5/active_skills_cost_formula/
         * 
        REQlvl = the required base hero level to unlock a given skill
        Csk = the current level of a given skill
        Skspace = a constant given to each skill to set the cost increase curve [spacing]
        */

        SMPActiveSkillLevelConfiguration levelConfiguration = new SMPActiveSkillLevelConfiguration();
        levelConfiguration.manaCapBonus = GetNextManaCapBonus(skillData, lvAdd); //need to put this line above level increasing
        levelConfiguration.manaConsumtion = GetNextManaConsumtion(skillData, lvAdd); //need to put this line above level increasing
        levelConfiguration.level = skillData.m_iLv + lvAdd;
        levelConfiguration.nextCost = GetNextCostConfiguration(skillData, lvAdd);
        

        return levelConfiguration;
    }

    public static int GetNextActiveSkillLevelToBuy(SMPUserSkillData skillInfo, SMPNum totalGold, int upgradeConfig)
    {
        int lv = 1;
        SMPNum gold = totalGold;
        SMPNum cost ;
        int runner = lv;
        switch (upgradeConfig)
        {
        case 1:
            lv = 1;
            break;
        case 10:
            lv = 10;
            cost = SMPActiveSkillLevelConfiguration.GetNextCostConfiguration(skillInfo, lv);
            if (cost > gold)
            {
                lv = SMPActiveSkillLevelConfiguration.GetMaxActiveSkillLevelOnBaseCost(skillInfo, gold);
            }
            break;
        case 100:
            lv = 100;
            cost = SMPActiveSkillLevelConfiguration.GetNextCostConfiguration(skillInfo, lv);
            if (cost > gold)
            {
                lv = SMPActiveSkillLevelConfiguration.GetMaxActiveSkillLevelOnBaseCost(skillInfo, gold);
            }
            break;
        case 0:
            lv = SMPActiveSkillLevelConfiguration.GetMaxActiveSkillLevelOnBaseCost(skillInfo, gold);
            break;
        }

        lv = Mathf.Clamp(lv, 1, lv);
        return lv;
    }
        

    public static SMPNum GetNextCostConfiguration(SMPUserSkillData skillData, int lvAdd = 1)
    {
        SMPNum nextCost;

        int REQlvl = 50;
        int Csk = skillData.m_iLv;
        int Skspace = 160;

        ConfigParamDependingOnSkillId(skillData.m_iID, ref REQlvl, ref Skspace);

        if (lvAdd == 1)
        {
            nextCost = new SMPNum(1.075).Pow(REQlvl + Csk * Skspace) * 3 * 25;
        }
        else
        {
            nextCost = (3 * 25 * (new SMPNum(1.075).Pow(REQlvl)) * (new SMPNum(1.075).Pow(skillData.m_iLv * Skspace) * (new SMPNum(1.075).Pow(lvAdd * Skspace) - 1))) / (new SMPNum(1.075).Pow(Skspace) - 1);
        }

        return nextCost;
    }

    public static SMPNum GetNextCostConfiguration(SMPPassiveSkillData skillData, int lvAdd = 1)
    {
        SMPNum nextCost;

        int REQlvl = 50;
        int Csk = skillData.m_iLv;
        int Skspace = 160;

        ConfigParamDependingOnSkillId(skillData.m_iID, ref REQlvl, ref Skspace);

        if (lvAdd == 1)
        {
            nextCost = new SMPNum(1.075).Pow(REQlvl + Csk * Skspace) * 3 * 25;
        }
        else
        {
            nextCost = (3 * 25 * (new SMPNum(1.075).Pow(REQlvl)) * (new SMPNum(1.075).Pow(skillData.m_iLv * Skspace) * (new SMPNum(1.075).Pow(lvAdd * Skspace) - 1))) / (new SMPNum(1.075).Pow(Skspace) - 1);
        }

        return nextCost;
    }

    public static double GetNextManaConsumtion (SMPUserSkillData skillData, int lvAdd = 1)
    {
        int level = skillData.m_iLv;
        int baseMana = skillData.base_Mana;
        int baseLevel = 1;
        double costPerLevel = 1;

        switch ((ActiveSkillType)skillData.m_iID)
        {
            case ActiveSkillType.THUNDER_ATTACK:
                costPerLevel = 2;
                break;
            case ActiveSkillType.TWIN_SHADOW:
                costPerLevel = 3;
                break;
            case ActiveSkillType.LAST_HAND:
                costPerLevel = 1;
                break;
            case ActiveSkillType.FAST_AND_FURIOUS:
                costPerLevel = 4;
                break;
            case ActiveSkillType.ANGER_OF_GOD:
                costPerLevel = 5;
                break;
            case ActiveSkillType.GOLD_FINGER:
                costPerLevel = 4;
                break;
        }


        double cost;

        if (level <= 0)
        {
            cost = baseMana;
        }
        else
        {
            cost = baseMana + costPerLevel * (level - baseLevel);
        }
        return cost;
    }

    public static double GetNextManaCapBonus (SMPUserSkillData skillData, int lvAdd = 1)
    {
        //if it's gold finger, just keep the base mana cap for all level
        if (skillData.m_iID == (int)ActiveSkillType.GOLD_FINGER)
        {
            return skillData.base_ManaCap;
        }


        int level = skillData.m_iLv;
        int baseManaCap = skillData.base_ManaCap;
        int baseLevel = 1;
        double capPerLevel = 1;

        switch ((ActiveSkillType)skillData.m_iID)
        {
            case ActiveSkillType.THUNDER_ATTACK:
                capPerLevel = 2;
                break;
            case ActiveSkillType.TWIN_SHADOW:
                capPerLevel = 3;
                break;
            case ActiveSkillType.LAST_HAND:
                capPerLevel = 1;
                break;
            case ActiveSkillType.FAST_AND_FURIOUS:
                capPerLevel = 4;
                break;
            case ActiveSkillType.ANGER_OF_GOD:
                capPerLevel = 5;
                break;
        }


        double cost;

        if (level <= 0)
        {
            cost = baseManaCap;
        }
        else
        {
            cost = baseManaCap + capPerLevel * (level - baseLevel);
        }
        return cost;
    }

	public static double GetNextManaCapBonus(int skillId, int level, int baseManaCap)
	{
		//if it's gold finger, just keep the base mana cap for all level
		if (skillId == (int)ActiveSkillType.GOLD_FINGER)
		{
			return baseManaCap;
		}
		
		int baseLevel = 1;
		double capPerLevel = 1;

		switch ((ActiveSkillType)skillId)
		{
			case ActiveSkillType.THUNDER_ATTACK:
				capPerLevel = 2;
				break;
			case ActiveSkillType.TWIN_SHADOW:
				capPerLevel = 3;
				break;
			case ActiveSkillType.LAST_HAND:
				capPerLevel = 1;
				break;
			case ActiveSkillType.FAST_AND_FURIOUS:
				capPerLevel = 4;
				break;
			case ActiveSkillType.ANGER_OF_GOD:
				capPerLevel = 5;
				break;
		}

		double manaCapTarget;
		if (level <= 0)
		{
			manaCapTarget = baseManaCap;
		}
		else
		{
			manaCapTarget = baseManaCap + capPerLevel * (level - baseLevel);
		}
		return manaCapTarget;
	}

	public static int GetMaxActiveSkillLevelOnBaseCost(SMPUserSkillData skillInfo, SMPNum gold)
    {
        int REQlvl = 50;
        int Csk = skillInfo.m_iLv;
        int Skspace = 160;
        ConfigParamDependingOnSkillId(skillInfo.m_iID, ref REQlvl, ref Skspace);

        SMPNum resultInNum = ((gold * (Math.Pow(1.075,Skspace) - 1))/(3*25*(Math.Pow(1.075,REQlvl+Csk*Skspace))))+1;
        double result = 1;
        if (!resultInNum.IsDoubleInifinity())
        {
            result = resultInNum.ToDoubleIfPossible(); 
        }
        else
        {
            //Because I think that we don't have level that bigger than max value of double.
            result = double.MaxValue;
        }
        int level = (int)Math.Floor(Math.Log(result,1.075) / Skspace);

        return level;
    }

    private static void ConfigParamDependingOnSkillId (int skillId, ref int REQlvl, ref int Skspace)
    {
        switch (skillId)
        {
        case 0:
            REQlvl = 50;
            Skspace = 160;
            break;

        case 1:
            REQlvl = 100;
            Skspace = 100;
            break;

        case 2:
            REQlvl = 200;
            Skspace = 140;
            break;

        case 3:
            REQlvl = 300;
            Skspace = 110;
            break;

        case 4:
            REQlvl = 400;
            Skspace = 130;
            break;

        case 5:
            REQlvl = 500;
            Skspace = 130;
            break;

		case 6:
			REQlvl = 600;
			Skspace = 130;
			break;
		}
    }

    public static float GetSkillDurationMatching (SMPUserSkillData skillData)
    {
        var result = 30.0f;
        //not all skills required to use this method
        switch ((ActiveSkillType)skillData.m_iID)
        {
            case ActiveSkillType.THUNDER_ATTACK:
                break;
            case ActiveSkillType.TWIN_SHADOW:
                break;
            case ActiveSkillType.LAST_HAND:
                break;
            case ActiveSkillType.FAST_AND_FURIOUS:
                break;
            case ActiveSkillType.ANGER_OF_GOD:
                break;
            case ActiveSkillType.GOLD_FINGER:
                break;

			case ActiveSkillType.ANGER_OF_PET:
				result = 30 + (skillData.m_iLv - 1) * 2f;
				//result += result * SMPEquipmentDataShared.Instance().GetCapacitySkillIncreasePercentage(ActiveSkillType.ANGER_OF_PET) * 0.01f;
				break;

			case ActiveSkillType.PROTECTION:
                result = 30 + (skillData.m_iLv - 1) * 5f;
				//result += result * SMPEquipmentDataShared.Instance().GetCapacitySkillIncreasePercentage(ActiveSkillType.PROTECTION) * 0.01f;
				break;

            case ActiveSkillType.FLYING_SUPPORT:
				result = 30 + (skillData.m_iLv - 1) * 2f;
				//result += result * SMPEquipmentDataShared.Instance().GetCapacitySkillIncreasePercentage(ActiveSkillType.FLYING_SUPPORT) * 0.01f;
				break;

            case ActiveSkillType.THE_TEAMMATE:
                result = GetNumRound(skillData.m_iLv) * 10 + (skillData.m_iLv - 1); //10 seconds per round
				//result += result * SMPEquipmentDataShared.Instance().GetCapacitySkillIncreasePercentage(ActiveSkillType.THE_TEAMMATE) * 0.01f;
                break;
        }
		
        return result;
    }
    public static float GetHeroDurationForTeammateSkillMatching(int skillLv, int heroLv)
    {
        //var result = 5 + (heroLv - 1) * 1;
        //return result;

        return 10;
    }

    public static int GetNumHeroForTeammateSkillMatching(int skillLv)
    {
        switch(skillLv)
        {
            case var _ when skillLv >= 10:
                return 2;
            case var _ when skillLv >= 1:
                return 1;
            default:
                return 1;
        }
    }

    public static int GetNumRound (int skillLv)
    {
        switch (skillLv)
        {
            case var _ when skillLv >= 60:
                return 4;
            case var _ when skillLv >= 40:
                return 3;
            case var _ when skillLv >= 20:
                return 2;
            case var _ when skillLv >= 10:
                return 1;
            default:
                return 1;
        }
    }

	/*
    public static SMPResultOfCheckingSkillRequirementModel CheckIfCanUpdate (ActiveSkillType skillType, int currentLv, int lvToAdd = 1)
    {
        var dataUnlocked = GameData.Instance().userData.listHeroCharacterUnlocked;
        var numHeroHired = dataUnlocked.Where(data => data.isHire).ToArray().Count();
        var status = true;
        var numHeroRequired = 0;
        switch (skillType)
        {
            case ActiveSkillType.THE_TEAMMATE:
                switch (currentLv)
                {
                    case var _ when currentLv + lvToAdd >= 60:
                        numHeroRequired = 8;
                        status = numHeroHired >= numHeroRequired;
                        break;

                    case var _ when currentLv + lvToAdd >= 50:
                        numHeroRequired = 7;
                        status = numHeroHired >= numHeroRequired;
                        break;

                    case var _ when currentLv + lvToAdd >= 40:
                        numHeroRequired = 6;
                        status = numHeroHired >= numHeroRequired;
                        break;

                    case var _ when currentLv + lvToAdd >= 30:
                        numHeroRequired = 5;
                        status = numHeroHired >= numHeroRequired;
                        break;

                    case var _ when currentLv + lvToAdd >= 20:
                        numHeroRequired = 4;
                        status = numHeroHired >= numHeroRequired;
                        break;

                    case var _ when currentLv + lvToAdd >= 10:
                        numHeroRequired = 3;
                        status = numHeroHired >= numHeroRequired;
                        break;
                }
                break;
        }
		string sHeroRequire = GameData.Instance().gameLanguage.skill_require_n_hero_more.Replace("[n]", (numHeroRequired - numHeroHired).ToString());
		return new SMPResultOfCheckingSkillRequirementModel(status, $"<color=red>"+sHeroRequire+"</color>");
		//return new SMPResultOfCheckingSkillRequirementModel(status, $"<color=red>Require {numHeroRequired - numHeroHired} hero more.</color>");
	}*/

	public static int GetSkillBonus(int skillID, int currentLevel)
	{
		int baseSkillBonus = 0;
		switch (skillID)
		{
			case 0:
				baseSkillBonus = 70 * (1 + currentLevel);
				break;

			case 1:
				// number of tap per second
				baseSkillBonus = 3 * currentLevel + 4;
				break;

			case 2:
				baseSkillBonus = 3 * currentLevel + 14;
				break;

			case 3:
				baseSkillBonus = 50 * currentLevel + 100;
				break;

			case 4:
				baseSkillBonus = 30 * currentLevel + 40;
				break;

			case 5:
				baseSkillBonus = 5 * currentLevel + 10;
				break;
		}
		//float bonusCapacity = SMPEquipmentDataShared.Instance().GetCapacitySkillIncreasePercentage((ActiveSkillType)skillID);
		return baseSkillBonus;// + Mathf.RoundToInt(baseSkillBonus * bonusCapacity * 0.01f);
	}

	/*
    public static SMPResultOfCheckingSkillRequirementModel CheckIfCanUnlock(SMPUserSkillData _userSkillDataInfo, int currentLvToCheckUnlock)
    {
        if (_userSkillDataInfo == null)
        {
            return new SMPResultOfCheckingSkillRequirementModel(false, "");
        }

        var teamController = GameSystem.Instance().gameControl.inventoryTapController.teamController;
        var numOfHeroUnlock = GameSystem.Instance().gameControl.inventoryTapController.heroControl.m_HeroesList.FindAll(data => data.Hired).Count;


        bool canUnlock = false;
        canUnlock = (_userSkillDataInfo.Level_Unlock <= currentLvToCheckUnlock);

        var skillType = (ActiveSkillType)_userSkillDataInfo.m_iID;
        var message = "";

        switch (skillType)
        {
            case ActiveSkillType.ANGER_OF_PET:
                var haveEnoughPet = (teamController.heroTeam.petSupports.Count > 1);
                if (!haveEnoughPet)
                {
					message = GameData.Instance().gameLanguage.skill_require_at_least_2_pets;//"Require at least 2 pets.";
                }

                canUnlock = canUnlock && haveEnoughPet;
                break;

            case ActiveSkillType.THE_TEAMMATE:
                var haveEnoughHero = numOfHeroUnlock > 1;
                if (!haveEnoughHero)
                {
					message = GameData.Instance().gameLanguage.skill_require_at_least_2_heroes;//"Require at least 2 heroes.";
                }
                canUnlock = canUnlock && haveEnoughHero;
                
                break;

            default:
                break;
        }


        return new SMPResultOfCheckingSkillRequirementModel(canUnlock, $"<color=red>{message}</color>");

        //if (_userSkillDataInfo != null && _userSkillDataInfo.m_iID == 6) //Anger of pet
        //{
        //    var teamController = GameSystem.Instance().gameControl.inventoryTapController.teamController;
        //    canUnlock = canUnlock && (teamController.heroTeam.petSupports.Count > 1);
        //}
        //else if (_userSkillDataInfo != null && _userSkillDataInfo.m_iID == 10) //Teammate
        //{
        //    var numOfHeroUnlock = GameSystem.Instance().gameControl.inventoryTapController.heroControl.m_HeroesList.FindAll(data => data.Hired).Count;

        //    canUnlock = canUnlock && numOfHeroUnlock > 1;

        //}

        //return canUnlock;
    }*/
}
