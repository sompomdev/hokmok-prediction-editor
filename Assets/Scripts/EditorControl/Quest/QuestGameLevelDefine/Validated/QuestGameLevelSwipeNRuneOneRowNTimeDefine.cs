using System;
using UnityEngine;

public class QuestGameLevelSwipeNRuneOneRowNTimeDefine : QuestGameLevelBaseDefine
{
	private int gameLevelStart = 3;

	public override int GameLevelDefine()
	{
		var nTime = questData.target;
		var nRune = questData.target2;
		var totalRune = nTime * nRune;
		var gameLevel = gameLevelStart + Mathf.CeilToInt(totalRune / 6f) - 1;//1 level can collect 6 runes in horizontal and -1 is can start count
		
		return gameLevel;
	}

	public override int AppearLevelDefine()
	{
		return gameLevelStart;
	}
}
