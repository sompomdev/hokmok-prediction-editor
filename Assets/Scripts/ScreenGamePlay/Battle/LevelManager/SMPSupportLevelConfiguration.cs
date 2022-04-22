using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sompom.Inventory;
//using System.Net;
//using Sompom.Common;
//using Sompom.GamePlay.Battle;
using System.Linq;
using System;

public class SMPSupportLevelConfiguration {
	public int level;
    public SMPNum cost;
	public string damage;
    public SMPNum damagePerSecond;

    public static SMPSupportLevelConfiguration GetLevelConfiguration (SMPSupportsCharacters support, int lvToAdd = 1)
	{
        support.m_sCostBase = CostUnlockSupport(support.m_iID);

        SMPSupportLevelConfiguration levelconfig = new SMPSupportLevelConfiguration ();
        levelconfig.level = support.m_iCurrentLevel;
        if (!support.m_bHired)
        {
            levelconfig.cost = new SMPNum(support.m_sCostBase);
        }
        else
        {
            if (support.m_SupportState == SupportStates.UnlockedSkill)
            {
                int totalUnlockSkills = support.m_SupportsAbilityList.Where(item => item.m_bUnlockedInCurrentEvolution == true).ToArray().Count();
                SMPNum costOnLevel;
                if (support.m_SupportsAbilityList[totalUnlockSkills].m_skillType == SupportSkillType.EVOLVE)// && !support.m_evolved)
                {
                    levelconfig.cost = new SMPNum((support.m_sCostBase * Math.Round(Math.Pow(1.075, support.m_iCurrentLevel - 1))) * 10.75);
                }
                else
                {
                    costOnLevel = GetCostUnlockSkill(support.m_sCostBase, support.m_SupportsAbilityList[totalUnlockSkills].m_iCurrentLevel);
                    if (support.m_evolved)
                    {
                        //cost after evolved
                        levelconfig.cost = costOnLevel * (9+support.m_evoledCounter);//start in 10
                    }
                    else
                    {
                        levelconfig.cost = costOnLevel * 5;
                    }
                }
            }
            else
            {
                levelconfig.cost = GetCostDependingOnNumOfLevelToAdd(support.m_iCurrentLevel, lvToAdd);
            }
        }

        levelconfig.damagePerSecond = GetDmg(support.m_iCurrentLevel); //(new SMPNum(1.08).Pow(support.m_iCurrentLevel) * support.m_iCurrentLevel).Round();
        //CheckPassSkill(levelconfig, support, true);

		return levelconfig;
	}

    private static double CostUnlockSupport (int supportIndex)
    {
        double costUnlockSupport = 0;
        if (supportIndex < 5)
        {
            //costUnlockSupport = Mathf.Pow(1.075f, supportIndex * 20);
            costUnlockSupport = supportIndex * 20 * SMPMathGamePlay.GetUnBaseOnLevel(1, SequenceName.CostSupport).ToDoubleIfPossible();
        }
        else if (supportIndex < 10)
        {
            //costUnlockSupport = Mathf.Pow(1.075f, supportIndex * 35);
            costUnlockSupport = supportIndex * 35 * SMPMathGamePlay.GetUnBaseOnLevel(1, SequenceName.CostSupport).ToDoubleIfPossible();
        }
        else if (supportIndex < 15)
        {
            //costUnlockSupport = Mathf.Pow(1.075f, supportIndex * 45);
            costUnlockSupport = supportIndex * 45 * SMPMathGamePlay.GetUnBaseOnLevel(1, SequenceName.CostSupport).ToDoubleIfPossible();
        }
        else
        {
            //costUnlockSupport = Mathf.Pow(1.075f, supportIndex * 50);
            costUnlockSupport = supportIndex * 50 * SMPMathGamePlay.GetUnBaseOnLevel(1, SequenceName.CostSupport).ToDoubleIfPossible();
        }

        

        return costUnlockSupport;
    }

	public static SMPNum GetDamageWithoutAnyBonus(int level)
	{
		return SMPHeroLevelConfiguration.GetDamageWithoutAnyBonus(level);
	}

    public static SMPNum GetDmg (int supportLevel)
    {
        SMPNum dmg = null;

        // if (supportLevel < 1000)
        // {
        //     dmg = SMPHeroLevelConfiguration.DamageMatchingLevel(supportLevel) ;
        // }
        // else
        // {
        //     dmg = SMPHeroLevelConfiguration.DamageMatchingLevel(supportLevel);
        // }

        dmg = SMPMathGamePlay.GetUnBaseOnLevel(supportLevel, SequenceName.DMGHero);
        return dmg;
    }

	/*
    private static void CheckPassSkill(SMPSupportLevelConfiguration levelconfig, SMPSupportsCharacters support, bool isCheckUnlock)
    {
        SMPBattleSystem battleSystem = GameSystem.Instance().gameControl.battleSystem;
        double perDamage = 0;
        for (int i = 0; i < support.m_SupportsAbilityList.Count; i++)
        {
            if (!isCheckUnlock || (isCheckUnlock && support.m_SupportsAbilityList[i].m_bUnlocked))
            {
                if (support.m_SupportsAbilityList[i].m_skillType == SupportSkillType.HERO_DAMAGE)
                {
                    perDamage = perDamage + GetSkillPercentOnEvolve(support.m_evoledCounter, support.m_SupportsAbilityList[i].m_skillPercent, support.m_SupportsAbilityList[i].m_bUnlockedInCurrentEvolution);//SMPMoney.AddString(perDamage, support.m_SupportsAbilityList[i].m_skillPercent);
                }
            }
        }

        double totalPersentDamage = battleSystem.TotalPercentageAllDamageSkill + SMPEquipmentDataShared.Instance().GetFinalGlobalDPSPercentage;

        if (perDamage > 0)
        {
            totalPersentDamage = totalPersentDamage + perDamage;
        }

		float petSkill = battleSystem.GameControlInstance.inventoryTapController.PetControl.GetSkillBonusPercentage(PetBonusSkillType.ALL_SUPPORTER_DAMAGE);
		petSkill += battleSystem.GameControlInstance.inventoryTapController.PetControl.GetSkillBonusPercentage(PetBonusSkillType.ALL_DAMAGE);
		if (petSkill > 0)
		{
			totalPersentDamage = totalPersentDamage + petSkill;
		}

        if (totalPersentDamage > 0)
        {   
            levelconfig.damagePerSecond = levelconfig.damagePerSecond + (levelconfig.damagePerSecond * totalPersentDamage);
        }
    }*/

    public static SMPNum GetDPSMatchLevel (int level, SMPSupportsCharacters support)
	{
        SMPNum damagePerSecond;
		damagePerSecond = GetDmg(level);

		/*
        double perDamage = 0;
        int totalUnlockSkills = support.m_SupportsAbilityList.Where(item => item.m_bUnlocked == true).ToArray().Count();

        for (int i = 0; i < support.m_SupportsAbilityList.Count; i++)
        {
            if (support.m_SupportsAbilityList[i].m_bUnlocked)
            {
                if (support.m_SupportsAbilityList[i].m_skillType == SupportSkillType.HERO_DAMAGE)
                {
                    perDamage = perDamage + GetSkillPercentOnEvolve(support.m_evoledCounter, support.m_SupportsAbilityList[i].m_skillPercent, support.m_SupportsAbilityList[i].m_bUnlockedInCurrentEvolution);
                }
            }

            else if (support.m_SupportState == SupportStates.UnlockedSkill)
            {
                if (i == totalUnlockSkills)
                {
                    if (support.m_SupportsAbilityList[i].m_skillType == SupportSkillType.HERO_DAMAGE)
                    {
                        perDamage = perDamage + GetSkillPercentOnEvolve(support.m_evoledCounter, support.m_SupportsAbilityList[i].m_skillPercent, support.m_SupportsAbilityList[i].m_bUnlockedInCurrentEvolution);
                    }
                    else if (support.m_SupportsAbilityList[i].m_skillType == SupportSkillType.ALL_DAMAGE)
                    {
                        perDamage = perDamage + GetSkillPercentOnEvolve(support.m_evoledCounter, support.m_SupportsAbilityList[i].m_skillPercent, support.m_SupportsAbilityList[i].m_bUnlockedInCurrentEvolution);
                    }
                }
            }
        }

        SMPBattleSystem battleSystem = GameSystem.Instance().gameControl.battleSystem;
		double totalPersentDamage = battleSystem.TotalPercentageAllDamageSkill + SMPEquipmentDataShared.Instance().GetFinalGlobalDPSPercentage;

		if (perDamage > 0)
        {
            totalPersentDamage = totalPersentDamage + perDamage;
        }


		float petSkill = battleSystem.GameControlInstance.inventoryTapController.PetControl.GetSkillBonusPercentage(PetBonusSkillType.ALL_SUPPORTER_DAMAGE);
		petSkill += battleSystem.GameControlInstance.inventoryTapController.PetControl.GetSkillBonusPercentage(PetBonusSkillType.ALL_DAMAGE);
		if (petSkill > 0)
		{
			totalPersentDamage = totalPersentDamage + petSkill;
		}

        if (totalPersentDamage > 0)
        {   
            damagePerSecond = damagePerSecond + (damagePerSecond * totalPersentDamage);
        }*/

        //damagePerSecond.DisplayDetails();

		return damagePerSecond;//.Round();
	}

    public static SMPNum GetCostDependingOnNumOfLevelToAdd(int currentLevel, int lvToAdd = 1)
    {
        //SMPNum cost;
        /*if (lvToAdd == 1)
        {
            cost = support.m_sCostBase * new SMPNum(1.075).Pow(support.m_iCurrentLevel);
        }
        else
        {
            cost = support.m_sCostBase * new SMPNum(1.075).Pow(support.m_iCurrentLevel) * ((new SMPNum(1.075).Pow(lvToAdd) - 1) / 0.075);
        }
        if (support.m_evolved)
        {
            cost = cost * (9+support.m_evoledCounter);//start in 10
        }*/

        //cost = support.m_iID * SMPHeroLevelConfiguration.GetCostOnLevel(0, support.m_iCurrentLevel) / 30;

        //if (lvToAdd > 1)
        //{
        //    for(int i = 2; i <= lvToAdd; i++)
        //    {
        //        cost += support.m_iID * SMPHeroLevelConfiguration.GetCostOnLevel(0, support.m_iCurrentLevel + (i - 1)) / 30;
        //    }
        //}
        
        var _targetLevel = currentLevel + lvToAdd;
        var cost = SMPMathGamePlay.SumBaseOnCurrentLvAndTargetLv(currentLevel, _targetLevel, SequenceName.CostSupport);
        
        cost.Round();
        return cost;
    }


    public static SMPNum GetCostUnlockSkill(double baseCost, int currentLevel)
    {
        //SMPNum cost = baseCost * (new SMPNum(1.075).Pow(currentLevel));
        SMPNum cost = SMPMathGamePlay.GetUnBaseOnLevel(currentLevel, SequenceName.CostSupport);
        return cost;
    }

    public static int GetNextLevelToBuyOnBaseCost(SMPSupportsCharacters support, SMPNum gold)
    {
        int level = GetMaxLevelOnBaseCost(support, support.m_iCurrentLevel, gold);;
        level = Mathf.Clamp(level, 1, level);
        return level;
    }

    /*
    gold = 5 * 1.075^level * ((1.075^howManyLevel) - 1) / 0.075
    => ((1.075^howManyLevel) - 1) = gold * 0.075 / 5 * 1.075^level
    => 1.075^howManyLevel = (gold * 0.075 / 5 * 1.075^level) + 1
    => Math.Log(1.075^howManyLevel, 1.075) = Math.Log((gold * 0.075 / 5 * 1.075^level) + 1, 1.075)
    => howManyLevel = Math.Log((gold * 0.075 / 5 * 1.075^level) + 1, 1.075)
    */
    
    public static int GetMaxLevelOnBaseCost(SMPSupportsCharacters support, int currentlv, SMPNum gold)
    {
        /*SMPNum result = ((gold * 0.075) / (bastCost *  new SMPNum(1.075).Pow(currentlv))) + 1;
        int level ;
        if (result.IsDoubleInifinity())
        {
            double dbResult = result.Log(1.075).ToDoubleIfPossible();
            if (dbResult > int.MaxValue)
            {
                level = int.MaxValue;
            }else 
            {
                level = (int) dbResult;
            }
        }
        else
        {
            double resultInDouble = result.ToDoubleIfPossible();
            level = (int)Math.Floor(Math.Log(resultInDouble, 1.075));
        }*/

        //SMPNum cost = GetCostDependingOnNumOfLevelToAdd(support, currentlv);
        //int level = 0;
        //while (cost <= gold)
        //{
        //    level++;
        //    cost += GetCostDependingOnNumOfLevelToAdd(support, currentlv + level);
        //}


        int level = SMPMathGamePlay.GetMaxLevelThatCanBuyWithExistingGold(gold, currentlv, SequenceName.CostSupport);

        level = Mathf.Clamp(level, 1, level);
        return level; // (int)Math.Floor(Math.Log(result,1.075));
    }

    public static void EvolvedSkill(SMPSupportsCharacters support)
    {
        for (int i = 0; i < support.m_SupportsAbilityList.Count; i++)
        {
            //RemoveSupportSkill(support.m_evoledCounter,support.m_SupportsAbilityList[i].m_skillType, support.m_SupportsAbilityList[i].m_skillPercent);
            //support.m_SupportsAbilityList[i].m_bUnlocked = false;
            //support.m_SupportsAbilityList[i].isActivated = false;
            support.m_SupportsAbilityList[i].m_bUnlockedInCurrentEvolution = false;
            support.m_SupportsAbilityList[i].m_iCurrentLevel += 1000;
        }
        //hero.m_iCurrentLevel = 1001;
        support.m_iCurrentLevel = 1000 * support.m_evoledCounter + 1;
    }

	/*
	public static void DisableSupportSkill(SMPSupportsCharacters support)
	{
		for (int i = 0; i < support.m_SupportsAbilityList.Count; i++)
		{
			if(support.m_SupportsAbilityList[i].m_bUnlocked && support.m_SupportsAbilityList[i].isActivated)
			{
                var skillPercent = GetSkillPercentOnEvolve(support.m_evoledCounter, support.m_SupportsAbilityList[i].m_skillPercent, true);

				RemoveSupportSkill(support.m_evoledCounter, support.m_SupportsAbilityList[i].m_skillType, skillPercent);

				support.m_SupportsAbilityList[i].isActivated = false;
			}
		}
	}

	public static void RemoveSupportSkill(int evoledCounter, SupportSkillType skillType, double persentSkill)
    {
        SMPBattleSystem battleSystem = GameSystem.Instance().gameControl.battleSystem;
        if(skillType == SupportSkillType.ALL_DAMAGE && battleSystem.TotalPercentageAllDamageSkill > 0)
        {
			battleSystem.TotalPercentageAllDamageSkill -= persentSkill;
		}
		else if (skillType == SupportSkillType.TAP_DAMAGE && battleSystem.TotalPercentageTapSkill > 0)
        {
            battleSystem.TotalPercentageTapSkill -= persentSkill;
        }
        else if (skillType == SupportSkillType.TAP_DAMAGE_OF_TOTAL_DPS && battleSystem.TotalPercentageDPSTapSkill > 0)
        {
            battleSystem.TotalPercentageDPSTapSkill -= persentSkill;
        }
        else if (skillType == SupportSkillType.CRITICAL_CHANCE && battleSystem.CriticalChancePersent > 0)
        {
            battleSystem.CriticalChancePersent -= persentSkill;
        }
        else if (skillType == SupportSkillType.CRITICAL_DAMAGE && battleSystem.CriticalDamagePersent > 0)
        {
            battleSystem.CriticalDamagePersent -= persentSkill;
        }
        else if (skillType == SupportSkillType.GOLD_DROP && battleSystem.TotalPersentDropGold > 0)
        {
            battleSystem.TotalPersentDropGold -= persentSkill;
        }
        else if (skillType == SupportSkillType.TREASURE_CHEST_GOLD && battleSystem.TotalPersentChestGold > 0)
        {
            battleSystem.TotalPersentChestGold -= persentSkill;
        }
		else if (skillType == SupportSkillType.WAVE_REDUCE && battleSystem.TotalSupporterWaveReduceSkillCount > 0)
		{
			battleSystem.TotalSupporterWaveReduceSkillCount -= (int)persentSkill;
		}
        else if (skillType == SupportSkillType.MANA_BONUS && SMPManaVariant.Instance().manaRateFromSupports > 0)
        {
            SMPManaVariant.Instance().manaRateFromSupports -= (int)persentSkill;
        }
    }

    public static double GetSkillPercentOnEvolve(int evolve, double persentSkill, bool isUnlockInCurrentEvolve)
    {
        if (isUnlockInCurrentEvolve)
        {
            return (persentSkill + (evolve * 0.1 * persentSkill)).FloorDecimal(3);
        }
        else
        {
            if (evolve >0 )
            {
                return (persentSkill + ((evolve - 1) * 0.1 * persentSkill)).FloorDecimal(3);
            }
            else
            {
                return 0;
            }
            
        }
		
	}

	public static int GetSkillPercentOnEvolve(int evolve, int persentSkill, bool isUnlockInCurrentEvolve)
    {
        if (isUnlockInCurrentEvolve)
        {
            return persentSkill + Mathf.RoundToInt(evolve * 0.1f * persentSkill);
        }
        else
        {
            if (evolve > 0)
            {
                return persentSkill + Mathf.RoundToInt((evolve - 1) * 0.1f * persentSkill);
            }
            else
            {
                return 0;
            }
        }
        
    }*/

	public static int GetReviveCost(int level)
	{
		return 20;
	}
}
