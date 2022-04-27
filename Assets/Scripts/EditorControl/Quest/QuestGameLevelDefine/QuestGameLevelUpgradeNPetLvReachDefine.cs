using Sompom.Inventory;
using System;

public class QuestGameLevelUpgradeNPetLvReachDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var petCountTarget = questData.target;
		var petLevelTarget = questData.target2;

		if (petCountTarget == -1)
		{
			petCountTarget = SMPQuestTemplateConstance.MAX_PET;
		}

		var gameLevel = GetGameLevelByDiamondForPetUpdate(petCountTarget, petLevelTarget - 1);// -1 is the level reach ready
		return gameLevel;
	}
}
