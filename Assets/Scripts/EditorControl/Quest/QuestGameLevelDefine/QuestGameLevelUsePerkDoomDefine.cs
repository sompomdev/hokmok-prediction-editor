using System;

public class QuestGameLevelUsePerkDoomDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var perkData = EditorDatas.instance.GetShopSkillData(1);
		var diamondNeed = int.Parse(perkData.m_Gems_Count);
		var lvDiamondFarm = GetGameLevelByDiamondBossDrop(diamondNeed);
		return lvDiamondFarm;
	}
}
