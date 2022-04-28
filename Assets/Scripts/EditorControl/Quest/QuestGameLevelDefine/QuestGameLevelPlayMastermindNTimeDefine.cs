
using UnityEngine;

public class QuestGameLevelPlayMastermindNTimeDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var playNTarget = questData.target;
		var gameLevel = GetGameLevelOnFirstPlayMastermind();
		
		//play one time per fight boss
		gameLevel += playNTarget;

		return gameLevel;
	}
}
