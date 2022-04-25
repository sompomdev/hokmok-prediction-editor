using UnityEngine;
using System;

public class QuestGameLevelTapDefine : QuestGameLevelBaseDefine
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
		var gameLevel = tapCount / avgTapPerLevel;
		return gameLevel;
	}
}
