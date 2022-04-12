/*//————————————————————————————————————————//
	Company Name : Sompom Game Studio 
	Developer Name 	: Mr.Puthear San
		Unity Developer
//————————————————————————————————————————//*/

using System.Collections.Generic;
using SimpleJSON;

public class SMPHeroAndSkillData 
{
	public int m_iHeroID = 0;
	public List<SMPSkillItem> m_SkillList = new List<SMPSkillItem>();

	public SMPHeroAndSkillData(string fromJsonString)
    {
        var node = JSON.Parse(fromJsonString);
		m_iHeroID = node["m_iHeroID"].AsInt;
		var nodeArraySkillUnlock = node["m_SkillList"].AsArray;
		m_SkillList = new List<SMPSkillItem>();
		foreach(var n in nodeArraySkillUnlock)
		{
			m_SkillList.Add(new SMPSkillItem(n.ToString()));
		}
    }

    public JSONNode SaveToJSON()
    {
        JSONNode node = new JSONObject();
		node["m_iHeroID"] = m_iHeroID;
		JSONNode nodeSkillArray = new JSONArray();
		for (int i = 0; i < m_SkillList.Count; i++)
		{
			nodeSkillArray.Add(m_SkillList[i].SaveToJSON());
		}
		node["m_SkillList"] = nodeSkillArray;
        return node;
    }

	public class SMPSkillItem
	{
		public int m_iSkillID;
		public bool m_bUnlocked;
		public int m_iLevel;

		public SMPSkillItem(string jSon)
		{
			var node = JSON.Parse(jSon);
			m_iSkillID = node["m_iSkillID"].AsInt;
			m_bUnlocked = node["m_bUnlocked"].AsBool;
			m_iLevel = node["m_iLevel"].AsInt;
		}

		public JSONNode SaveToJSON()
		{
			JSONNode node = new JSONObject();
			node["m_iSkillID"] = m_iSkillID;
			node["m_bUnlocked"] = m_bUnlocked;
			node["m_iLevel"] = m_iLevel;
			return node;
		}
	}
}
