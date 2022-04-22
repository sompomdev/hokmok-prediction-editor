
public class QuestGameLevelVideoAdsDefine : QuestGameLevelBaseDefine
{
	//collect video from bird

	public override int GameLevelDefine()
	{
		var videoCount = questData.target;
		var timePerAds = SMPQuestTemplateConstance.TIME_PER_BIRD_APPEAR + SMPQuestTemplateConstance.TIME_PER_BIRD_APPEAR * SMPQuestTemplateConstance.PERCENT_NOT_VIDEO_BIRD;
		var timeAvailableAllChest = videoCount * timePerAds;
		return GetGameLevelCanReachBaseOnTime(timeAvailableAllChest);
	}
}
