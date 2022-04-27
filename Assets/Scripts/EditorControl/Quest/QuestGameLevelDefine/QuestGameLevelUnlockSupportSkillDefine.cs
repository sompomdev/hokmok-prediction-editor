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
			SMPNum cost = new SMPNum(0);
			if (support.m_SupportsAbilityList[totalUnlockSkills].m_skillType == SupportSkillType.EVOLVE)// && !support.m_evolved)
			{
				//cost = new SMPNum((support.m_sCostBase * Math.Round(Math.Pow(1.075, support.m_iCurrentLevel - 1))) * 10.75);
				break;
			}
			else
			{
				SMPNum costOnLevel = SMPSupportLevelConfiguration.GetCostUnlockSkill(support.m_sCostBase, support.m_SupportsAbilityList[totalUnlockSkills].m_iCurrentLevel);
				if (support.m_evolved)
				{
					//cost after evolved
					cost = costOnLevel * (9 + support.m_evoledCounter);//start in 10
				}
				else
				{
					cost = costOnLevel * 5;
				}
			}
			costSkillSupport += cost;
			totalUnlockSkills++;
		}
		while (totalUnlockSkills < unlockTarget);

		var targetSupportLevelReach = support.m_SupportsAbilityList[totalUnlockSkills - 1].m_iCurrentLevel;
		SMPNum costSupportLevelReachUnlockSkill = SMPSupportLevelConfiguration.GetCostDependingOnNumOfLevelToAdd(support.m_iCurrentLevel, targetSupportLevelReach);
		
		SMPNum costNextHero = new SMPNum(0);
		if(totalUnlockSkills < unlockTarget)
		{
			costNextHero = GetCostToUnlockSupportAndSkill(supportId + 1, unlockTarget - totalUnlockSkills);
		}

		return costUnlockSupport + costSkillSupport + costSupportLevelReachUnlockSkill + costNextHero;
	}
}
