using System;
using UnityEngine;

public class QuestGameLevelObtainNBirdWeekDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var nBird = questData.target;
		var timeForNBird = QuestConstance.TIME_PER_BIRD_APPEAR * nBird;
		var gameLvBirdAppear = GetGameLevelCanReachBaseOnTime(timeForNBird);

		var timePerWeek = QuestConstance.AVERAGE_DAY_PLAY_PER_WEEK * QuestConstance.AVERAGE_HOURS_PLAY_PER_DAY * 3600;
		var birdPerWeek = timePerWeek / QuestConstance.TIME_PER_BIRD_APPEAR;
		var gameLvBirdPerWeek = GetGameLevelCanReachBaseOnTime(timePerWeek);

		Debug.Log($"lv {gameLvBirdAppear}  lvWeek {gameLvBirdPerWeek}");
		if(gameLvBirdAppear > gameLvBirdPerWeek)
		{
			Debug.LogError($"Not possible to appear bird {nBird} in 1 week of target time");
		}

		return gameLvBirdAppear;
	}
}
