using Sompom.Inventory;
using System;

public class QuestGameLevelUpgradeNPetLvNTimeDefine : QuestGameLevelBaseDefine
{
	//"Update a pet [n] times!"

	public override int GameLevelDefine()
	{
		var updateNPet = questData.target;
		var updateTime = questData.target2;

		if(updateNPet == -1)
		{
			updateNPet = SMPQuestTemplateConstance.MAX_PET;
		}

		var gameLevel = GetGameLevelByDiamondForPetUpdate(updateNPet, updateTime);
		return gameLevel;
	}
}
