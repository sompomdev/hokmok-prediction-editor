
public class QuestGameLevelCollectNGoldInSecondDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		if (questData.duration <= 0) return 0;

		var goldTarget = questData.bigTarget_GS;
		var countGhostFarm = questData.duration / QuestConstance.TAP_PER_SECOND;
		
		return GetGameLevelCanFarmForCost(goldTarget);
	}
}
