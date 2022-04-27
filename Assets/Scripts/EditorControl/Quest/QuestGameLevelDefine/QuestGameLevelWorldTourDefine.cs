
public class QuestGameLevelWorldTourDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var worldTourCount = questData.target;
		var gameLvCount = SMPQuestTemplateConstance.MAX_ZONE * SMPQuestTemplateConstance.MAX_LEVEL_ON_STAGE * (worldTourCount + 1);
		return gameLvCount;
	}

	public override int AppearLevelDefine()
	{
		var appearLv = GameLevelDefine() - (SMPQuestTemplateConstance.MAX_ZONE * SMPQuestTemplateConstance.MAX_LEVEL_ON_STAGE);
		if (appearLv <= 0) appearLv = 1;
		return appearLv;
	}
}
