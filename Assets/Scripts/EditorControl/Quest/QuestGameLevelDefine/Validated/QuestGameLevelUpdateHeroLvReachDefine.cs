using System;
using Unity.VisualScripting.Dependencies.NCalc;

public class QuestGameLevelUpdateHeroLvReachDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var levelTarget = questData.target;
		var heroId = questData.heroId;
		var gameLvUnlockHero = 0;
		if (heroId != 0)
		{
			gameLvUnlockHero = GetGameLevelOnUnlockHero(heroId);
		}
		
		var gameLevelUpdateLevel = GetGameLevelFromGoldEarningBallance(1, levelTarget);
		return Math.Max(gameLevelUpdateLevel, gameLvUnlockHero);
	}

	public override int AppearLevelDefine()
	{
		return GameLevelDefine() - 2;
	}
}
