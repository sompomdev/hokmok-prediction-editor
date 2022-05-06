
using UnityEngine;

public class QuestGameLevelReachNMastermindColorDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var reachTarget = questData.target;
		var gameLevel = GetGameLevelOnFirstPlayMastermind();
		var gameLevelReachTarget = reachTarget / SMPQuestTemplateConstance.PASS_COLOR_PER_MASTERMINE;

		//don't want appear same as normal play master mind
		gameLevel += 5;
		
		return gameLevel + gameLevelReachTarget;
	}

	public override int AppearLevelDefine()
	{
		var reachTarget = questData.target;
		var gameLevel = GameLevelDefine();
		var gameLevelReachTarget = reachTarget / SMPQuestTemplateConstance.PASS_COLOR_PER_MASTERMINE;
		return gameLevel - gameLevelReachTarget;
	}
}
