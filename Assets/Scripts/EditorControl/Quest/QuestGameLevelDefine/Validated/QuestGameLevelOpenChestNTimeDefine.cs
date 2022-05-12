
public class QuestGameLevelOpenChestNTimeDefine : QuestGameLevelBaseDefine
{
	//or Total of tap on bird

	private int gameLevelStart = 15;
	
	public override int GameLevelDefine()
	{
		var chestCount = questData.target;
		var timeAvailableAllChest = chestCount * SMPQuestTemplateConstance.TIME_PER_BIRD_APPEAR;
		return gameLevelStart + GetGameLevelCanReachBaseOnTime(timeAvailableAllChest);
	}

	public override int AppearLevelDefine()
	{
		return gameLevelStart;
	}
}
