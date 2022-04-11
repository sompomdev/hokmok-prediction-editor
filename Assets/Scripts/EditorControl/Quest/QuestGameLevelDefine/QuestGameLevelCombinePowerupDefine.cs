
public class QuestGameLevelCombinePowerupDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var targetCombine = questData.target;
		var costSkill = new SMPNum(0);
		var heroLvTarget = HeroLevelSkillUnlock(targetCombine);
		for(int i=0;i<targetCombine;i++)
		{
			costSkill += HeroSkillCostUnlock(i);
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

	private int HeroLevelSkillUnlock(int skillId)
	{
		switch(skillId)
		{
			case 0:
				return 50;

			case 1:
				return 100;

			case 2:
				return 200;

			case 3:
				return 300;

			case 4:
				return 400;

			case 5:
				return 500;

			case 6:
				return 510;

			case 7:
				return 520;

			case 8:
				return 530;

			case 10:
				return 30;
		}

		return 0;
	}

	private SMPNum HeroSkillCostUnlock(int skillId)
	{
		switch (skillId)
		{
			case 0:
				return new SMPNum(1) * 2790;

			case 1:
				return new SMPNum(1) * 103730;

			case 2:
				return new SMPNum(1) * 143470000;

			case 3:
				return new SMPNum(1) * 1750;

			case 4:
				return new SMPNum(1) * 1750;

			case 5:
				return new SMPNum(1) * 1750;

			case 6:
				return new SMPNum(1) * 1750;

			case 7:
				return new SMPNum(1) * 1750;

			case 8:
				return new SMPNum(1) * 1750;

			case 10:
				return new SMPNum(1) * 1750;
		}

		return new SMPNum(0);
	}
}
