using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sompom.Inventory;
using System.Net;
//using Sompom.Common;
//using Sompom.GamePlay.Battle;
//using System.Linq;
using System;

public class SMPPetLevelConfiguration {
    
	public int level;
	public int cost;
    public SMPNum petAttackDamage;
	public SMPNum petAttackPassive;
	public float petPassiveDamagePercentage;
    public float petDamagePercentage;
    public float petBonus;
	public float petPassiveBonusPercentage;

    public SMPPetLevelConfiguration ()
    {
        petAttackDamage = new SMPNum(0);
        petAttackPassive = new SMPNum(0);
    }

    public static SMPPetLevelConfiguration GetLevelConfiguration (SMPPetsData petData)
	{
        SMPPetLevelConfiguration levelconfig = new SMPPetLevelConfiguration ();
        levelconfig.level = petData.petCurrentLevel;
        float di = 0;
        if (levelconfig.level <= 40)
        {
            di = levelconfig.level * petData.petDamIncPerLvT1;
        }
        else if (levelconfig.level <= 80)
        {
            di = (40 * petData.petDamIncPerLvT1) + (levelconfig.level - 40) * petData.petDamIncPerLvT2;
        }
        else
        {
            di = (40 * petData.petDamIncPerLvT1) + (80 - 40) * petData.petDamIncPerLvT2 + (levelconfig.level - 80) * petData.petDamIncPerLvT3;
        }
        levelconfig.petDamagePercentage = petData.petBaseDamage + di;
        levelconfig.petBonus = petData.petBaseBonus + (levelconfig.level * petData.petBoIncPerLv);


		levelconfig.cost = GetCostDependingOnNumOfLevelToAdd(petData);

		int lvGroup = (levelconfig.level / 5) * 5;//we should you floor to get (level/5) for fix bug of pet percentage increase rule [5 level per time]
		if (lvGroup > 0)
		{
			levelconfig.petPassiveDamagePercentage = levelconfig.petDamagePercentage * (lvGroup / 100.0f);
			levelconfig.petPassiveBonusPercentage = levelconfig.petBonus * (lvGroup / 100.0f);
		}

		return levelconfig;
	}

	public static SMPPetLevelConfiguration GetAttackDamage(SMPPetsData petData, SMPNum tapDamage)
	{
		SMPPetLevelConfiguration levelconfig = new SMPPetLevelConfiguration ();
		levelconfig.level = petData.petCurrentLevel;
		levelconfig.petAttackDamage =  tapDamage * petData.petTotalDamagePercent / 100;
		int lvGroup = (levelconfig.level / 5) * 5;
		if (lvGroup > 0)
		{
			levelconfig.petAttackPassive = tapDamage * (petData.petTotalPassiveDamagePercent / 100.0f);
		}
        
		return levelconfig;
	}

	public static int GetCostDependingOnNumOfLevelToAdd(SMPPetsData pet)
	{
		//int cost = Mathf.FloorToInt(Mathf.Pow(2,pet.petCurrentLevel - 1) * 15);
		int cost = 5 * pet.petCurrentLevel;
		return cost;
	}

	public static float GetRecoverDurationOnPassive(SMPPetsData petData)
	{
		float duration = GetRecoverDuration(petData.petCurrentLevel) * (petData.petRotation.attackCounter / TapCapacity());
		return duration;
	}

	public static float GetRecoverDuration(int petLevel)
	{
		float duration = petLevel * 30;
		return duration;
	}

	public static double GetPeriodFromStartRecover(SMPPetsData petData)
	{
		var activeTime = DateTime.Now.Subtract(petData.petRotation.startTime_GS).TotalSeconds;
		activeTime = (petData.petRotation.recoverDurationOnPassive - activeTime);
        return activeTime;
	}

	public static float GetAttackCounterOnPeriodOfRecover(SMPPetsData petData, double period)
	{
		float attackCounter = (float)((period / petData.petRotation.recoverDurationOnPassive) * TapCapacity());
        return attackCounter;
	}

	public static int GetPricePetWakeUp(SMPPetsData petdata)
	{
		int price = Mathf.CeilToInt(((float)GetPeriodFromStartRecover(petdata) / 60) / 4);
		return price;
	}

	public static int TapCapacity()
	{
		return 60;
	}

	/*
	public static int TapCapacityWithBonus()
	{
		int baseCapacity = TapCapacity();
		return baseCapacity + Mathf.RoundToInt(baseCapacity * SMPEquipmentDataShared.Instance().PetActiveTimeIncreasePercentage * 0.01f);
	}*/
}
