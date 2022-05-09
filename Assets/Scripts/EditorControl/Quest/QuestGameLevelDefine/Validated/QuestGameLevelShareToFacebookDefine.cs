
public class QuestGameLevelShareToFacebookDefine : QuestGameLevelBaseDefine
{
	private int gameLevelStart = 50;
	public override int GameLevelDefine()
	{
		return gameLevelStart;
	}

	public override int AppearLevelDefine()
	{
		return GameLevelDefine() - 1;
	}
}
