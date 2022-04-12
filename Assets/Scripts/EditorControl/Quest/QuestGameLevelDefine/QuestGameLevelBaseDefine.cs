using UnityEngine;
using System;

public abstract class QuestGameLevelBaseDefine
{
	public QuestData questData { get; set; }

	public abstract int GameLevelDefine();
	
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
}
