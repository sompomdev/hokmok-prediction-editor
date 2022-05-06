
using UnityEngine;

public class QuestGameLevelPlayMastermindNTimeDuringDayDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var playNTarget = questData.target;
		var gameLevel = GetGameLevelOnFirstPlayMastermind();

		var secondPerDay = SMPQuestTemplateConstance.AVERAGE_HOURS_PLAY_PER_DAY * 3600;
		var levelPerDay = GetGameLevelCanReachBaseOnTime(secondPerDay);

		if (levelPerDay < playNTarget)
		{
			Debug.LogError($"Not possible play master mind {playNTarget} one day");
		}
		else
		{
			Debug.Log("Gamelevel perday "+levelPerDay);
		}
		
		//play one time per fight boss
		gameLevel += playNTarget;
		
		//add more level to not appear on normal play master mind
		gameLevel += 20;

		return gameLevel;
	}

	public override int AppearLevelDefine()
	{
		var gameLevel = GameLevelDefine();
		var playNTarget = questData.target;
		return gameLevel - playNTarget + 1;
	}
}
