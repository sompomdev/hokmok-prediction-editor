
using UnityEngine;

public class QuestGameLevelWinMastermindNTimeDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var winNTime = questData.target;
		var gameLevel = GetGameLevelOnFirstPlayMastermind();
		
		//play one time per fight boss, should win one time per boss
		gameLevel += winNTime;

		return gameLevel;
	}

	public override int AppearLevelDefine()
	{
		var gameLevel = GetGameLevelOnFirstPlayMastermind() + 1;
		return gameLevel;
	}
}
