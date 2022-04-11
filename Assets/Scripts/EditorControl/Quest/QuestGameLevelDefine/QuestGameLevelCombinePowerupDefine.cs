
public class QuestGameLevelCombinePowerupDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var targetCombine = questData.target;
		var costSkill = new SMPNum(0);
		var heroLvTarget = QuestConstance.HeroLevelSkillUnlock(targetCombine);
		for(int i=0;i<targetCombine;i++)
		{
			costSkill += QuestConstance.HeroSkillCostUnlock(i);
		}
		
		return GetGameLevelHeroCanReachLevel(heroLvTarget, costSkill);
	}

	private int GetGameLevelHeroCanReachLevel(int heroLv, SMPNum skillCosts)
	{
		var gameLv = 0;
		var goldEarning = new SMPNum(0);
		var goldNeed = SMPHeroLevelConfiguration.GetCostOnLevel(5, heroLv) + skillCosts;
		do
		{
			gameLv++;
			goldEarning += EditorController.instance.GetGoldToDrop(gameLv) * QuestConstance.GHOST_PER_WAVE + 1;//ghost and boss gold drop
		}
		while (goldEarning < goldNeed);

		return gameLv;
	}
}
