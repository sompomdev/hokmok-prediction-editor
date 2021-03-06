using System;

public class QuestGameLevelUpgradeNHeroToLvDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var heroTargetCount = questData.target;
		if (heroTargetCount == -1)
		{
			heroTargetCount = SMPQuestTemplateConstance.MAX_HERO;
		}
		var heroLevelTarget = questData.target2;
		var gameLevelCanUpdateHeroLevel = GetGameLevelFromGoldEarningBallance(heroTargetCount, heroLevelTarget);
		var gameLevelUnlockHero = (heroTargetCount - 1) * SMPQuestTemplateConstance.UNLOCK_HERO_STAGE_COUNT;//-1 is one hero unlock ready

		return Math.Max(gameLevelUnlockHero, gameLevelCanUpdateHeroLevel);
	}

	public override int AppearLevelDefine()
	{
		var heroTargetCount = questData.target;
		if (heroTargetCount == -1)
		{
			heroTargetCount = SMPQuestTemplateConstance.MAX_HERO;
		}
		
		var gameLevelUnlockHero = (heroTargetCount - 1) * SMPQuestTemplateConstance.UNLOCK_HERO_STAGE_COUNT;//-1 is one hero unlock ready
		
		return gameLevelUnlockHero;
	}
}
