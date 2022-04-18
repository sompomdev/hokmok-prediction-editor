
public class QuestGameLevelVideoAdsDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var videoCount = questData.target;
		var timePerAds = QuestConstance.TIME_PER_BIRD_APPEAR + QuestConstance.TIME_PER_BIRD_APPEAR * QuestConstance.PERCENT_VIDEO_BIRD;
		var timeAvailableAllChest = videoCount * timePerAds;
		return GetGameLevelCanReachBaseOnTime(timeAvailableAllChest);
	}
}
