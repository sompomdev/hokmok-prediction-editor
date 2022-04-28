using System;

public class QuestGameLevelUpdateHeroLvDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var updateTime = questData.target;
		var heroId = questData.heroId;
		var gameLvUnlockHero = 0;
		if (heroId != 0)
		{
			gameLvUnlockHero = GetGameLevelOnUnlockHero(heroId);
		}
		
		var gameLevelUpdateLevel = GetGameLevelFromGoldEarningBallance(1, updateTime+1);//coz +1 is have ready
		return Math.Max(gameLevelUpdateLevel, gameLvUnlockHero);
	}
}
