using UnityEngine;
using System;

public class QuestGameLevelTapNTimeInSecondDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var tapCount = questData.target;
		var avgTapPerLevel = SMPQuestTemplateConstance.TAP_AVG_PER_GAMELEVEL;//define 1 level can tap 40 time or 4 per monsters
		
		if(tapCount <= avgTapPerLevel)
		{
			//first tap
			return 1;
		}

		var gameLevelTap = tapCount / avgTapPerLevel;

		var avgDurationPerLevel = 40;
		var gameLevelDuration = Mathf.CeilToInt(questData.duration / avgDurationPerLevel);
		
		return Math.Max(gameLevelTap, gameLevelDuration);
	}
}
