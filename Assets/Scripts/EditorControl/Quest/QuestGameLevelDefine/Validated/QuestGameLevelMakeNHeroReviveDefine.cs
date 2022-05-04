using System;

public class QuestGameLevelMakeNHeroReviveDefine : QuestGameLevelBaseDefine
{
	private int gameLevelStart = 25;
	public override int GameLevelDefine()
	{
		var heroCount = questData.target;
		
		heroCount = Math.Min(heroCount-1, SMPQuestTemplateConstance.MAX_HERO-1);//-1 is one hero unlock ready
		var gameLevelUnlockHero = (heroCount) * SMPQuestTemplateConstance.UNLOCK_HERO_STAGE_COUNT;

		var costPerRevive = SMPHeroLevelConfiguration.GetReviveCost(1);
		var gameLevel = gameLevelStart + heroCount * GetGameLevelByDiamondBossDrop(costPerRevive);
		
		return Math.Max(gameLevel, gameLevelUnlockHero);
	}

	public override int AppearLevelDefine()
	{
		var gameLevel = GameLevelDefine();
		
		//add 1 level before appear
		gameLevel -= 1;
		
		return gameLevel;
	}
}
