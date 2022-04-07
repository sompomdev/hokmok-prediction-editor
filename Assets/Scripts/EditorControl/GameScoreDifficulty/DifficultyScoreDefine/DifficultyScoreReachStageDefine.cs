
public class DifficultyScoreReachStageDefine : DifficultyScoreBaseDefine
{
	public SMPNum GetScoreOnDMG(SMPNum dmg)
	{
		return (GetScoreOnDMGKillGhost(dmg) + GetScoreOnDMGKillBoss(dmg)) / 2;
	}

	public SMPNum GetScoreOnDMGKillGhost(SMPNum dmg)
	{
		var scoreDMG = EditorController.instance.GetConvertScoreFromDMGToKillGhost(dmg);

		var gameLv = EditorController.instance.GameLv;
		var hp = EditorController.instance.GetGhostHp(gameLv);
		var tap = EditorController.instance.TapPerSec;
		var dmgBalance = hp / (4 * tap);//4 is the ballance second to kill ghost and 100 is the ballance score
		var scoreBallance = EditorController.instance.GetConvertScoreFromDMGToKillGhost(dmgBalance);

		return (scoreDMG / scoreBallance) * GamePlayDifficultyScore.SCORE_RATIO;
	}

	public SMPNum GetScoreOnDMGKillBoss(SMPNum dmg)
	{
		var scoreDMG = EditorController.instance.GetConvertScoreFromDMGToKillBoss(dmg);

		var gameLv = EditorController.instance.GameLv;
		var hp = EditorController.instance.GetBossHp(gameLv);
		var tap = EditorController.instance.TapPerSec;
		var dmgBalance = hp / (4 * tap);//4 is the ballance second to kill ghost and 100 is the ballance score
		var scoreBallance = EditorController.instance.GetConvertScoreFromDMGToKillBoss(dmgBalance);

		return (scoreDMG / scoreBallance) * GamePlayDifficultyScore.SCORE_RATIO;
	}
}
