
using Unity.VisualScripting.Dependencies.NCalc;

public class QuestGameLevelPlayTotalNMinuteDefine : QuestGameLevelBaseDefine
{
	private int gameLevelAppear = 5;
	
	public override int GameLevelDefine()
	{
		var playMinute = questData.target;
		var playInSeconds = playMinute * 60;
		return GetGameLevelCanReachBaseOnTime(playInSeconds);
	}

	public override int AppearLevelDefine()
	{
		return gameLevelAppear;
	}
}
