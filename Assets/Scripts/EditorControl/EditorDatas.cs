using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.Linq;

public class EditorDatas : MonoBehaviour
{
	public static EditorDatas instance;

	public List<SMPUserSkillData> userSkillDatas;
	public List<SMPHeroAndSkillData> listHeroAndSkillData;

	private void Awake()
	{
		instance = this;

		LoadPlayerSkill();
	}

	public SMPUserSkillData GetSkillData(int id)
	{
		return userSkillDatas.FirstOrDefault(s => s.m_iID == id);
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

		listHeroAndSkillData = new List<SMPHeroAndSkillData>();
		jsonData = SMPLocalDataProvider.GetHeroAndSkillData();
		if (!string.IsNullOrEmpty(jsonData))
		{
			var nodeArray = JSON.Parse(jsonData).AsArray;
			foreach (var node in nodeArray)
			{
				listHeroAndSkillData.Add(new SMPHeroAndSkillData(node.ToString()));
			}
		}
	}
}
