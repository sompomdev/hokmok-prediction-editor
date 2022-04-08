using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestScoreReachStageDefine : QuestScoreBaseDefine
{
	private int stageReach = 5;

	public override SMPNum ScoreExspectAfterFinish()
	{
		//int lv = EditorController.instance.GameLv + stageReach;
		//var totalTime = new SMPNum(0);
		//var timeKillGhost = EditorController.instance.GetTimeToKillGhost(lv);
		//var timeKillBoss = EditorController.instance.GetTimeToKillBoss(lv);
		//totalTime = timeKillGhost + timeKillBoss;
		//return EditorController.instance.GetCovertScoreFromTime(totalTime, lv);

		//var bossGold = EditorController.instance.GetGoldToDrop(lv);

		var dmg = EditorController.instance.GetCurrentHeroDMG();
		return EditorController.instance.GetConvertScoreFromDMGToKillBoss(dmg, stageReach);
	}

	
	//public override SMPNum ScoreInBattleCurrently()
	//{
		//var totalTime = new SMPNum(0);
		//var timeKillGhost = EditorController.instance.GetTimeToKillGhost();
		//var timeKillBoss = EditorController.instance.GetTimeToKillBoss();
		//totalTime = timeKillGhost + timeKillBoss;
		//return EditorController.instance.GetCovertScoreFromTime(totalTime);
	//}
}
