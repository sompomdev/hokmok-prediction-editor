
public abstract class DifficultyScoreBaseDefine
{
	public abstract SMPNum GetScoreOnDMG(SMPNum dmg);

	public virtual SMPNum GetScoreOnDMGKillGhost(SMPNum dmg)
	{
		return null;
	}

	public virtual SMPNum GetScoreOnDMGKillBoss(SMPNum dmg)
	{
		return null;
	}
}
