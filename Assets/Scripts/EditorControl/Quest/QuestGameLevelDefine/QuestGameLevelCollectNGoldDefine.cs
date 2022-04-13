
public class QuestGameLevelCollectNGoldDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var goldTarget = questData.bigTarget_GS;
		var countGhostFarm = QuestConstance.GHOST_FARM_PER_QUEST;
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
