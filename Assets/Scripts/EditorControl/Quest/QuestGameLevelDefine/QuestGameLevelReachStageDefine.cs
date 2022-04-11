
public class QuestGameLevelReachStageDefine : QuestGameLevelBaseDefine
{
	private int preStageCounter = 1;

	public override int GameLevelDefine()
	{
		return questData.target - preStageCounter;
	}
}
