using System;
using UnityEngine;

public class QuestGameLevelMakeReviveSupportNTimeDefine : QuestGameLevelBaseDefine
{
	private int gameLevelStart = 500;
	public override int GameLevelDefine()
	{
		var nTime = questData.target;
		var costPerRevive = SMPSupportLevelConfiguration.GetReviveCost(1);
		var gameLevel = gameLevelStart + nTime * GetGameLevelByDiamondBossDrop(costPerRevive);
		
		return gameLevel;
	}

	public override int AppearLevelDefine()
	{
		var gameLevel = GameLevelDefine();
		var nTime = questData.target;
		var gameLevelKillSupport = GetGameLevelCanReachBaseOnTime(120 * nTime);
		return gameLevel - gameLevelKillSupport;
	}
}
