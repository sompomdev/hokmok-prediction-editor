
public class QuestGameLevelCompleteYourNMissionDefine : QuestGameLevelBaseDefine
{
	//Complete your first mission!
	//Complete your 10 mission!
	//Clear [n] boss monsters
	
	public override int GameLevelDefine()
	{
		var missionCount = questData.target;
		var gameLevel = missionCount;//one level for one mission or one Boss
		return gameLevel;
	}
}
