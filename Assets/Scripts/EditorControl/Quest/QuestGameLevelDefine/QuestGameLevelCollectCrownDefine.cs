
public class QuestGameLevelCollectCrownDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		return questData.target * SMPQuestTemplateConstance.MAX_LEVEL_ON_STAGE - SMPQuestTemplateConstance.STAGE_COUNTER_PRE_REACH;
	}
}
