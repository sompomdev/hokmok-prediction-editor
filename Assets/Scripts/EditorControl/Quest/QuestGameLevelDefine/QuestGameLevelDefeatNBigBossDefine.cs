
public class QuestGameLevelDefeatNBigBossDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		return questData.target * SMPQuestTemplateConstance.MAX_LEVEL_ON_STAGE;
	}
}
