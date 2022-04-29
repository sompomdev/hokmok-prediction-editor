
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
		var heroCount = SMPQuestTemplateConstance.MAX_HERO;
		RankType rankType = (RankType)questData.target;
		var heroLvTarget = Helper.GetHeroMinLevelMatchingRankType(rankType);

		//appear before hero can reach target 100
		heroLvTarget -= 100;
		
		return GetGameLevelFromGoldEarningBallance(heroCount, heroLvTarget);
	}
}
