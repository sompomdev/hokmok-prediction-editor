using UnityEngine;

public class QuestGameLevelMakeNComboHitBossTypeDefine : QuestGameLevelBaseDefine
{
	private int gameLevelStart = 3;
	public override int GameLevelDefine()
	{
		var nTime = questData.target;
		var kpiAppear = AppearLevelDefine();
		
		var gameLevel = kpiAppear + Mathf.CeilToInt(nTime / 9f) - 1;//1 level can combo hit 9 times or 9 runes collect and -1 is can start count
		
		var bossType = questData.bossType;
		if (bossType == 2)
		{
			var levelZoneBoss = SMPQuestTemplateConstance.MAX_LEVEL_ON_STAGE;
			gameLevel = gameLevel + (levelZoneBoss - (gameLevel % levelZoneBoss));//for level Boss Revenge only not Boss Battle
			gameLevel -= 1;//for appear on big boss
		}
		else if (bossType == 1)
		{
			gameLevel = gameLevel - (gameLevel % 2) + 1;//for level Boss Battle only not Boss Revenge
		}
		else
		{
			gameLevel = gameLevel - (gameLevel % 2);//for level Boss Revenge only not Boss Battle
		}
		
		return gameLevel;
	}

	public override int AppearLevelDefine()
	{
		//0 => Revenge
		//1 => Boss, Big boss
		//2 => Zone Boss
		
		var bossType = questData.bossType;
		var kpiAppear = 1;
		
		if (bossType == 2)
		{
			kpiAppear = 9;//start gameLevel
		}
		else if (bossType == 1)
		{
			kpiAppear = 3;//start gameLevel
		}
		else
		{
			kpiAppear = 4;//start gameLevel
		}

		return kpiAppear;
	}
}
