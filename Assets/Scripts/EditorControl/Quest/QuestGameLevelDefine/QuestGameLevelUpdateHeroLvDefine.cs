
public class QuestGameLevelUpdateHeroLvDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		return DefineForGoldEarningBallance();
	}

	private int DefineForGoldEarningBallance()
	{
		var levelTarget = questData.target;
		var gameLv = 0;
		var goldEarning = new SMPNum(0);
		var goldNeed = SMPHeroLevelConfiguration.GetCostOnLevel(5, levelTarget);
		do
		{
			gameLv++;
			goldEarning += EditorController.instance.GetGoldToDrop(gameLv) * QuestConstance.GHOST_PER_WAVE + 1;//ghost and boss gold drop
		}
		while (goldEarning < goldNeed);

		return gameLv;
	}

	private int DefineForDMGBallance()
	{
		var levelTarget = questData.target;
		var gameLv = 0;
		var dmgBalance = new SMPNum();
		var dmgTarget = EditorController.instance.GetHeroDmg(levelTarget);
		do
		{
			gameLv++;
			var hp = EditorController.instance.GetBossHp(gameLv);
			//var hp = EditorController.instance.GetGhostHp(gameLv);
			var tap = EditorController.instance.TapPerSec;
			dmgBalance = hp / (QuestConstance.TAP_PER_SECOND * tap);
		}
		while (dmgBalance < dmgTarget);

		return gameLv;
	}
}
