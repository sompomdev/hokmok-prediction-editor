using System;
using Sompom.Inventory;
using UnityEditor;
using UnityEngine;

public class QuestGameLevelUnlockSupportNEvolveDefine : QuestGameLevelBaseDefine
{
	//[support_name] evolve [n] times!
	public override int GameLevelDefine()
	{
		var evolveCounter = questData.target;
		var levelTarget = evolveCounter * SMPQuestTemplateConstance.PER_LEVEL_SUPPORT_EVOLVE;
		var supportId = questData.supportId;
		return GetGameLevelOnSupportUpgrateLevel(supportId, levelTarget);
	}
}
