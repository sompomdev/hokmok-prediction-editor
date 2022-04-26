
public class QuestGameLevelCollectNDiamondBirdDefine : QuestGameLevelBaseDefine
{
	//collect diamond from bird

	public override int GameLevelDefine()
	{
		var diamondTarget = questData.target;
		var timePerDiamondBird = SMPQuestTemplateConstance.TIME_PER_BIRD_APPEAR + SMPQuestTemplateConstance.TIME_PER_BIRD_APPEAR * SMPQuestTemplateConstance.PERCENT_NOT_DIAMOND_BIRD;
		var timeAvailableAllChest = diamondTarget * timePerDiamondBird;//one chest define as one diamond
		return GetGameLevelCanReachBaseOnTime(timeAvailableAllChest);
	}
}
