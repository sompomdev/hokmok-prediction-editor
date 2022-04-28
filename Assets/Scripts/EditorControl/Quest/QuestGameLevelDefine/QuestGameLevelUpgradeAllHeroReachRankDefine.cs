
public class QuestGameLevelUpgradeAllHeroReachRankDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var heroCount = SMPQuestTemplateConstance.MAX_HERO;
		RankType rankType = (RankType)questData.target;
		var heroLvTarget = Helper.GetHeroMinLevelMatchingRankType(rankType);
		return GetGameLevelFromGoldEarningBallance(heroCount, heroLvTarget);
	}
}
