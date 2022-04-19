
public class QuestGameLevelPlayTotalNHourDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var playHour = questData.target;
		var playInSeconds = playHour * 3600;
		return GetGameLevelCanReachBaseOnTime(playInSeconds);
	}
}
