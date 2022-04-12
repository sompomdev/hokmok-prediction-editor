//----------------------------------------------------------------------------------------------------------------//
/*
	 *		Name			: 	SMPWeaponsControl
	 *		Create Date		:	24-09-2016
	 *		Modified		:	24-09-2016
	 *		Author			:	Gaucher Jimmy
	 *		Author Modify	:	Gaucher Jimmy
	 *		Sumary			: 	Control all components in inventory.WeaponsControl.
	*/
//----------------------------------------------------------------------------------------------------------------//

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

//using Sompom.Common;

//using Sompom.UI;
//using Sompom.GamePlay;

//using Newtonsoft.Json;
using SimpleJSON;

namespace Sompom.Inventory
{
	public class SMPSupportsAbility 
	{
		public int m_iID;
		public string m_sName;
		public int m_iCurrentLevel;
		public bool m_bUnlocked;
        public bool m_bUnlockedInCurrentEvolution { get; set; }
        public string m_iIconId;
        public SupportSkillType m_skillType;
        public double m_skillPercent;
		public bool isActivated;
		private int supportID;
		//[JsonIgnore]public int m_iIDSupportCharacter
		//{
		//	get{ return supportID;}
		//	set
		//	{ 
		//		supportID = value;
		//	}
		//}

		//private object CreateInstaceObjectByString(string strFullyQualifiedName)
		//{         
		//	Type t = Type.GetType(strFullyQualifiedName); 
		//	return  Activator.CreateInstance(t,m_iIDSupportCharacter, m_iID);     
		//}
        
        public SMPSupportsAbility (string fromJsongString)
		{
			var node = JSON.Parse(fromJsongString);
			m_bUnlocked = node["m_bUnlocked"].AsBool;
            m_iCurrentLevel = node["m_iCurrentLevel"].AsInt;
            m_iIconId = node["m_iIconId"];
            m_iID = node["m_iID"].AsInt;
			m_bUnlockedInCurrentEvolution = node["m_bUnlockedInCurrentEvolution"].AsBool;
            m_skillPercent = node["m_skillPercent"].AsDouble;
            m_skillType = (SupportSkillType)node["m_skillType"].AsInt;
		}

        public JSONNode SaveToJSON()
        {
            JSONNode node = new JSONObject();
            node["m_bUnlocked"] = m_bUnlocked;
			node["m_bUnlockedInCurrentEvolution"] = m_bUnlockedInCurrentEvolution;
			node["m_iCurrentLevel"] = m_iCurrentLevel;
            node["m_iIconId"] = m_iIconId;
            node["m_iID"] = m_iID;
            node["m_skillPercent"] = m_skillPercent;
            node["m_skillType"] =(int) m_skillType;

            return node;
        }
	}
}