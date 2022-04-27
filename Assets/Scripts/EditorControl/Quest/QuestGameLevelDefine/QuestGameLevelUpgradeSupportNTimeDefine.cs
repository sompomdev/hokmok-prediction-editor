using System;
using Sompom.Inventory;

public class QuestGameLevelUpgradeSupportNTimeDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var upgradeLevelCount = questData.target;
		var costUnlockSupportAndSkill = GetCostToUnlockSupportAndUpdate(1, upgradeLevelCount + 1);//1 is unlock
		return GetGameLevelCanFarmForCost(costUnlockSupportAndSkill);
	}

	/// <summary>
	/// start support id 1
	/// not include evolve skill unlock
	/// move to next support if pass to evolve
	/// </summary>
	/// <param name="supportId"></param>
	/// <param name="targetUnlock"></param>
	/// <returns></returns>
	protected SMPNum GetCostToUnlockSupportAndUpdate(int supportId, int upgradeLevelCount)
	{
		var support = EditorDatas.instance.GetSupportData(supportId);
		if (support == null)
		{
			UnityEngine.Debug.Log("Out of support on id " + supportId);
			return new SMPNum(0);
		}

		support.m_bHired = false;
		var costUnlockSupport = SMPSupportLevelConfiguration.GetLevelConfiguration(support, 1).cost;
		support.m_bHired = true;
		var targetSupportLevelReach = 998;
		SMPNum costNextHero = new SMPNum(0);
		if (upgradeLevelCount < 998)
		{
			targetSupportLevelReach = upgradeLevelCount;
		}
		else
		{
			costNextHero = GetCostToUnlockSupportAndUpdate(supportId + 1, upgradeLevelCount - targetSupportLevelReach);
		}

		SMPNum costSupportLevelReachUnlockSkill = SMPSupportLevelConfiguration.GetCostDependingOnNumOfLevelToAdd(support.m_iCurrentLevel, targetSupportLevelReach);
		
		return costUnlockSupport + costSupportLevelReachUnlockSkill + costNextHero;
	}
}
