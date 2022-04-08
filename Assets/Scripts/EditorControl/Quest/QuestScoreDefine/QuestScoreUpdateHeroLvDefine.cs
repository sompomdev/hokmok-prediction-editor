using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestScoreUpdateHeroLvDefine : QuestScoreBaseDefine
{
	private int lvAdd = 5;

	public override SMPNum ScoreExspectAfterFinish()
	{
		int lv = EditorController.instance.HeroLv;
		int lvTarget = lv + lvAdd;
		var dmgTarget = EditorController.instance.GetHeroDmg(lvTarget);
		//var goldHave = EditorController.instance.currentGold;
		//var dmg = EditorController.instance.GetCurrentHeroDMG();
		//var goldSpent = SMPHeroLevelConfiguration.GetCostOnLevel(5, lv, lvAdd);
		return EditorController.instance.GetConvertScoreFromDMGToKillGhost(dmgTarget);// + goldHave - goldSpent;
	}
}
