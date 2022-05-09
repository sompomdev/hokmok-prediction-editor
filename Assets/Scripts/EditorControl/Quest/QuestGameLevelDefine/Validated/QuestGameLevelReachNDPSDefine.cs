using UnityEngine;
using System;

public class QuestGameLevelReachNDPSDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var dpsTarget = questData.bigTarget_GS;
		var dps = new SMPNum(0);
		var tapPerSecond = 5;
		var heroLv = 1;
		do
		{
			dps = SMPHeroLevelConfiguration.GetDamageWithoutAnyBonus(heroLv) * tapPerSecond;
			heroLv++;
		} while (dps < dpsTarget);

		var cost = SMPHeroLevelConfiguration.GetCostOnLevel(5, 1, heroLv - 1);
		var gameLevel = GetGameLevelCanFarmForCost(cost);
		return gameLevel;
	}

	public override int AppearLevelDefine()
	{
		var gameLevel = GameLevelDefine();
		gameLevel -= 5;
		gameLevel = Math.Max(1, gameLevel);
		return gameLevel;
	}

	protected int GetGameLevelByDPSCalculate()
	{
		var dpsTarget = questData.bigTarget_GS;
		var gameLevel = 1;
		var ghostHp = new SMPNum(0);
		var dps = new SMPNum(0);
		do
		{
			ghostHp = GetGhostHp(gameLevel);
			dps = ghostHp / 4;//dps to kill one ghost in 4 seconds
			gameLevel++;
		} while (dps<dpsTarget);
		
		return gameLevel;
	}
	
	protected SMPNum GetGhostHp(int lv)
	{
		var commonRatio = new SMPNum(SMPMathCore.GetSeriesCommonRatioByLevel(lv, SequenceName.HPGhost));
		var firstTerm = SMPMathCore.GetSeriesFirstTermByLevel(lv, SequenceName.HPGhost);
		return firstTerm * commonRatio.Pow(lv - 1);
	}
}
