using UnityEngine;
using System;

public class QuestGameLevelPlayOnWeekendDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var dayReward = 2;
		var secondsBeforeWeekend = dayReward * SMPQuestTemplateConstance.AVERAGE_HOURS_PLAY_PER_DAY * 3600;
		var gameLevel = GetGameLevelCanReachBaseOnTime(secondsBeforeWeekend);
		
		DebugJumping();
		
		return gameLevel;
	}

	public override int AppearLevelDefine()
	{
		var gameLevel = GameLevelDefine();
		var dayBeforeWeekend = 1;
		var secondsBeforeWeekend = dayBeforeWeekend * SMPQuestTemplateConstance.AVERAGE_HOURS_PLAY_PER_DAY * 3600;
		var glCountAppear = GetGameLevelCanReachBaseOnTime(secondsBeforeWeekend);
		Debug.Log("gamelevel count before appear "+glCountAppear);
		var levelAppear = gameLevel - glCountAppear;
		return levelAppear;
	}

	protected void DebugJumping()
	{
		var dayPerWeek = SMPQuestTemplateConstance.AVERAGE_DAY_PLAY_PER_WEEK;
		var secondPerDay = SMPQuestTemplateConstance.AVERAGE_HOURS_PLAY_PER_DAY * 3600;
		var totalSeconds = dayPerWeek * secondPerDay;
		var jumpingLevel = GetGameLevelCanReachBaseOnTime(totalSeconds);
		Debug.Log("Jumping "+jumpingLevel);
	}
}
