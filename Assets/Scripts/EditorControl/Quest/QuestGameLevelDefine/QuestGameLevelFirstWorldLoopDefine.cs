
public class QuestGameLevelFirstWorldLoopDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var gameLvCount = QuestConstance.MAX_ZONE * QuestConstance.MAX_LEVEL_ON_STAGE;
		return gameLvCount;
	}
}
