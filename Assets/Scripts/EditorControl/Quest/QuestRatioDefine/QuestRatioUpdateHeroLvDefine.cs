using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestRatioUpdateHeroLvDefine : QuestRatioBaseDefine
{
	private int lvAdd = 5;

	public override SMPNum RatioNeeded()
	{
		int lvTarget = EditorController.instance.HeroLv + lvAdd;
		var dmgTarget = EditorController.instance.GetHeroDmg(lvTarget);
		return EditorController.instance.GetConvertScoreFromDMGToKillGhost(dmgTarget);
	}

	public override SMPNum RatioPassRequire()
	{
		var goldSpent = EditorController.instance.goldPerUpdateLv * lvAdd;
		var scoreInBattle = EditorController.instance.GetConvertScoreFromDMGToKillGhost(EditorController.instance.GetCurrentHeroDMG());
		var goldHave = EditorController.instance.currentGold;
		return scoreInBattle + goldSpent - goldHave;
	}
}
