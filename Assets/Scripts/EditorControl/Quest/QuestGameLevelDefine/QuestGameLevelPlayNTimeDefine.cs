
public class QuestGameLevelPlayNTimeDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var playTimeCount = questData.target;
		return GetGameLevelCanReachBaseOnTime(playTimeCount * QuestConstance.AVERAGE_SECOND_PER_LUNCH_GAME);
	}
}
