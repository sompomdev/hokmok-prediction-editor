using Sompom.Inventory;
using System;

public class QuestGameLevelUpdatePetLevelNTimeDefine : QuestGameLevelBaseDefine
{
	//"Update a pet!"

	public override int GameLevelDefine()
	{
		var updateTime = questData.target;
		var gameLevel = GetGameLevelByDiamondForPetUpdate(1, updateTime);
		return gameLevel;
	}
}
