
public class QuestGameLevelCollectNDiamondDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var diamondTarget = questData.target;
		var gameLv = GetGameLevelByDiamondFarmFromBossOnly(diamondTarget);
		return gameLv;
	}
}
