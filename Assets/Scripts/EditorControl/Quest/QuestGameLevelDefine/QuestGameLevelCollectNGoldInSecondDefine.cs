
public class QuestGameLevelCollectNGoldInSecondDefine : QuestGameLevelBaseDefine
{
	private int timePerKillGhost = 4;//4 is the ballance second to kill ghost and 100 is the ballance score

	public override int GameLevelDefine()
	{
		if (questData.duration <= 0) return 0;

		var goldTarget = questData.bigTarget_GS;
		var countGhostFarm = questData.duration / timePerKillGhost;

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
