
public abstract class QuestRatioBaseDefine
{
	//Test the score in 60s
	public abstract SMPNum RatioNeeded();//how many percentage we need this quest?//how many useful to complete this quest?

	//Battle score that farmed in 60s
	public virtual SMPNum RatioPassRequire()
	{
		return EditorController.instance.GetBattleScoreDefault();
	}

	public virtual SMPNum ScoreProfit()
	{
		return RatioNeeded() - RatioPassRequire();
	}
}
