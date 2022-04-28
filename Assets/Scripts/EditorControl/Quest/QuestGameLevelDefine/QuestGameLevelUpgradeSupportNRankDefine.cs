using System;
using Sompom.Inventory;
using UnityEditor;

public class QuestGameLevelUpgradeSupportNRankDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var rankType = (RankType)questData.target;
		var upgradeLevelCount = Helper.GetSupportMinLevelMatchingRankType(rankType);
		var supportId = questData.supportId;
		if (supportId == 0)
		{
			supportId = 1;
		}
		var costUnlockSupportAndSkill = GetCostToUnlockSupportAndUpdateIncludeEvole(supportId, upgradeLevelCount, 1, 0);

		if (supportId >= 17)//fly support
		{
			var flySupportSkillData = EditorDatas.instance.GetSkillData(8);
			var costHeroUnlockFlySupportSkill = SMPHeroLevelConfiguration.GetCostOnLevel(5, 1,flySupportSkillData.Level_Unlock);
			var flyUnlockCount = supportId - 16;
			var costFlySupportSkillUpdate = SMPActiveSkillLevelConfiguration.GetNextCostConfiguration(flySupportSkillData, flyUnlockCount);
			var totalCost = costHeroUnlockFlySupportSkill + costFlySupportSkillUpdate;
			costUnlockSupportAndSkill += totalCost;
		}
		
		return GetGameLevelCanFarmForCost(costUnlockSupportAndSkill);
	}

	protected SMPNum GetCostToUnlockSupportAndUpdateIncludeEvole(int supportId, int upgradeLevelCount, int levelStart, int evolCounter)
	{
		var support = EditorDatas.instance.GetSupportData(supportId);
		if (support == null)
		{
			UnityEngine.Debug.Log("Out of support on id " + supportId);
			return new SMPNum(0);
		}

		support.m_iCurrentLevel = levelStart;
		var costUnlockSupport = new SMPNum(0);
		if (levelStart == 0)
		{
			support.m_bHired = false;
			support.m_SupportState = SupportStates.Hired;
			costUnlockSupport = SMPSupportLevelConfiguration.GetLevelConfiguration(support, 1).cost;
		}
		support.m_bHired = true;
		var targetSupportLevelReach = 998;
		SMPNum extraCost = new SMPNum(0);
		if (upgradeLevelCount < 998)
		{
			targetSupportLevelReach = upgradeLevelCount;
		}
		else
		{
			//cost for evolve
			for (int i = 0; i < support.m_SupportsAbilityList.Count - 1; i++)
			{
				support.m_SupportsAbilityList[i].m_bUnlocked = true;
			}

			support.m_evoledCounter = evolCounter;
			support.m_SupportState = SupportStates.UnlockedSkill;
			support.m_iCurrentLevel += 1000;
			extraCost = SMPSupportLevelConfiguration.GetLevelConfiguration(support, 1).cost;
			var upgradeNextCount = upgradeLevelCount - targetSupportLevelReach;
			extraCost += GetCostToUnlockSupportAndUpdateIncludeEvole(supportId + 1, upgradeNextCount, support.m_iCurrentLevel, support.m_evoledCounter+1);
		}

		SMPNum costSupportLevelReachUnlockSkill = SMPSupportLevelConfiguration.GetCostDependingOnNumOfLevelToAdd(levelStart,
				targetSupportLevelReach);

		return costUnlockSupport + costSupportLevelReachUnlockSkill + extraCost;
	}
}
