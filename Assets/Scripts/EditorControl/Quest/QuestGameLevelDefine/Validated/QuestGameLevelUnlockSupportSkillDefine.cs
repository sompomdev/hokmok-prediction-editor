using System;
using Sompom.Inventory;

public class QuestGameLevelUnlockSupportSkillDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var targetUnlock = questData.target;
		var costUnlockSupportAndSkill = GetCostToUnlockSupportAndSkill(1, targetUnlock);
		return GetGameLevelCanFarmForCost(costUnlockSupportAndSkill);
	}
	
	public override int AppearLevelDefine()
	{
		return GameLevelDefine() - 5;
	}
	
	
	protected int GetLevelSupportUnlock(int supportId, int unlockTarget)
	{
		var support = EditorDatas.instance.GetSupportData(supportId);
		if (support == null)
		{
			UnityEngine.Debug.Log("Out of support on id " + supportId);
			return 0;
		}

		support.m_bHired = false;
		support.m_bHired = true;
		int totalUnlockSkills = 0;
		do
		{
			if(totalUnlockSkills>=support.m_SupportsAbilityList.Count) break;
			totalUnlockSkills++;
		}
		while (totalUnlockSkills < unlockTarget);

		var targetSupportLevelReach = support.m_SupportsAbilityList[totalUnlockSkills].m_iCurrentLevel;
		return targetSupportLevelReach;
	}

	/// <summary>
	/// start support id 1
	/// not include evolve skill unlock
	/// move to next support if pass to evolve
	/// </summary>
	/// <param name="supportId"></param>
	/// <param name="targetUnlock"></param>
	/// <returns></returns>
	protected SMPNum GetCostToUnlockSupportAndSkill(int supportId, int unlockTarget)
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
		var costSkillSupport = new SMPNum(0);
		int totalUnlockSkills = 0;
		do
		{
			if (totalUnlockSkills >= support.m_SupportsAbilityList.Count)
			{
				totalUnlockSkills--;
				break;
			}
			
			SMPNum cost = new SMPNum(0);
			support.m_SupportState = SupportStates.UnlockedSkill;
			//cost on unlock skill
			cost += SMPSupportLevelConfiguration.GetLevelConfiguration(support, 1).cost;
			support.m_SupportsAbilityList[totalUnlockSkills].m_bUnlocked = true;
			
			costSkillSupport += cost;
			totalUnlockSkills++;
		}
		while (totalUnlockSkills < unlockTarget);

		var targetSupportLevelReach = support.m_SupportsAbilityList[totalUnlockSkills].m_iCurrentLevel;
		support.m_SupportState = SupportStates.LevelUp;
		support.m_iCurrentLevel = 1;
		SMPNum costSupportLevelReachUnlockSkill = SMPSupportLevelConfiguration.GetCostDependingOnNumOfLevelToAdd(1, targetSupportLevelReach);
		
		SMPNum costNextHero = new SMPNum(0);
		if(totalUnlockSkills < unlockTarget)
		{
			costNextHero = GetCostToUnlockSupportAndSkill(supportId + 1, unlockTarget - totalUnlockSkills);
		}

		return costUnlockSupport + costSkillSupport + costSupportLevelReachUnlockSkill + costNextHero;
	}
}
