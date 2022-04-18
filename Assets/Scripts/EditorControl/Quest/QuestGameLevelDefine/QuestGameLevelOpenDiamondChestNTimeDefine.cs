
public class QuestGameLevelOpenDiamondChestNTimeDefine : QuestGameLevelBaseDefine
{
	//collect diamond from bird

	public override int GameLevelDefine()
	{
		var diamondChestCount = questData.target;
		var timePerDiamondBird = QuestConstance.TIME_PER_BIRD_APPEAR + QuestConstance.TIME_PER_BIRD_APPEAR * QuestConstance.PERCENT_NOT_DIAMOND_BIRD;
		var timeAvailableAllChest = diamondChestCount * timePerDiamondBird;
		return GetGameLevelCanReachBaseOnTime(timeAvailableAllChest);
	}
}
