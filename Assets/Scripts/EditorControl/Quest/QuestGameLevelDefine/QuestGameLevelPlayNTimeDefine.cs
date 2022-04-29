
public class QuestGameLevelPlayNTimeDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var playTimeCount = questData.target;
		return playTimeCount;
	}

	public override int AppearLevelDefine()
	{
		return GameLevelDefine() - 1;
	}
}
