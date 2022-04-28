
using UnityEngine;

public class QuestGameLevelPlayMastermindNTimeDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var playNTarget = questData.target;
		var costUnlock = GetCostAllSupportUnlock(4);
		var gameLevel = GetGameLevelCanFarmForCost(costUnlock);
		
		//for first boss after support unlock will have tutorial so mastermind not appear
		gameLevel += 1;
		
		//play one time per fight boss
		gameLevel += playNTarget;

		return gameLevel;
	}
}
