
public class QuestGameLevelUpgradeNHeroReachRankDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var heroCount = questData.target;
		RankType rankType = (RankType)questData.target2;
		var heroLvTarget = Helper.GetHeroMinLevelMatchingRankType(rankType);
		return GetGameLevelFromGoldEarningBallance(heroCount, heroLvTarget);
	}
	
	
	public override int AppearLevelDefine()
	{
		var heroCount = questData.target;
		var gameLevel = GameLevelDefine();
		gameLevel -= heroCount * questData.target2 * 5;
		return gameLevel;
	}
}
