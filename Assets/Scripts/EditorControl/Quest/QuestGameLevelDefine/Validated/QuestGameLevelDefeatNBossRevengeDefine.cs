
using System.Net.NetworkInformation;

public class QuestGameLevelDefeatNBossRevengeDefine : QuestGameLevelBaseDefine
{
	//Defeat [n] bosses of battle!
	public override int GameLevelDefine()
	{
		var levelStart = 1;
		var bossN = questData.target;
		var gameLevel = levelStart + (bossN * 2);//two level will appear one revenge boss and start from level 2
		gameLevel = gameLevel - (gameLevel % 2);//for level Boss Revenge only not Boss Battle
		return gameLevel;
	}

	public override int AppearLevelDefine()
	{
		var levelReward = GameLevelDefine();
		var bossN = questData.target;
		var levelAppear = levelReward - ((bossN - 1) * 2);//two level will appear one revenge boss and start from level
		return levelAppear;
	}
}
