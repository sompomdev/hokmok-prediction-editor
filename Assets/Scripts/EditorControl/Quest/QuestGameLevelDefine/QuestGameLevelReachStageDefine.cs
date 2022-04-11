
public class QuestGameLevelReachStageDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		return questData.target - QuestConstance.STAGE_COUNTER_PRE_REACH;
	}
}
