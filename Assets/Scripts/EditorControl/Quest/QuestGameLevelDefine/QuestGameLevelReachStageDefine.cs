
public class QuestGameLevelReachStageDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		return questData.target - SMPQuestTemplateConstance.STAGE_COUNTER_PRE_REACH;
	}
}
