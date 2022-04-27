using Sompom.Inventory;
using System;

public class QuestGameLevelUpdatePetLevelNTimeDefine : QuestGameLevelBaseDefine
{
	//"Update a pet!"

	public override int GameLevelDefine()
	{
		var updateTime = questData.target;

		var gameLvDropEgg = GetGameLevelPetUnlock(1);

		var petData = new SMPPetsData();
		petData.petCurrentLevel = 0;//start update level from 0
		int cost = 0;
		do
		{
			petData.petCurrentLevel++;
			cost += SMPPetLevelConfiguration.GetCostDependingOnNumOfLevelToAdd(petData);
		}
		while (petData.petCurrentLevel < updateTime);

		var gameLvToGetDiamond = GetGameLevelByDiamondBossDrop(cost);
		return Math.Max(gameLvDropEgg, gameLvToGetDiamond);
	}
}
