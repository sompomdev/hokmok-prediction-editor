using System;

public class QuestGameLevelHireFullHeroDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var gameLevelUnlockHero = (QuestConstance.MAX_HERO - 1) * QuestConstance.UNLOCK_HERO_STAGE_COUNT;//-1 is one hero unlock ready
		return gameLevelUnlockHero;
	}
}
