
public class QuestGameLevelNHeroReachRankDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var heroCount = questData.target;
		if (heroCount == -1)
		{
			heroCount = SMPQuestTemplateConstance.MAX_HERO;
		}

		RankType rankType = (RankType)questData.target2;
		var heroLvTarget = Helper.GetHeroMinLevelMatchingRankType(rankType);
		return GetGameLevelFromGoldEarningBallance(heroCount, heroLvTarget);
	}
}
