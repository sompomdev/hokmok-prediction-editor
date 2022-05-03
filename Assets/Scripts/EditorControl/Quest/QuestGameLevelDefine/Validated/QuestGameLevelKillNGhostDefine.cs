using System;
using UnityEngine;

public class QuestGameLevelKillNGhostDefine : QuestGameLevelBaseDefine
{
	private int levelStart = 1;
	public override int GameLevelDefine()
	{
		var ghostTarget = questData.target;
		var gameLevel = levelStart + Mathf.CeilToInt(ghostTarget * 1f / SMPQuestTemplateConstance.GHOST_PER_WAVE) - 1;//-1 refer to on level 0 to 1 we can count ghost ready
		return gameLevel;
	}

	public override int AppearLevelDefine()
	{
		return levelStart;
	}
}
