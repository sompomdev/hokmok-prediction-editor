using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMPHeroLevelConfiguration
{
	public static SMPNum GetNextDamageFromLevelToLevel(int hero_unlocklevel, int currentLevel, int lvAdd, SMPNum currentDamage)
	{
		var nextDmg = DamageMatchingLevel(currentLevel + lvAdd);
		if (nextDmg <= currentDamage)
		{
			var currentOriginal = DamageMatchingLevelOriginal(currentLevel);
			var nextOriginal = DamageMatchingLevelOriginal(currentLevel + lvAdd);

			return nextOriginal - currentOriginal;
		}

		SMPNum result = nextDmg - currentDamage;
		return result;
	}

	public static SMPNum DamageMatchingLevel(int level)
	{
		var totalDamage = DamageMatchingLevelOriginal(level);
		return totalDamage;
	}

	public static SMPNum GetDamageWithoutAnyBonus(int level)
	{
		return DamageMatchingLevelOriginal(level);
	}

	private static SMPNum DamageMatchingLevelOriginal(int level)
	{
		SMPNum totalDamage = SMPMathGamePlay.GetUnBaseOnLevel(level, SequenceName.DMGHero);
		return totalDamage;
	}

	public static SMPNum GetCostOnLevel(double baseCost, int currentLevel, int lvToAdd = 1)
	{
		var _targetLevel = currentLevel + lvToAdd;
		var cost = SMPMathGamePlay.SumBaseOnCurrentLvAndTargetLv(currentLevel, _targetLevel, SequenceName.CostHero);
		return cost;
	}
}
