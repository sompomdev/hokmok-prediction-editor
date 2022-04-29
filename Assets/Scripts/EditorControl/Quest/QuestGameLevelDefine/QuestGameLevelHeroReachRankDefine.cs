
public class QuestGameLevelHeroReachRankDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		RankType rankType = (RankType)questData.target;
		var heroLvTarget = Helper.GetHeroMinLevelMatchingRankType(rankType);
		// now the hero id not impact the level update
		// var heroId = questData.heroId;
		return GetGameLevelFromGoldEarningBallance(1, heroLvTarget);
	}

	public override int AppearLevelDefine()
	{
		var lv = GameLevelDefine() - 50;
		if (lv <= 0) lv = 1;
		return lv;
	}
}
