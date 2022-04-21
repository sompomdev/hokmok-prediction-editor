
public class QuestGameLevelCollectFirstCrownDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		return SMPQuestTemplateConstance.MAX_LEVEL_ON_STAGE - SMPQuestTemplateConstance.STAGE_COUNTER_PRE_REACH;
	}
}
