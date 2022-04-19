
public class QuestGameLevelCollectCrownDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		return questData.target * QuestConstance.MAX_LEVEL_ON_STAGE - QuestConstance.STAGE_COUNTER_PRE_REACH;
	}
}
