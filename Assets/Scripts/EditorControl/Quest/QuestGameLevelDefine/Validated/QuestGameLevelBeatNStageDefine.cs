
using System;

public class QuestGameLevelBeatNStageDefine : QuestGameLevelBaseDefine
{
	
	public override int GameLevelDefine()
	{
		var startLevel = 4;
		return questData.target + startLevel;
	}

	public override int AppearLevelDefine()
	{
		var gameLevel = GameLevelDefine() - questData.target;
		gameLevel = Math.Clamp(gameLevel, 1, gameLevel);
		return gameLevel;
	}
}
