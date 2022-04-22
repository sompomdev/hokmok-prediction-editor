
public class QuestGameLevelFirstWorldLoopDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var gameLvCount = SMPQuestTemplateConstance.MAX_ZONE * SMPQuestTemplateConstance.MAX_LEVEL_ON_STAGE;
		return gameLvCount;
	}
}
