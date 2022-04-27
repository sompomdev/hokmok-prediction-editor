using Sompom.Inventory;
using System;

public class QuestGameLevelUpgradeNPetLvNTimeDefine : QuestGameLevelBaseDefine
{
	//"Update a pet [n] times!"

	public override int GameLevelDefine()
	{
		var updateNPet = questData.target;
		var updateTime = questData.target2;

		var gameLevel = GetGameLevelByDiamondForPetUpdate(updateNPet, updateTime);
		return gameLevel;
	}
}
