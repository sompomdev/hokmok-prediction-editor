using System;
using UnityEngine;

public class QuestGameLevelKillNGhostDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var ghostTarget = questData.target;
		var gameLevel = Mathf.CeilToInt(ghostTarget * 1f / SMPQuestTemplateConstance.GHOST_PER_WAVE);
		return gameLevel;
	}
}
