
public class QuestGameLevelCompleteYourNMissionDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var missionCount = questData.target;
		var gameLevel = (missionCount * 2) - 1;//two level for one mission or one Battle Boss
		return gameLevel;
	}
}
