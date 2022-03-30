using UnityEngine;
using UnityEngine.UI;
//using Sompom.Common;
//using Sompom.GamePlay.Battle;

public class SMPRatioDebugInput : MonoBehaviour
{
	[SerializeField]
	private GameObject focus;

	public InputField ipRatio;
	public int indexInterval;
	public SequenceName seriesName;
	public bool IsFirstTerm = false;

	private void Start()
	{
		UpdateInputValue();
		//Debug.Log(seriesName + " " + indexInterval+" "+IsFirstTerm);
	}

	private void OnEnable()
	{
		//SMPBattleSystem.onZoneBossBattleDeath += UpdateFocus;
		UpdateFocus();
	}

	private void OnDisable()
	{
		//SMPBattleSystem.onZoneBossBattleDeath -= UpdateFocus;
	}

	public void OnIputRatioChange(string value)
	{
		float ratio = 0;
		if(float.TryParse(value, out ratio))
		{
			if(ratio < 0)
			{
				ratio = 0;
			}
			if(IsFirstTerm)
			{
				SMPRatioDebugData.SetFirstTermRatioDebug(indexInterval, seriesName, ratio);
			}
			else
			{
				SMPRatioDebugData.SetSeriesCommonRatioDebug(indexInterval, seriesName, ratio);
			}
		}
		UpdateInputValue();
	}

	public void UpdateInputValue()
	{
		if(IsFirstTerm)
		{
			ipRatio.text = SMPRatioDebugData.GetFirstTermRatioDebug(indexInterval, seriesName).ToString();
		}
		else
		{
			ipRatio.text = SMPRatioDebugData.GetSeriesCommonRatioDebug(indexInterval, seriesName).ToString();
		}
	}

	private void UpdateFocus()
	{
		//if(seriesName == SequenceName.CostHero 
		//	|| seriesName == SequenceName.CostSupport 
		//	|| seriesName == SequenceName.DMGHero)
		//{
		//	focus.SetActiveOp(false);
		//	return;
		//}

		//int stageLevel = GameData.Instance().userData.level_GS;
		//var interval = SMPMathCore.getSequenceIntervalInfoFor(stageLevel, seriesName);
		//var indexInterval = interval != null ? interval.indexInterval : 4;
		//focus.SetActiveOp(indexInterval == this.indexInterval);
	}
}
