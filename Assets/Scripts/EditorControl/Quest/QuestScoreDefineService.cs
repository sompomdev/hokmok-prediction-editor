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
			q.score = qDefine.ScoreProfit() + GetAddingBonusScoreDifficulty(q);

			q.gameLvTarget = DefineGameLevel(q);
		}
		
		return qsd.OrderByDescending(q => q.score).ToList();

	}

	public int DefineGameLevel(QuestData q)
	{
		Type t = Type.GetType(q.questGameLevelDefineClass);
		QuestGameLevelBaseDefine qDefine = (QuestGameLevelBaseDefine)Activator.CreateInstance(t);
		return qDefine.GameLevelDefine();
	}

	private SMPNum GetAddingBonusScoreDifficulty(QuestData questData)
	{
		DifficultyScoreBaseDefine scoreBaseDefine = null;
		switch (questData.questType)
		{
			case QuestTypeForPriority.STAGE_REACH:
				scoreBaseDefine = new DifficultyScoreReachStageDefine();
				break;

			case QuestTypeForPriority.GOLD_FARMING:
				scoreBaseDefine = new DifficultyScoreGoldFarmDefine();
				break;

			case QuestTypeForPriority.DMG_FARMING:
				scoreBaseDefine = new DifficultyScoreDMGFarmDefine();
				break;
		}

		SMPNum bonus = new SMPNum(0);
		if(scoreBaseDefine != null)
		{
			bonus = scoreBaseDefine.GetScoreOnDMG(EditorController.instance.GetCurrentHeroDMG());
		}

		return bonus;
	}
}
