using UnityEngine;
using System.Linq;
using System;

public class SMPManaLevelConfiguration 
{
    public const int DEFAULT_MANA_PLAYER = 0;
	public const int DEFAULT_RATE_GENERATION = 3;

    public static double GetMaxManaPool ()
    {
        //
        //SMPManaVariant.Instance().levelOfSkills

        //skills unlocked
        //levels of skills

        var skills = EditorDatas.instance.userSkillDatas.Where(a => a.is_unlocked);
		double totalMana = skills.Sum(a => a.manaCapBonus);// + SMPEquipmentDataShared.Instance().ManaCapIncrease;

        return totalMana;
    }    

    public static double GetManaPerMinutes ()
    {
        float baseRefill = DEFAULT_RATE_GENERATION;
        double totalRefill = GetManaBonusRefillSkill();
        
        totalRefill += baseRefill;
       // totalRefill += SMPEquipmentDataShared.Instance().ManaRateIncrease;

        return totalRefill;
    }

	public static double GetManaBonusRefillSkill()
	{
		double totalRefill = 0;
		var variant = SMPManaVariant.Instance();

		if (variant.numberOfMonsterKilledPerMinute >= 12)
		{
			totalRefill += 1;
		}
		if (variant.manaRateFromSupports > 0)
		{
			totalRefill += variant.manaRateFromSupports;
		}
		return totalRefill;
	}

	/*
	public static double GetMaxManaByHeroId(int heroId)
	{
		SMPHeroAndSkillData heroSkill = EditorDatas.instance.listHeroAndSkillData.FirstOrDefault(h => h.m_iHeroID == heroId);
		var userSkillData = GameSystem.Instance().gameControl.playerSkillControls.userSkillDatas;
		double mana = 0;
		foreach (var s in heroSkill.m_SkillList)
		{
			if (!s.m_bUnlocked) continue;
			var us = userSkillData.FirstOrDefault(ss => ss.m_iID == s.m_iSkillID);
			if (us == null) continue;
			mana += SMPActiveSkillLevelConfiguration.GetNextManaCapBonus(s.m_iSkillID, s.m_iLevel, us.base_ManaCap);
		}

		//double manaBonus = SMPEquipmentDataShared.Instance().ManaCapIncrease;
		return mana;// + manaBonus;
	}*/

	/*
	public static double GetCurrentManaByHeroId(int heroId)
	{
		var heroUnlock = GameData.Instance().userData.listHeroCharacterUnlocked.FirstOrDefault(h => h.id == heroId);
		if (heroUnlock == null) return 0;

		return heroUnlock.CurrentMana + CheckAndCalculateTimeForManaGeneration(heroId);
	}*/

		/*
	private static double CheckAndCalculateTimeForManaGeneration(int heroId)
	{
		var charData = GameData.Instance().userData.listHeroCharacterUnlocked.FirstOrDefault(h => h.id == heroId);
		var currentTime = DateTime.Now;
		TimeSpan difference = currentTime.Subtract(charData.timeSinceLastChecked_GS);
		float totalSeconds = (float)difference.TotalSeconds;
		if (totalSeconds <= 10)
		{
			return 0;
		}
		else
		{
			int howMany = Mathf.FloorToInt(totalSeconds / 10);
			double manaPerMin = Math.Ceiling(GetManaPerMinutes() / 6);
			return manaPerMin * howMany;
		}
	}*/
}
