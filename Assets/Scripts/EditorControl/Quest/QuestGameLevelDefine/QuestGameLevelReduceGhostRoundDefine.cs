
public class QuestGameLevelReduceGhostRoundDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var totalReduce = questData.target;
		//our rule total reduce equal to total passive skill level (id 9 plov kat)
		var stageUnlockAndUpdateLevel = SMPPassiveSkillLevelConfiguration.GetStageForUnlockNextLevel(0, totalReduce);

		return stageUnlockAndUpdateLevel - QuestConstance.STAGE_COUNTER_PRE_REACH;
	}
}
