using UnityEngine;
using System;

public class QuestGameLevelTapNTimeInSecondDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var tapCount = questData.target;
		if(tapCount <= 4)
		{
			//first tap
			return 1;
		}

		var avgTapPerLevel = 4;
		var gameLevelTap = tapCount / avgTapPerLevel;

		var avgDurationPerLevel = 4;
		var gameLevelDuration = Mathf.CeilToInt(questData.duration / avgDurationPerLevel);
		
		return Math.Max(gameLevelTap, gameLevelDuration);
	}
}
