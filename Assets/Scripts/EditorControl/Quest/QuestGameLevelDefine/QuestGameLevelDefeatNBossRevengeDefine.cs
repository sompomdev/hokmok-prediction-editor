
using System.Net.NetworkInformation;

public class QuestGameLevelDefeatNBossRevengeDefine : QuestGameLevelBaseDefine
{
	//Defeat [n] bosses of revenge!
	public override int GameLevelDefine()
	{
		var bossN = questData.target;
		var gameLevel = (bossN * 2);//two level will appear one revenge boss
		return gameLevel;
	}
}
