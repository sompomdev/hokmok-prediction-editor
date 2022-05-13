
public class QuestGameLevelCompleteNQuestDefine : QuestGameLevelBaseDefine
{
	//collect video from bird
	private int gameLevelStart = 3;

	public override int GameLevelDefine()
	{
		var nQuest = questData.target;
		var gameLevel = nQuest * SMPQuestTemplateConstance.N_GAMELEVEL_PER_QUEST_COMPLETE;
		return gameLevelStart + gameLevel;
	}

	public override int AppearLevelDefine()
	{
		return gameLevelStart;
	}
}
