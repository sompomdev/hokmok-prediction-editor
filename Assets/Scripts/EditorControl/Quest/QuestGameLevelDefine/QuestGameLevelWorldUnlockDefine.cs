
public class QuestGameLevelWorldUnlockDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var zoneId = questData.target;
		var gameLevel = EditorDatas.instance.GetGameLevelByZone(zoneId);
		return gameLevel - SMPQuestTemplateConstance.STAGE_COUNTER_PRE_WORLD_REACH;
	}
}
