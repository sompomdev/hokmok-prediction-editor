using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestScoreGhostFarmingDefine : QuestScoreBaseDefine
{
	private int killGhostCount = 10;

	public override SMPNum ScoreExspectAfterFinish()
	{
		var dmg = EditorController.instance.GetCurrentHeroDMG();
		return EditorController.instance.GetConvertScoreFromDMGToKillGhost(dmg);
	}
}
