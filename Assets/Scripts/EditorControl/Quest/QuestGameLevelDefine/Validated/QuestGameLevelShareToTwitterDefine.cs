
public class QuestGameLevelShareToTwitterDefine : QuestGameLevelBaseDefine
{
	private int gameLevelStart = 40;
	public override int GameLevelDefine()
	{
		return gameLevelStart;
	}

	public override int AppearLevelDefine()
	{
		return GameLevelDefine() - 1;
	}
}
