using Sompom.Inventory;
using System;

public class QuestGameLevelUpdateAPetLevelNTimeDefine : QuestGameLevelBaseDefine
{
	//"Update a pet!"
	//Update a pet \[n\] times!

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

		var gameLevel = Math.Max(gameLevelFromDiamond, gameLevelFromPetUnlock);
		
		//to increase to avoid appear the same on a pet
		if (updateTime > 1)
		{
			gameLevel += updateTime * 5;
		}

		return gameLevel;
	}

	public override int AppearLevelDefine()
	{
		var gameLevel = GameLevelDefine();
		return gameLevel;
	}
}
