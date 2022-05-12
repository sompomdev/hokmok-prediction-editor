using System;
using UnityEngine;

public class QuestGameLevelObtainNBirdWeekDefine : QuestGameLevelBaseDefine
{
	private int gameLevelStart = 30;
	public override int GameLevelDefine()
	{
		var nBird = questData.target;
		var timeForNBird = SMPQuestTemplateConstance.TIME_PER_BIRD_APPEAR * nBird;
		var gameLvBirdAppear = GetGameLevelCanReachBaseOnTime(timeForNBird);

		var timePerWeek = SMPQuestTemplateConstance.AVERAGE_DAY_PLAY_PER_WEEK * SMPQuestTemplateConstance.AVERAGE_HOURS_PLAY_PER_DAY * 3600;
		var birdPerWeek = timePerWeek / SMPQuestTemplateConstance.TIME_PER_BIRD_APPEAR;
		var gameLvBirdPerWeek = GetGameLevelCanReachBaseOnTime(timePerWeek);

		Debug.Log($"lv {gameLvBirdAppear}  lvWeek {gameLvBirdPerWeek}");
		if(gameLvBirdAppear > gameLvBirdPerWeek)
		{
			Debug.LogError($"Not possible to appear bird {nBird} in 1 week of target time");
		}

		return gameLevelStart + gameLvBirdAppear;
	}

	public override int AppearLevelDefine()
	{
		return gameLevelStart;
	}
}
