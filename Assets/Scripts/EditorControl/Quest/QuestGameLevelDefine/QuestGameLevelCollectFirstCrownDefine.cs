
public class QuestGameLevelCollectFirstCrownDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		return QuestConstance.MAX_LEVEL_ON_STAGE - QuestConstance.STAGE_COUNTER_PRE_REACH;
	}
}
