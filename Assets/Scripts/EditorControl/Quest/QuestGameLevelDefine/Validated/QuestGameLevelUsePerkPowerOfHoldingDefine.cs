using System;

public class QuestGameLevelUsePerkPowerOfHoldingDefine : QuestGameLevelBaseDefine
{
	private int gameLevelAppear = 50;
	public override int GameLevelDefine()
	{
		var perkCount = questData.target;
		var perkData = EditorDatas.instance.GetShopSkillData(2);
		var diamondNeed = int.Parse(perkData.m_Gems_Count) * perkCount;
		var lvDiamondFarm = GetGameLevelByDiamondBossDrop(diamondNeed);
		
		return Math.Max(lvDiamondFarm, gameLevelAppear);
	}
	
	public override int AppearLevelDefine()
	{
		return gameLevelAppear;
	}
}
