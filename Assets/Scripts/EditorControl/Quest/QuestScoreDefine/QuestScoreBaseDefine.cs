
public abstract class QuestScoreBaseDefine
{
	//Test the score in 60s
	public abstract SMPNum ScoreExspectAfterFinish();//how many useful to complete this quest?

	//Battle score that farmed in 60s
	public virtual SMPNum ScoreInBattleCurrently()
	{
		return EditorController.instance.GetBattleScoreDefault();
	}

	public virtual SMPNum ScoreProfit()
	{
		return ScoreExspectAfterFinish() - ScoreInBattleCurrently();
	}
}
