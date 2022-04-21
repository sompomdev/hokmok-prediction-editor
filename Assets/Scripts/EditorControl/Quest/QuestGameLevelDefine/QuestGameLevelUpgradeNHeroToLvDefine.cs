using System;

public class QuestGameLevelUpgradeNHeroToLvDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var heroTargetCount = questData.target;
		var heroLevelTarget = questData.target2;
		var gameLevelCanUpdateHeroLevel = GetGameLevelFromGoldEarningBallance(heroTargetCount, heroLevelTarget);
		var gameLevelUnlockHero = (heroTargetCount - 1) * SMPQuestTemplateConstance.UNLOCK_HERO_STAGE_COUNT;//-1 is one hero unlock ready

		return Math.Max(gameLevelUnlockHero, gameLevelCanUpdateHeroLevel);
	}
}
