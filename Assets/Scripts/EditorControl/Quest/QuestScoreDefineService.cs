using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class QuestScoreDefineService : MonoBehaviour
{
	public List<QuestData> QuestRatioDefine(List<QuestData> questDatas)
	{
		List<QuestData> qsd = questDatas.ToList();
		foreach (var q in qsd)
		{
			Type t = Type.GetType(q.questRatioClass);
			QuestScoreBaseDefine qDefine =(QuestScoreBaseDefine)Activator.CreateInstance(t);
			q.score = qDefine.ScoreProfit();
		}
		
		return qsd.OrderByDescending(q => q.score).ToList();

	}
}
