using UnityEngine;
using System;
using Sompom.Inventory;

public abstract class QuestGameLevelBaseDefine
{
	public QuestData questData { get; set; }

	public abstract int GameLevelDefine();

	public virtual int AppearLevelDefine()
	{
		return 1;
	}

	protected int GetGameLevelFromGoldEarningBallance(int heroCount, int levelTarget)
	{
		var gameLv = 0;
		var goldEarning = new SMPNum(0);
		var goldNeed = SMPHeroLevelConfiguration.GetCostOnLevel(5, 1, levelTarget) * heroCount;
		do
		{
			gameLv++;
			goldEarning += GetGoldToDrop(gameLv) * SMPQuestTemplateConstance.GHOST_PER_WAVE + 1;//ghost and boss gold drop
		}
		while (goldEarning < goldNeed);

		return gameLv;
	}

	protected int GetGameLevelFromDMGBallance(int levelTarget)
	{
		var gameLv = 0;
		var dmgBalance = new SMPNum();
		var dmgTarget = EditorController.instance.GetHeroDmg(levelTarget);
		do
		{
			gameLv++;
			var hp = EditorController.instance.GetBossHp(gameLv);
			//var hp = EditorController.instance.GetGhostHp(gameLv);
			var tap = EditorController.instance.TapPerSec;
			dmgBalance = hp / (SMPQuestTemplateConstance.KILL_PER_SECOND * tap);
		}
		while (dmgBalance < dmgTarget);

		return gameLv;
	}

	protected int GetGameLevelHeroCanReachLevel(int heroLv, SMPNum skillCosts)
	{
		var gameLv = 0;
		var goldEarning = new SMPNum(0);
		var goldNeed = SMPHeroLevelConfiguration.GetCostOnLevel(5, 0, heroLv) + skillCosts;
		do
		{
			gameLv++;
			goldEarning += GetGoldToDrop(gameLv) * SMPQuestTemplateConstance.GHOST_PER_WAVE + 1;//ghost and boss gold drop
		}
		while (goldEarning < goldNeed);

		return gameLv;
	}

	protected int GetGameLevelCanReachBaseOnTime(double time)
	{
		var timeOnOneLevel = (SMPQuestTemplateConstance.GHOST_PER_WAVE * SMPQuestTemplateConstance.TIME_PER_GHOST) + SMPQuestTemplateConstance.TIME_PER_BOSS;
		return (int)(time / timeOnOneLevel);
	}

	protected int GetGameLevelCanFarmForCost(SMPNum cost)
	{
		var gameLv = 0;
		var goldEarning = new SMPNum(0);
		do
		{
			gameLv++;
			goldEarning += GetGoldToDrop(gameLv) * SMPQuestTemplateConstance.GHOST_PER_WAVE + 1;//ghost and boss gold drop
		}
		while (goldEarning < cost);

		return gameLv;
	}

	protected SMPNum GetCostAllSupportUnlock(int supportNeedUnlock)
	{
		var cost = new SMPNum(0);
		for (int i = 1; i <= supportNeedUnlock; i++)
		{
			var supportData = EditorDatas.instance.GetSupportData(i);
			supportData.m_bHired = false;
			cost += SMPSupportLevelConfiguration.GetLevelConfiguration(supportData, 1).cost;
		}
		return cost;
	}

	protected SMPNum GetGoldToDrop(int gameLv)
	{
		var coins = SMPMathGamePlay.GetUnBaseOnLevel(gameLv, SequenceName.DropCoins);
		return coins;
	}

	protected int GetGameLevelPetUnlock(int petUnlockTarget)
	{
		int lvUnlock = 0;
		if (petUnlockTarget < 10)
		{
			//under 100 gamelevel => unlock 1 pet per 10 level
			lvUnlock = petUnlockTarget * 10;
		}
		else
		{
			//upper 100 gamelevel => unlock 1 pet per 100 level
			//minus 9 pecause we got 9 pet will unlock before 100 game level ready
			lvUnlock = (petUnlockTarget - 9) * 100;
		}
		return lvUnlock;
	}

	protected int GetGameLevelByDiamondBossDrop(int diamond)
	{
		if(diamond <= SMPQuestTemplateConstance.DIAMOND_GAME_STARTUP)
		{
			return 1;
		}

		diamond -= SMPQuestTemplateConstance.DIAMOND_GAME_STARTUP;

		//10 game level will drop 1 diamon
		var gameLevel = diamond * SMPQuestTemplateConstance.STAGE_TO_DROP_ONE_DIAMOND;
		return gameLevel;
	}

	protected int GetGameLevelByDiamondFarmFromBossOnly(int diamond)
	{
		//10 game level will drop 1 diamon
		var gameLevel = diamond * SMPQuestTemplateConstance.STAGE_TO_DROP_ONE_DIAMOND;
		return gameLevel;
	}

	protected int GetGameLevelByDiamondForPetUpdate(int petCount, int updateTime)
	{
		var gameLvDropEgg = GetGameLevelPetUnlock(petCount);

		var petData = new SMPPetsData();
		petData.petCurrentLevel = 0;//start update level from 0
		int cost = 0;
		do
		{
			petData.petCurrentLevel++;
			cost += SMPPetLevelConfiguration.GetCostDependingOnNumOfLevelToAdd(petData) * petCount;
		}
		while (petData.petCurrentLevel < updateTime);

		var gameLvToGetDiamond = GetGameLevelByDiamondBossDrop(cost);
		return Math.Max(gameLvDropEgg, gameLvToGetDiamond);
	}
}
