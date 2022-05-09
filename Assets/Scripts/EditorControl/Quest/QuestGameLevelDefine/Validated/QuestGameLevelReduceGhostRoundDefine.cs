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

		return gameLevelMax;
	}

	public override int AppearLevelDefine()
	{
		var gameLevel = GameLevelDefine();
		
		//add 5 game level before appear
		gameLevel -= 5;

		return gameLevel;
	}
}
