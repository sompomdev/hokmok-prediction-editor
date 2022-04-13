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
	public List<SMPSupportsCharacters> supportsCharactersList;
	public List<SMPPetsData> petDatas;

	private void Awake()
	{
		instance = this;

		LoadPlayerSkill();
		LoadSupportsControl();
		LoadPetsData();
	}

	public SMPUserSkillData GetSkillData(int id)
	{
		return userSkillDatas.FirstOrDefault(s => s.m_iID == id);
	}

	public SMPSupportsCharacters GetSupportData(int id)
	{
		return supportsCharactersList.FirstOrDefault(s => s.m_iID == id);
	}

	public SMPPetsData GetPetData(int id)
	{
		return petDatas.FirstOrDefault(p => p.petID == id);
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
		supportsCharactersList = new List<SMPSupportsCharacters>();
		foreach (var node in nodeArray)
		{
			supportsCharactersList.Add(new SMPSupportsCharacters(node.ToString()));
		}
	}

	public void LoadPetsData()
	{
		string jsonData = SMPLocalDataProvider.GetPetData();
		if (!string.IsNullOrEmpty(jsonData))
		{
			petDatas = new List<SMPPetsData>();
			var nodeArray = JSON.Parse(jsonData).AsArray;
			foreach (var node in nodeArray)
			{
				petDatas.Add(new SMPPetsData(node.ToString()));
			}
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