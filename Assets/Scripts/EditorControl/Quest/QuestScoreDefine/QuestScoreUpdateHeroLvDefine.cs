using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestScoreUpdateHeroLvDefine : QuestScoreBaseDefine
{
	private int lvAdd = 5;

	public override SMPNum ScoreExspectAfterFinish()
	{
		int lvTarget = EditorController.instance.HeroLv + lvAdd;
		var dmgTarget = EditorController.instance.GetHeroDmg(lvTarget);
		var goldHave = EditorController.instance.currentGold;
		var goldSpent = EditorController.instance.goldPerUpdateLv * lvAdd;
		return EditorController.instance.GetConvertScoreFromDMGToKillGhost(dmgTarget) + goldHave - goldSpent;
	}
}
