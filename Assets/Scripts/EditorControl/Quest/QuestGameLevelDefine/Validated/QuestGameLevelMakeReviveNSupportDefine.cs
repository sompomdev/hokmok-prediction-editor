using System;
using UnityEngine;

public class QuestGameLevelMakeReviveNSupportDefine : QuestGameLevelBaseDefine
{
	private int gameLevelStart = 500;
	public override int GameLevelDefine()
	{
		var nSupport = questData.target;
		var costPerRevive = SMPSupportLevelConfiguration.GetReviveCost(1);
		var gameLevel = gameLevelStart + nSupport * GetGameLevelByDiamondBossDrop(costPerRevive);
		
		return gameLevel;
	}

	public override int AppearLevelDefine()
	{
		return gameLevelStart;
	}
}
