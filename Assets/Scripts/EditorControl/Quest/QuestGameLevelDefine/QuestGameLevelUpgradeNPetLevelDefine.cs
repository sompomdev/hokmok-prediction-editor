using Sompom.Inventory;
using System;

public class QuestGameLevelUpgradeNPetLevelDefine : QuestGameLevelBaseDefine
{
	//"Update [n] pets!"

	public override int GameLevelDefine()
	{
		var updateNPet = questData.target;

		if(updateNPet == -1)
		{
			updateNPet = SMPQuestTemplateConstance.MAX_PET;
		}

		var gameLevel = GetGameLevelByDiamondForPetUpdate(updateNPet, 1);
		return gameLevel;
	}
}
