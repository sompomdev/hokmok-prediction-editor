using UnityEngine;
using System;

public abstract class QuestGameLevelBaseDefine
{
	public QuestData questData { get; set; }

	public abstract int GameLevelDefine();

	protected int GetGameLevelFromGoldEarningBallance(int heroCount, int levelTarget)
	{
		var gameLv = 0;
		var goldEarning = new SMPNum(0);
		var goldNeed = SMPHeroLevelConfiguration.GetCostOnLevel(5, 0, levelTarget) * heroCount;
		do
		{
			gameLv++;
			goldEarning += EditorController.instance.GetGoldToDrop(gameLv) * QuestConstance.GHOST_PER_WAVE + 1;//ghost and boss gold drop
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
			dmgBalance = hp / (QuestConstance.TAP_PER_SECOND * tap);
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
			goldEarning += EditorController.instance.GetGoldToDrop(gameLv) * QuestConstance.GHOST_PER_WAVE + 1;//ghost and boss gold drop
		}
		while (goldEarning < goldNeed);

		return gameLv;
	}

	protected int GetGameLevelCanReachBaseOnTime(double time)
	{
		var timeOnOneLevel = (QuestConstance.GHOST_PER_WAVE * QuestConstance.TIME_PER_GHOST) + QuestConstance.TIME_PER_BOSS;
		return (int)(time / timeOnOneLevel);
	}

	protected int GetGameLevelCanFarmForCost(SMPNum skillCosts)
	{
		var gameLv = 0;
		var goldEarning = new SMPNum(0);
		do
		{
			gameLv++;
			goldEarning += EditorController.instance.GetGoldToDrop(gameLv) * QuestConstance.GHOST_PER_WAVE + 1;//ghost and boss gold drop
		}
		while (goldEarning < skillCosts);

		return gameLv;
	}
}
