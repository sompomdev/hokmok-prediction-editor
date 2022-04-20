using System;

public class QuestGameLevelUsePerkPowerOfHoldingDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var perkData = EditorDatas.instance.GetShopSkillData(2);
		var diamondNeed = int.Parse(perkData.m_Gems_Count);
		var lvDiamondFarm = GetGameLevelByDiamondBossDrop(diamondNeed);
		return lvDiamondFarm;
	}
}
