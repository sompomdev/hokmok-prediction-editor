using System;

public class QuestGameLevelHireFullHeroDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var gameLevelUnlockHero = (SMPQuestTemplateConstance.MAX_HERO - 1) * SMPQuestTemplateConstance.UNLOCK_HERO_STAGE_COUNT;//-1 is one hero unlock ready
		return gameLevelUnlockHero;
	}
	public override int AppearLevelDefine()
	{
		return 10;
	}
}
