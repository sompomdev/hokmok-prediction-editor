
using UnityEngine;

public class QuestGameLevelCountNFruitMatchByColorDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var nMatch = questData.target;
		var gameLevel = GetGameLevelOnFirstPlayMastermind();
		var gameLevelReachTarget = nMatch / SMPQuestTemplateConstance.PASS_N_MATCH_PER_BOSS;

		int color = questData.fruitType;

		//don't want appear same as normal play master mind
		gameLevel += 2;
		
		//add level to avoid appear the same quest on difference color
		gameLevel += color * 5;
		
		return gameLevel + gameLevelReachTarget;
	}

	public override int AppearLevelDefine()
	{
		var nMatch = questData.target;
		var gameLevelReachTarget = nMatch / SMPQuestTemplateConstance.PASS_N_MATCH_PER_BOSS;
		var gameLevel = GameLevelDefine();
		return gameLevel - gameLevelReachTarget;
	}
}
