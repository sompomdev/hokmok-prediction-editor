using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System.Linq;
using Sompom.Inventory;
using Sompom.GamePlay.Enemy;
using Newtonsoft.Json;

public class EditorDatas : MonoBehaviour
{
	public static EditorDatas instance;

	public List<SMPUserSkillData> userSkillDatas;
	public List<SMPPassiveSkillData> listPassiveSkills;
	public List<SMPHeroAndSkillData> listHeroAndSkillData;
	public List<SMPSupportsCharacters> supportsCharactersList;
	public List<SMPPetsData> petDatas;
	public List<ShopSkillData> shopSkillDatas;
	public List<SMPZoneData> zoneDatas;

	private void Awake()
	{
		instance = this;

		LoadPlayerSkill();
		LoadHeroesPassiveSkills();
		LoadSupportsControl();
		LoadPetsData();
		LoadShopSkillDatas();
		LoadEnemyDataByZone();
	}

	public SMPUserSkillData GetSkillData(int id)
	{
		var skillData = userSkillDatas.FirstOrDefault(s => s.m_iID == id);
		skillData.m_iLv = 0;
		skillData.is_unlocked = false;
		return skillData;
	}

	public SMPPassiveSkillData GetPassiveSkillData(int id)
	{
		return listPassiveSkills.FirstOrDefault(p => p.m_iID == id);
	}

	public SMPSupportsCharacters GetSupportData(int id)
	{
		var supportData = supportsCharactersList.FirstOrDefault(s => s.m_iID == id);
		supportData.m_evolved = false;
		supportData.m_evoledCounter = 0;
		supportData.m_bHired = false;
		supportData.m_SupportsAbilityList.ForEach(s => s.m_bUnlocked = false);
		supportData.m_iCurrentLevel = 0;
		supportData.m_SupportState = SupportStates.LevelUp;
		return supportData;
	}

	public SMPPetsData GetPetData(int id)
	{
		return petDatas.FirstOrDefault(p => p.petID == id);
	}

	public ShopSkillData GetShopSkillData(int id)
	{
		return shopSkillDatas.FirstOrDefault(s => s.ID == id);
	}

	public SMPZoneData GetZoneData(int id)
	{
		return zoneDatas.FirstOrDefault(z => z.zone_id == id);
	}

	public int GetZoneByLevel(int level)
	{
		return Mathf.FloorToInt(level / SMPQuestTemplateConstance.MAX_LEVEL_ON_STAGE);
	}

	public int GetGameLevelByZone(int zoneId)
	{
		if (zoneId == 1) return 1;
		return ((zoneId - 1) * SMPQuestTemplateConstance.MAX_LEVEL_ON_STAGE);
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

	public void LoadHeroesPassiveSkills()
	{
		listPassiveSkills = new List<SMPPassiveSkillData>();
		string jsonData = SMPLocalDataProvider.GetUserPassiveSkillData();
		if (!string.IsNullOrEmpty(jsonData))
		{
			var nodeArray = JSON.Parse(jsonData).AsArray;
			foreach (var node in nodeArray)
			{
				listPassiveSkills.Add(new SMPPassiveSkillData(node.ToString()));
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

	public void LoadShopSkillDatas()
	{
		string jsonData = SMPLocalDataProvider.GetShopSkillData();
		if (!string.IsNullOrEmpty(jsonData))
		{
			List<ShopSkillData> datas = new List<ShopSkillData>();
			var nodeArray = JSON.Parse(jsonData).AsArray;
			foreach (var node in nodeArray)
			{
				datas.Add(new ShopSkillData(node.ToString()));
			}
			shopSkillDatas = datas.ToList();
		}
	}

	public void LoadEnemyDataByZone()
	{
		string jsonContent = SMPLocalDataProvider.GetEnemyByZoneData();
		zoneDatas = JsonConvert.DeserializeObject<List<SMPZoneData>>(jsonContent);
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