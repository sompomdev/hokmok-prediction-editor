using System;

public class QuestGameLevelUsePerkDoomDefine : QuestGameLevelBaseDefine
{
	private int appearLevel = 200;
	public override int GameLevelDefine()
	{
		var perkCount = questData.target;
		var perkData = EditorDatas.instance.GetShopSkillData(1);
		var diamondNeed = int.Parse(perkData.m_Gems_Count) * perkCount;
		var lvDiamondFarm = GetGameLevelByDiamondBossDrop(diamondNeed);
		return Math.Max(lvDiamondFarm, appearLevel);
	}
	
	public override int AppearLevelDefine()
	{
		var perkCount = questData.target;
		var gameLevel = GameLevelDefine();
		if (perkCount > 1)
		{
			gameLevel -= appearLevel;
		}
		return gameLevel;
	}
}
