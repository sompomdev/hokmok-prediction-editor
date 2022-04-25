
public class QuestGameLevelCompleteYourNMissionDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var missionCount = questData.target;
		var gameLevel = missionCount;//one level for one mission or one Boss
		return gameLevel;
	}
}
