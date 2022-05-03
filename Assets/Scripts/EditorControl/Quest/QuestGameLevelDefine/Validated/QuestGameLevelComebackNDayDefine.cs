
public class QuestGameLevelComebackNDayDefine : QuestGameLevelBaseDefine
{
	private int gameLevelStart = 40;
	public override int GameLevelDefine()
	{
		var day = questData.target;
		var gameLevel = gameLevelStart + (day * 10);
		
		return gameLevel;
	}

	public override int AppearLevelDefine()
	{
		return gameLevelStart;
	}
}
