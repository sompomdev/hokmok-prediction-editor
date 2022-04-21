
public class QuestGameLevelPlayNTimeDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var playTimeCount = questData.target;
		return GetGameLevelCanReachBaseOnTime(playTimeCount * SMPQuestTemplateConstance.AVERAGE_SECOND_PER_LUNCH_GAME);
	}
}
