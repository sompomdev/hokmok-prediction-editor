using System;

public class QuestGameLevelMakeReviveAllNTimeDefine : QuestGameLevelBaseDefine
{
	private int gameLevelStart = 30;
	public override int GameLevelDefine()
	{
		var nTime = questData.target;
		var costPerRevive = SMPHeroLevelConfiguration.GetReviveCost(1);
		var gameLevel = gameLevelStart + nTime * GetGameLevelByDiamondBossDrop(costPerRevive);
		
		return gameLevel;
	}

	public override int AppearLevelDefine()
	{
		var gameLevel = GameLevelDefine();
		
		//add 1 level before appear
		gameLevel -= 1;
		
		return gameLevel;
	}
}
