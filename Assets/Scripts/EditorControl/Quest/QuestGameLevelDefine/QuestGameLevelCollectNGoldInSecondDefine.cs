
public class QuestGameLevelCollectNGoldInSecondDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		if (questData.duration <= 0) return 0;

		var goldTarget = questData.bigTarget_GS;
		var countGhostFarm = questData.duration / QuestConstance.TAP_PER_SECOND;

		var gameLv = 0;
		var goldCollect = new SMPNum(0);
		do
		{
			gameLv++;
			goldCollect = EditorController.instance.GetGoldToDrop(gameLv) * countGhostFarm;
		}
		while (goldCollect < goldTarget);
		return gameLv;
	}
}
