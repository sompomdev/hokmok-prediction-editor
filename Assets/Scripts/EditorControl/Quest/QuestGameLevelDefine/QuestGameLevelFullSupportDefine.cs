using System;
using Sompom.Inventory;

public class QuestGameLevelFullSupportDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var costUnlockSupport = GetCostAllSupportUnlock();
		var flySupportSkillData = EditorDatas.instance.GetSkillData(8);
		var costHeroUnlockFlySupportSkill = SMPHeroLevelConfiguration.GetCostOnLevel(5, 1,flySupportSkillData.Level_Unlock);
		var flyUnlockCount = QuestConstance.MAX_FLYING_SUPPORT;
		var costFlySupportSkill = SMPActiveSkillLevelConfiguration.GetNextCostConfiguration(flySupportSkillData, flyUnlockCount);
		var totalCost = costUnlockSupport + costHeroUnlockFlySupportSkill + costFlySupportSkill;
		return GetGameLevelCanFarmForCost(totalCost);
	}

	protected SMPNum GetCostAllSupportUnlock()
	{
		var cost = new SMPNum(0);
		var supportNeedUnlock = QuestConstance.MAX_SUPPORT - QuestConstance.MAX_FLYING_SUPPORT;
		for(int i=1;i<=supportNeedUnlock;i++)
		{
			var supportData = EditorDatas.instance.GetSupportData(i);
			cost += SMPSupportLevelConfiguration.GetLevelConfiguration(supportData, 1).cost;
		}
		return cost;
	}
}
