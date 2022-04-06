using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestRatioCoinVideoAdsDefine : QuestRatioBaseDefine
{
	public override SMPNum RatioNeeded()
	{
		var goldDrop = EditorController.instance.goldDrop;

		return (goldDrop * 2) * 4;//4 is the play video time in 60s
	}
}
