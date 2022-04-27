
public class QuestGameLevelWorldNameDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var worldId = questData.target;
		var gameLvCount = SMPQuestTemplateConstance.MAX_LEVEL_ON_STAGE * (worldId - 1);
		return gameLvCount;
	}
}
