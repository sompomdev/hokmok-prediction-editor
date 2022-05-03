
public class QuestGameLevelFailNTimeDefine : QuestGameLevelBaseDefine
{
	private int gameLevelStart = 25;
	public override int GameLevelDefine()
	{
		var nTime = questData.target;
		var gameLevel = gameLevelStart + nTime;//fail 1 time define is 1 kpi levels
		
		return gameLevel;
	}

	public override int AppearLevelDefine()
	{
		return gameLevelStart;
	}
}
