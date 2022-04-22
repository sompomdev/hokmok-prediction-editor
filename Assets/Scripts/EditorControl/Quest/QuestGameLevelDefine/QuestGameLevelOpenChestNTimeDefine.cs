
public class QuestGameLevelOpenChestNTimeDefine : QuestGameLevelBaseDefine
{
	//or Total of tap on bird

	public override int GameLevelDefine()
	{
		var chestCount = questData.target;
		var timeAvailableAllChest = chestCount * SMPQuestTemplateConstance.TIME_PER_BIRD_APPEAR;
		return GetGameLevelCanReachBaseOnTime(timeAvailableAllChest);
	}
}
