using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(QuestGrid))]
public class QuestToolEditor : Editor
{
	QuestGrid Target
	{
		get
		{
			return (QuestGrid)target;
		}
	}

	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();

		if(GUILayout.Button("Generate gameLv Quest"))
		{
			GenerateGameLvQuest();
		}
	}

	private void GenerateGameLvQuest()
	{
		var scoreService = GameObject.FindObjectOfType<QuestScoreDefineService>();
		if(scoreService != null)
		{
			//var qDatas = scoreService.QuestRatioDefine(Target.questDatas);

		}
		else
		{
			Debug.LogError("No Score Service");
		}
	}
}
