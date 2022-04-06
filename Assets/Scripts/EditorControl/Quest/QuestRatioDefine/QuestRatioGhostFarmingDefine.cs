using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestRatioGhostFarmingDefine : QuestRatioBaseDefine
{
	private int killGhostCount = 10;

	public override SMPNum RatioNeeded()
	{
		var scoreToKillGhost = EditorController.instance.GetConvertScoreFromDMGToKillGhost(EditorController.instance.GetCurrentHeroDMG());
		return scoreToKillGhost;
	}
}
