
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

	public override int AppearLevelDefine()
	{
		var lv = GameLevelDefine() - 200;
		if (lv <= 0) lv = 1;
		return lv;
	}
}
