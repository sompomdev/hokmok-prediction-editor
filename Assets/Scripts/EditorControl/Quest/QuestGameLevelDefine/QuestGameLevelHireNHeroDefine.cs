using System;

public class QuestGameLevelHireNHeroDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var heroCount = questData.target;
		heroCount = Math.Min(heroCount-1, SMPQuestTemplateConstance.MAX_HERO-1);//-1 is one hero unlock ready
		var gameLevelUnlockHero = (heroCount) * SMPQuestTemplateConstance.UNLOCK_HERO_STAGE_COUNT;
		return gameLevelUnlockHero;
	}

	public override int AppearLevelDefine()
	{
		return GameLevelDefine();
	}
}
