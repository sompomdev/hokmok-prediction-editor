
public class QuestGameLevelUpgradeAllHeroReachRankDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var heroCount = SMPQuestTemplateConstance.MAX_HERO;
		RankType rankType = (RankType)questData.target;
		var heroLvTarget = Helper.GetHeroMinLevelMatchingRankType(rankType);
		return GetGameLevelFromGoldEarningBallance(heroCount, heroLvTarget);
	}
	
	
	public override int AppearLevelDefine()
	{
		var lv = GameLevelDefine() - 200;
		if (lv <= 0) lv = 1;
		return lv;
	}
}
