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

	public override int AppearLevelDefine()
	{
		var gameLevel = GameLevelDefine();
		var updateTime = questData.target;
		
		var petData = new SMPPetsData();
		petData.petCurrentLevel = 0;//start update level from 0
		int diamondSpent = 0;
		do
		{
			petData.petCurrentLevel++;
			diamondSpent += SMPPetLevelConfiguration.GetCostDependingOnNumOfLevelToAdd(petData);
		}
		while (petData.petCurrentLevel < updateTime);

		var diamondGameLevel = GetGameLevelByDiamondFarmFromBossOnly(diamondSpent);

		//appear level that can collect diamond for update pet n time
		gameLevel -= diamondGameLevel;

		return gameLevel;
	}
}
