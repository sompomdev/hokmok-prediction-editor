
public class QuestGameLevelPlayTotalNDayDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var playDay = questData.target;
		var playInSeconds = playDay * 24 * 3600;
		return GetGameLevelCanReachBaseOnTime(playInSeconds);
	}
}
