
using UnityEngine;

public class QuestGameLevelReachNMastermindColorDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var reachTarget = questData.target;
		var gameLevel = GetGameLevelOnFirstPlayMastermind();
		var gameLevelReachTarget = reachTarget / SMPQuestTemplateConstance.PASS_COLOR_PER_MASTERMINE;
		return gameLevel + gameLevelReachTarget;
	}
}
