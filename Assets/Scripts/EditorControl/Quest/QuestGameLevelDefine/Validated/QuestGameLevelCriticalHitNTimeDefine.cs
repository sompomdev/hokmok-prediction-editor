using UnityEngine;
using System;

public class QuestGameLevelCriticalHitNTimeDefine : QuestGameLevelBaseDefine
{
	private int levelStart = 4;
	public override int GameLevelDefine()
	{
		var nTime = questData.target;
		
		//critical hit probability 150% time per level
		var gameLevel = levelStart + Mathf.RoundToInt(nTime / 1.5f);
		
		return gameLevel;
	}

	public override int AppearLevelDefine()
	{
		return levelStart;
	}
}
