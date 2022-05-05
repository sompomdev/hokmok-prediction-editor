
public class QuestGameLevelCompleteYourNMissionDefine : QuestGameLevelBaseDefine
{
	//Complete your first mission!
	//Complete your 10 mission!

	public override int GameLevelDefine()
	{
		return questData.target * SMPQuestTemplateConstance.MAX_LEVEL_ON_STAGE;
	}

	public override int AppearLevelDefine()
	{
		return GameLevelDefine() - 9;
	}
}
