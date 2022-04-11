
public class QuestGameLevelCollectNGoldDefine : QuestGameLevelBaseDefine
{
	private int countGhostFarm = 10;

	public override int GameLevelDefine()
	{
		var goldTarget = questData.bigTarget_GS;
		
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
