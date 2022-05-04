using UnityEngine;

public class QuestGameLevelMakeNComboHitDefine : QuestGameLevelBaseDefine
{
	private int gameLevelStart = 2;
	public override int GameLevelDefine()
	{
		var nTime = questData.target;
		var gameLevel = gameLevelStart + Mathf.CeilToInt(nTime / 9f) - 1;//1 level can combo hit 9 times or 9 runes collect and -1 is can start count
		
		return gameLevel;
	}

	public override int AppearLevelDefine()
	{
		return gameLevelStart;
	}
}
