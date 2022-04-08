
public class DifficultyScoreGoldFarmDefine : DifficultyScoreBaseDefine
{
	public override SMPNum GetScoreOnDMG(SMPNum dmg)
	{
		return (GetScoreOnDMGKillGhost(dmg) + GetScoreOnDMGKillBoss(dmg)) / 2;
	}

	public override SMPNum GetScoreOnDMGKillGhost(SMPNum dmg)
	{
		var scoreDMG = EditorController.instance.GetConvertScoreFromDMGToKillGhost(dmg);

		var gameLv = EditorController.instance.GameLv;
		var hp = EditorController.instance.GetGhostHp(gameLv);
		var tap = EditorController.instance.TapPerSec;
		var dmgBalance = hp / (4 * tap);//4 is the ballance second to kill ghost and 100 is the ballance score

		var dmgNeedToBallance = dmgBalance - dmg;
		SMPNum goldNeed = new SMPNum(0);
		int heroLv = EditorController.instance.HeroLv;
		int lvAdd = 1;
		SMPNum dmgUp = SMPHeroLevelConfiguration.GetNextDamageFromLevelToLevel(1, heroLv, lvAdd, dmg);
		while(dmgUp < dmgBalance)
		{
			lvAdd++;
			dmgUp = SMPHeroLevelConfiguration.GetNextDamageFromLevelToLevel(1, heroLv, lvAdd, dmg);
		}
		var costPaid = SMPHeroLevelConfiguration.GetCostOnLevel(5, heroLv, lvAdd);
		if (costPaid < 0.01)
		{
			costPaid = new SMPNum(0.01);
		}
		var goldStock = EditorController.instance.currentGold;
		if (goldStock < 0.01)
		{
			goldStock = new SMPNum(0.01);
		}

		return (costPaid/goldStock) * GamePlayDifficultyScore.SCORE_RATIO;
	}

	public override SMPNum GetScoreOnDMGKillBoss(SMPNum dmg)
	{
		var scoreDMG = EditorController.instance.GetConvertScoreFromDMGToKillBoss(dmg);

		var gameLv = EditorController.instance.GameLv;
		var hp = EditorController.instance.GetBossHp(gameLv);
		var tap = EditorController.instance.TapPerSec;
		var dmgBalance = hp / (4 * tap);//4 is the ballance second to kill ghost and 100 is the ballance score

		var dmgNeedToBallance = dmgBalance - dmg;
		SMPNum goldNeed = new SMPNum(0);
		int heroLv = EditorController.instance.HeroLv;
		int lvAdd = 1;
		SMPNum dmgUp = SMPHeroLevelConfiguration.GetNextDamageFromLevelToLevel(1, heroLv, lvAdd, dmg);
		while (dmgUp < dmgBalance)
		{
			lvAdd++;
			dmgUp = SMPHeroLevelConfiguration.GetNextDamageFromLevelToLevel(1, heroLv, lvAdd, dmg);
		}
		var costPaid = SMPHeroLevelConfiguration.GetCostOnLevel(5, heroLv, lvAdd);
		if(costPaid<0.01)
		{
			costPaid = new SMPNum(0.01);
		}
		var goldStock = EditorController.instance.currentGold;
		if (goldStock < 0.01)
		{
			goldStock = new SMPNum(0.01);
		}

		return (costPaid / goldStock) * GamePlayDifficultyScore.SCORE_RATIO;
	}

}
