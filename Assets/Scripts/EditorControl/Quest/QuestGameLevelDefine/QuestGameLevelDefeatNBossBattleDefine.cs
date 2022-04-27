
using System.Net.NetworkInformation;

public class QuestGameLevelDefeatNBossBattleDefine : QuestGameLevelBaseDefine
{
	//Defeat [n] bosses of battle!
	public override int GameLevelDefine()
	{
		var bossN = questData.target;
		var gameLevel = (bossN * 2) -1;//two level will appear one battle boss and start from level 1
		return gameLevel;
	}
}
