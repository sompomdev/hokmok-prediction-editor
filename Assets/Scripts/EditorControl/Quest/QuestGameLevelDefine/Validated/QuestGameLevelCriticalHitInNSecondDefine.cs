using UnityEngine;
using System;

public class QuestGameLevelCriticalHitInNSecondDefine : QuestGameLevelBaseDefine
{
	private int levelStart = 8;
	public override int GameLevelDefine()
	{
		var nTime = questData.target;
		
		//critical hit probability 150% time per level
		var gameLevel = Mathf.RoundToInt(nTime / 1.5f);
		
		var avgDurationPerLevel = SMPQuestTemplateConstance.TAP_AVG_PER_GAMELEVEL * 0.1f;
		var gameLevelDuration = Mathf.CeilToInt(questData.duration / avgDurationPerLevel);
		
		return levelStart + Math.Max(gameLevel, gameLevelDuration);
	}

	public override int AppearLevelDefine()
	{
		return levelStart;
	}
}
