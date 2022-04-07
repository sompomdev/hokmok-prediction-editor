using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GamePlayDifficultyScore : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI lblGameScore;
	[SerializeField]
	private TextMeshProUGUI lblReachStageScore;
	[SerializeField]
	private TextMeshProUGUI lblDMGFarmingScore;
	[SerializeField]
	private TextMeshProUGUI lblGoldFarmingScore;

	public const float SCORE_RATIO = 100;
	
    // Update is called once per frame
    void Update()
    {
		UpdateScoreText();
    }

	public SMPNum GetFinalGameScore()
	{
		var dmg = EditorController.instance.GetCurrentHeroDMG();
		var reachStageScore = new DifficultyScoreReachStageDefine();

		return reachStageScore.GetScoreOnDMG(dmg);
	}
	
	public void UpdateScoreText()
	{
		var dmg = EditorController.instance.GetCurrentHeroDMG();
		
		var scoreReachStage = new DifficultyScoreReachStageDefine().GetScoreOnDMG(dmg);
		lblReachStageScore.text = scoreReachStage.ToString();

		var scoreDMGFarm = new DifficultyScoreDMGFarmDefine().GetScoreOnDMG(dmg);
		lblDMGFarmingScore.text = scoreDMGFarm.ToString();

		lblGameScore.text = ((scoreReachStage + scoreDMGFarm) / 2).ToString();
	}
	
}
