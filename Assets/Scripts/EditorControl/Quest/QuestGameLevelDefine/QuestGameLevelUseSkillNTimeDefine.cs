
public class QuestGameLevelUseSkillNTimeDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var skillTargetId = questData.powerUpType;
		var skillData = EditorDatas.instance.GetSkillData(skillTargetId);
		var skillCost = SMPActiveSkillLevelConfiguration.GetNextCostConfiguration(skillData, 1);
		var gameLevelUnlockSkill = GetGameLevelHeroCanReachLevel(skillData.Level_Unlock, skillCost);

		var useTime = questData.target2;
		var manaConsume = SMPActiveSkillLevelConfiguration.GetNextManaConsumtion(skillData, 1);
		var manaFarmingPerminute = SMPManaLevelConfiguration.GetManaPerMinutes();
		var manaNeed = manaConsume * useTime;
		var totalTimeMana = manaNeed / (manaFarmingPerminute / 60);
		var gameLevelOnFarmingMana = GetGameLevelCanReachBaseOnTime(totalTimeMana);

		//UnityEngine.Debug.Log($"manaConsume {manaConsume.ToString()} manaNeed {manaNeed} manaPerMinute {manaFarmingPerminute} totalTimeMana {totalTimeMana} gameLevelFarm {gameLevelOnFarmingMana}");

		return gameLevelUnlockSkill;// + gameLevelOnFarmingMana;
	}
}
