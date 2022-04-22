
public class QuestGameLevelWorldTourDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var worldTourCount = questData.target;
		var gameLvCount = QuestConstance.MAX_ZONE * QuestConstance.MAX_LEVEL_ON_STAGE * worldTourCount;
		return gameLvCount;
	}
}
