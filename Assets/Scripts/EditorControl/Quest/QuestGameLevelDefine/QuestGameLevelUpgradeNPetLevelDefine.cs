using Sompom.Inventory;
using System;

public class QuestGameLevelUpgradeNPetLevelDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var petCountTarget = questData.target;
		var petLevelTarget = questData.target2;

		var petUnlockTarget = questData.target;
		var gameLvDropEgg = GetGameLevelPetUnlock(petUnlockTarget);

		var petData = new SMPPetsData();
		petData.petCurrentLevel = 1;
		int cost = 0;
		do
		{
			cost += SMPPetLevelConfiguration.GetCostDependingOnNumOfLevelToAdd(petData) * petCountTarget;
			petData.petCurrentLevel++;
		}
		while (petData.petCurrentLevel < petLevelTarget);

		var gameLvToGetDiamond = GetGameLevelByDiamondBossDrop(cost);
		return Math.Max(gameLvDropEgg, gameLvToGetDiamond);
	}
}
