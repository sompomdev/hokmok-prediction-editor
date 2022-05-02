
using System.Net.NetworkInformation;

public class QuestGameLevelDefeatNBossBattleDefine : QuestGameLevelBaseDefine
{
	//Defeat [n] bosses of battle!
	public override int GameLevelDefine()
	{
		var levelStart = 2;
		var bossN = questData.target;
		var gameLevel = levelStart + (bossN * 2) - 1;//two level will appear one battle boss and start from level 1
		gameLevel = gameLevel - (gameLevel % 2) + 1;//for level Boss Battle only not Boss Revenge
		return gameLevel;
	}

	public override int AppearLevelDefine()
	{
		var levelReward = GameLevelDefine();
		var bossN = questData.target;
		var levelAppear = levelReward - ((bossN - 1) * 2);//two level will appear one battle boss and start from level
		return levelAppear;
	}
}
