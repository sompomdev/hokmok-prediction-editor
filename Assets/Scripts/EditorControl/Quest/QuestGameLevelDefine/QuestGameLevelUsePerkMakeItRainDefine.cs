using System;

public class QuestGameLevelUsePerkMakeItRainDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var perkData = EditorDatas.instance.GetShopSkillData(0);
		var diamondNeed = int.Parse(perkData.m_Gems_Count);
		var lvDiamondFarm = GetGameLevelByDiamondBossDrop(diamondNeed);
		return lvDiamondFarm;
	}
}
