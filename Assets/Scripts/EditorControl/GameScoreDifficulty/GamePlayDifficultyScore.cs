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

	public const float SCORE_RATIO = 1;
	
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

		var scoreGoldFarm = new DifficultyScoreGoldFarmDefine().GetScoreOnDMG(dmg);
		lblGoldFarmingScore.text = scoreGoldFarm.ToString();

		string txtDifficulty = "Easy";
		if (scoreReachStage <= SCORE_RATIO / 4) txtDifficulty = "Very Hard";
		else if (scoreReachStage <= SCORE_RATIO / 2) txtDifficulty = "Hard";
		else if (scoreReachStage <= SCORE_RATIO * 1.2) txtDifficulty = "Normal";
		else if (scoreReachStage <= SCORE_RATIO * 2) txtDifficulty = "Easy";
		else txtDifficulty = "Very Easy";

		lblGameScore.text = txtDifficulty;
	}
	
}
