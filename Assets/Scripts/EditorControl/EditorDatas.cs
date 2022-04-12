using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.Linq;
using Sompom.Inventory;

public class EditorDatas : MonoBehaviour
{
	public static EditorDatas instance;

	public List<SMPUserSkillData> userSkillDatas;
	public List<SMPHeroAndSkillData> listHeroAndSkillData;
	public List<SMPSupportsCharacters> m_SupportsCharactersList;

	private void Awake()
	{
		instance = this;

		LoadPlayerSkill();
		LoadSupportsControl();
	}

	public SMPUserSkillData GetSkillData(int id)
	{
		return userSkillDatas.FirstOrDefault(s => s.m_iID == id);
	}

	public SMPSupportsCharacters GetSupportData(int id)
	{
		return m_SupportsCharactersList.FirstOrDefault(s => s.m_iID == id);
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

	public void LoadSupportsControl()
	{
		string jsonData = "";
		jsonData = SMPLocalDataProvider.GetSupportData();
		var nodeArray = JSON.Parse(jsonData).AsArray;
		m_SupportsCharactersList = new List<SMPSupportsCharacters>();
		foreach (var node in nodeArray)
		{
			m_SupportsCharactersList.Add(new SMPSupportsCharacters(node.ToString()));
		}
	}
}

public enum HERO_COLOR
{
	SUPPORT1 = 0,//RED
	HERO, //sword
	LEAF, //leaft
	SUPPORT3,//BLUE
	SUPPORT4,//orange
	SUPPORT5,//PURPLE
	EMPTY
}