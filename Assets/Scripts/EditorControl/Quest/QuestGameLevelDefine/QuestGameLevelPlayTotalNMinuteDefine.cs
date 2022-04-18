
public class QuestGameLevelPlayTotalNMinuteDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var playMinute = questData.target;
		var playInSeconds = playMinute * 60;
		return GetGameLevelCanReachBaseOnTime(playInSeconds);
	}
}
