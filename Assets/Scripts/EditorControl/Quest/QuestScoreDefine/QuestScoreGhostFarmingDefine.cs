using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestScoreGhostFarmingDefine : QuestScoreBaseDefine
{
	private int killGhostCount = 10;

	public override SMPNum ScoreExspectAfterFinish()
	{
		var scoreToKillGhost = EditorController.instance.GetConvertScoreFromDMGToKillGhost(EditorController.instance.GetCurrentHeroDMG());
		return scoreToKillGhost;
	}
}
