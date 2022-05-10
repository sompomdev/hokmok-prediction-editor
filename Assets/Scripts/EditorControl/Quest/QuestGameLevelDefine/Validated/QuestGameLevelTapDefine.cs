using UnityEngine;
using System;

public class QuestGameLevelTapDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var tapCount = questData.target;
		var avgTapPerLevel = SMPQuestTemplateConstance.TAP_AVG_PER_GAMELEVEL;
		
		if(tapCount <= avgTapPerLevel)
		{
			//first tap
			return 1;
		}

		var gameLevel = tapCount / avgTapPerLevel;
		return gameLevel;
	}
}
