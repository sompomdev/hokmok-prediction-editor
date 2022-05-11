using System;

public class QuestGameLevelUsePerkMakeItRainDefine : QuestGameLevelBaseDefine
{
	private int appearLevel = 150;
	public override int GameLevelDefine()
	{
		var perkCount = questData.target;
		var perkData = EditorDatas.instance.GetShopSkillData(0);
		var diamondNeed = int.Parse(perkData.m_Gems_Count) * perkCount;
		var lvDiamondFarm = GetGameLevelByDiamondBossDrop(diamondNeed);
		return Math.Max(lvDiamondFarm, appearLevel);
	}

	public override int AppearLevelDefine()
	{
		return GameLevelDefine();
	}
}
