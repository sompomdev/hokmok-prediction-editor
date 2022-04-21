
public class QuestGameLevelWorldTourDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var worldTourCount = questData.target;
		var gameLvCount = SMPQuestTemplateConstance.MAX_ZONE * SMPQuestTemplateConstance.MAX_LEVEL_ON_STAGE * worldTourCount;
		return gameLvCount - SMPQuestTemplateConstance.STAGE_COUNTER_PRE_WORLD_REACH;
	}
}
