using System;

public class QuestGameLevelReduceGhostRoundDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var totalReduce = questData.target;
		//our rule total reduce equal to total passive skill level (id 9 plov kat)
		var gameLevelUnlockLevelTarget = SMPPassiveSkillLevelConfiguration.GetStageForUnlockNextLevel(0, totalReduce);

		var skillData = EditorDatas.instance.GetPassiveSkillData(9);
		var costSkill = SMPActiveSkillLevelConfiguration.GetNextCostConfiguration(skillData, totalReduce);
		var gameLevelGoldFarm = GetGameLevelCanFarmForCost(costSkill);

		var gameLevelMax = Math.Max(gameLevelUnlockLevelTarget, gameLevelGoldFarm);

		return gameLevelMax - QuestConstance.STAGE_COUNTER_PRE_REACH;
	}
}
