using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class EditorDatas : MonoBehaviour
{
	public static EditorDatas instance;

	public List<SMPUserSkillData> userSkillDatas;

	private void Awake()
	{
		instance = this;

		LoadPlayerSkill();
	}

	public void LoadPlayerSkill()
	{
		string jsonData = SMPLocalDataProvider.GetUserSkillData();
		if (!string.IsNullOrEmpty(jsonData))
		{
			userSkillDatas = new List<SMPUserSkillData>();
			var nodeArray = JSON.Parse(jsonData).AsArray;
			foreach (var node in nodeArray)
			{
				userSkillDatas.Add(new SMPUserSkillData(node.ToString()));
			}
		}
	}
}
