using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class QuestRatioDefineService : MonoBehaviour
{
	public List<QuestData> QuestRatioDefine(List<QuestData> questDatas)
	{
		List<QuestData> qsd = questDatas.ToList();
		foreach (var q in qsd)
		{
			Type t = Type.GetType(q.questRatioClass);
			QuestRatioBaseDefine qDefine =(QuestRatioBaseDefine)Activator.CreateInstance(t);
			//var rn = qDefine.RatioNeeded();
			//var rp = qDefine.RatioPassRequire();
			//q.ratio = rp + rn;
			q.ratio = qDefine.ScoreProfit();
		}

		//return qsd.OrderByDescending(q => q.priority).OrderByDescending(q => q.ratio).ToList();
		return qsd.OrderByDescending(q => q.ratio).ToList();

	}
}
