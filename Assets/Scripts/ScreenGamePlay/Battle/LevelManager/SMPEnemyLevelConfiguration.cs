
using UnityEngine;
//using Sompom.GamePlay.Enemy;
//using Sompom.Common;
//using System;
//using Sompom.Inventory;
using System.Collections.Generic;
using System.Linq;

public enum BossType
{
	BigBoss,
	ZoneBoss,
	RevengeBoss
}

public struct ENEMY_PROMOTE_CRITERIA
{
	public int level;
	public int wave;
	public ENEMY_POSITION enemy_position;
	public WAVE_MODE wave_mode;

	public ENEMY_PROMOTE_CRITERIA(int lv, int wa, ENEMY_POSITION e_pos, WAVE_MODE w_mode)
	{
		level = lv;
		wave = wa;
		enemy_position = e_pos;
		wave_mode = w_mode;
	}
}

public enum ENEMY_POSITION
{
	NONE,
	MAIN,
	LEFT,
	RIGHT
}
public enum WAVE_MODE
{
	NONE,
	ENDLESS,
	BOSS
}

public class SMPEnemyLevelConfiguration
{
    public int level;
    public SMPNum enemyDamage;
    public SMPNum enemyHP;
    public float enemyAttackSpeed;

    public static SMPEnemyLevelConfiguration GetLevelConfiguration(ENEMY_PROMOTE_CRITERIA criteria)
    {
        SMPEnemyLevelConfiguration level1 = new SMPEnemyLevelConfiguration();
        level1.level = criteria.level;

        if (criteria.wave_mode == WAVE_MODE.ENDLESS)
        {
            int stage = criteria.level;
            SMPNum maxHp = SMPMathGamePlay.GetUnBaseOnLevel(stage, SequenceName.HPGhost); 
            level1.enemyHP = maxHp.Round();
        }
        else
        { 	
            level1.enemyAttackSpeed = 2f;
            int stage = criteria.level;

            //if (criteria.wave >= GameSystem.Instance().gameControl.battleSystem.battleControl.monstersystem.MaxWaveCount)
            //{// it's boss wave
            //    level1.enemyHP = BossHP(stage).Round();
            //}
            //else
            {
                level1.enemyHP = SMPMathGamePlay.GetUnBaseOnLevel(stage, SequenceName.HPGhost).Round();
            }

            //SMPNum totalHPlayer = GameSystem.Instance().gameControl.battleSystem.battleControl.heroHPUIController.GetMaxCurrentHP;
			SMPNum enemyDamage;
			
			/* Disable Kill by second
			//damage formula by kill timer in 60 second
            float timeToKillHero = 60;
			enemyDamage = totalHPlayer/ (timeToKillHero/level1.enemyAttackSpeed);*/

			// Damage by formula
			enemyDamage = SMPMathGamePlay.GetUnBaseOnLevel(stage, SequenceName.DMGBoss);

			level1.enemyDamage = enemyDamage;
		}
		
        return level1;
    }


	/* We don't use it more, it the old formula of Boss Hp
    public static double GetBossHealthMatching(ENEMY_PROMOTE_CRITERIA criteria) //use for difficulty calculation only
    {
        int stage = criteria.level;
		double maxHp = Math.Floor(7 * System.Math.Pow(1.57f, System.Math.Min(stage, 156)) * System.Math.Pow(1.17f, System.Math.Max(stage - 156, 0)));
		double bossHealth = 0;

		int[] listInt;
		int index = GameData.Instance().GetBossIndexByLevel(stage) + 1;
		if (GameData.Instance().GetZoneByLevel(stage) == 0)
		{
			listInt = new int[] { 2, 2, 3, 3, 4, 4, 5, 5, 7 };//{ 2, 2, 4, 4, 6, 6, 7, 7, 10 };
		}
		else
		{
			listInt = new int[] { 7,2, 2, 3, 3, 4, 4, 5, 5, 7 };//{ 10, 2, 2, 4, 4, 6, 6, 7, 7, 10 };
		}
		if (stage % 2 == 0)
		{
			stage -= 1;
			//maxHp = Math.Floor(18.5f * System.Math.Pow(1.57f, System.Math.Min(stage, 156)) * System.Math.Pow(1.17f, System.Math.Max(stage - 156, 0)));
			maxHp = Math.Floor(7 * System.Math.Pow(1.57f, System.Math.Min(stage, 156)) * System.Math.Pow(1.17f, System.Math.Max(stage - 156, 0)));
		}
		int bonuses = 0;
        bossHealth = maxHp * listInt[index] * (1 - bonuses);
        bossHealth.ClampNotInfinity();

        return bossHealth;
    }*/

		/*
    public static void RefreshDamageOfMonster (SMPEnemyData enemyData)
    {
        if (enemyData.attackSpeed <= 0)
        {
            return;
        }
        SMPNum totalHPlayer = GameSystem.Instance().gameControl.battleSystem.battleControl.heroHPUIController.GetMaxCurrentHP;
        float timeToKillHero = 60;//in second
        SMPNum enemyDamage = totalHPlayer / (timeToKillHero / enemyData.attackSpeed);
        enemyData.damage = enemyDamage;

		//Damage in range
		//enemyData.damgaeRanges = new SMPNum[4];
		//enemyData.damgaeRanges[0] = enemyDamage / 20;
		//for (int i = 1; i <= 3; i++)
		//{
		//	timeToKillHero = 60 + (i * 20);
		//	enemyData.damgaeRanges[i] = (totalHPlayer / (timeToKillHero / enemyData.attackSpeed))/20;
		//}
	}

    public static SMPNum stageBaseHP()
    {
        int stage = GameSystem.Instance().gameControl.battleSystem.battleControl.monstersystem.GetSetCurrentLv;
        SMPNum baseHp = SMPMathGamePlay.GetUnBaseOnLevel(stage, SequenceName.HPGhost);
            
        return baseHp ;
    }*/

    public static SMPNum BossHP (int level)
    {
        SMPNum baseHp = SMPMathGamePlay.GetUnBaseOnLevel(level, SequenceName.HPBoss);
        return baseHp;
    }

    public static Color32 GetColorMatching()
    {
        Color newColor = new Color(UnityEngine.Random.value, UnityEngine.Random.value, UnityEngine.Random.value, 1.0f);
        return newColor;
    }

    public static SMPNum CoinToDrop(int stage)
    {
        var coins = SMPMathGamePlay.GetUnBaseOnLevel(stage, SequenceName.DropCoins);
		//coins = coins + coins * SMPEquipmentDataShared.Instance().GoldDropIncreasePercentage * 0.01;
        return coins;
    }

	/*
    public static SMPNum GetChestCoinToDrop(SMPEnemyData enemyData, int stage)
    {
        //http://yatto.me/#/formulas
        //10 * (1 + 0.2 * chestLevel) * (1 + customChest ) * ( 1 + chestGoldBonus)
		SMPNum gold = (10 * (1 + GameSystem.Instance().gameControl.battleSystem.TotalPersentChestGold) * CoinToDrop(stage));
		if (gold < 20)
		{
			gold.SetNum(20);
		}
		return gold;
    }*/

    public static SMPNum GetBonusMakeItRainCoin(SMPNum coinTarget)
    {
        SMPNum result = 5000 * coinTarget;
        return result;
    }
    public static SMPNum GetBonusMakeItRainCoinForOneBird(SMPNum coinTarget)
    {
        int totalBird = 20;
        SMPNum result = (5000/totalBird) * coinTarget;
        return result;
    }

	public static int DiamondDropOnZoneBossKill(int bossLv, BossType bossType, int totalDiamondSpent)
	{
		/* Disable the diamond from hero level bonus
		int count = m_HeroesList.Count(h => h.m_iCurrentLevel > bossLv);
		return Mathf.Min(count,8) + 1;
		*/

		//give the diamond only Big Boss
		if(bossType == BossType.ZoneBoss)
		{
			return 1;
		}
		return 0;
	}
}
