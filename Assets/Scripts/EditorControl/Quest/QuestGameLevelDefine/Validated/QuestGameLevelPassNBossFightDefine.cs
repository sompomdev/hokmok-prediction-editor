
using System.Net.NetworkInformation;

public class QuestGameLevelPassNBossFightDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var bossN = questData.target;
		var gameLevel = bossN;//one level will appear one boss
		return gameLevel;
	}
}
