using System;

public class QuestGameLevelUsePerkDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var perkId = questData.target;
		var manaPerk = EditorDatas.instance.GetShopSkillData(perkId);
		var diamondNeed = int.Parse(manaPerk.m_Gems_Count);
		var lvDiamondFarm = GetGameLevelByDiamondBossDrop(diamondNeed);
		return lvDiamondFarm;
	}
}
