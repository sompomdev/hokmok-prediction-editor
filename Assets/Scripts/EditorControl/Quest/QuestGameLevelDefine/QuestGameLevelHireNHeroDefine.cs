using System;

public class QuestGameLevelHireNHeroDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var heroCount = questData.target;
		heroCount = Math.Min(heroCount-1, QuestConstance.MAX_HERO-1);//-1 is one hero unlock ready
		var gameLevelUnlockHero = (heroCount) * QuestConstance.UNLOCK_HERO_STAGE_COUNT;
		return gameLevelUnlockHero;
	}
}
