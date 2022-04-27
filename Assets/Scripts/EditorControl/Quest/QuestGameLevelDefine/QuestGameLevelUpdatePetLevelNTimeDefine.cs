using Sompom.Inventory;
using System;

public class QuestGameLevelUpdatePetLevelNTimeDefine : QuestGameLevelBaseDefine
{
	//"Update a pet!"

	public override int GameLevelDefine()
	{
		var updateTime = questData.target;
		var gameLevelFromDiamond = GetGameLevelByDiamondForPetUpdate(1, updateTime);

		var petId = questData.petId;
		var gameLevelFromPetUnlock = 1;
		if(petId != 0)
		{
			gameLevelFromPetUnlock = GetGameLevelPetUnlock(SMPQuestTemplateConstance.MAX_PET/2);//50% to unlock this pet
		}
		return Math.Max(gameLevelFromDiamond, gameLevelFromPetUnlock);
	}
}
