//----------------------------------------------------------------------------------------------------------------//
/*
	 *		Name			: 	SupportsCharacters
	 *		Create Date		:	24-09-2016
	 *		Modified		:	24-09-2016
	 *		Author			:	Gaucher Jimmy
	 *		Author Modify	:	Gaucher Jimmy
	 *		Sumary			: 	Object in inventory.SupportsCharacters.
	*/
//----------------------------------------------------------------------------------------------------------------//

using UnityEngine;
using System.Collections.Generic;
using SimpleJSON;
using CodeStage.AntiCheat.ObscuredTypes;

namespace Sompom.Inventory
{
	public enum SupportStates 
	{
		Hired,
		LevelUp,
		UnlockedSkill,
	}

    public enum SupportSkillType
    {
        HERO_DAMAGE             = 1,//the supporter damage
        TAP_DAMAGE              = 2,
        TAP_DAMAGE_OF_TOTAL_DPS = 3,
        ALL_DAMAGE              = 4,
		WAVE_REDUCE				= 5,
        CRITICAL_CHANCE         = 6,
        CRITICAL_DAMAGE         = 7,
        GOLD_DROP               = 8,
        TREASURE_CHEST_GOLD     = 9,//the coin for the cat
        EVOLVE                  = 10,
        MANA_BONUS                  = 11
    }

	public enum SupportStandType
	{
		GROUND = 1,
		FLYING = 2
	}

	public class SMPSupportsCharacters 
	{
		public int m_iID;
		public string m_sName;

		public ObscuredInt m_iCurrentLevel;
        public HERO_COLOR m_iFruitType;
        public SMPNum m_sCost;
        public double m_sCostBase;

        private SMPNum _attackDamage = new SMPNum(0);
        public SMPNum m_sAttackDamages{
            get{ return _attackDamage;}
            set{ 
                if (SMPNum.IsNull(value) || value.ToString() == "NaN")
                {
                    Debug.Log("=======$$$$$$$$$$$>>>>>>>> OH NO, WHY NAN to me???");
                    throw new System.Exception("=======$$$$$$$$$$$>>>>>>>> OH NO, WHY NAN to me???");
                }
                else
                {
                    _attackDamage = value;
                }
            }
        }
		
		public float m_fAttackSpeed;
        
		public bool m_bUnlocked;
		public bool m_bHired;
		public SupportStandType m_SupportStandType = SupportStandType.GROUND;

        public bool m_evolved;
        public ObscuredInt m_evoledCounter;

        public SupportStates m_SupportState;
		public List<SMPSupportsAbility> m_SupportsAbilityList;
        public SMPSupportsCharacters ()
        {}

        public SMPSupportsCharacters (string fromJsonString)
        {
            var node = JSON.Parse(fromJsonString);
            m_bHired = node["m_bHired"].AsBool;
            m_bUnlocked = node["m_bUnlocked"].AsBool;
            m_evolved = node["m_evolved"].AsBool;
            m_fAttackSpeed = node["m_fAttackSpeed"].AsFloat;
            m_iCurrentLevel = node["m_iCurrentLevel"].AsInt;
            m_iFruitType = (HERO_COLOR) node["m_iFruitType"].AsInt;
            m_iID = node["m_iID"].AsInt;
            m_SupportState = (SupportStates)node["m_SupportState"].AsInt;
			int standType = node["m_SupportStandType"].AsInt;
			if (standType != 0)
			{
				m_SupportStandType = (SupportStandType)standType;
			}

            var nodeArray = node["m_SupportsAbilityList"].AsArray;
            m_SupportsAbilityList = new List<SMPSupportsAbility>();
            foreach(var n in nodeArray)
            {
                SMPSupportsAbility supportAbility = new SMPSupportsAbility(n.ToString());
                m_SupportsAbilityList.Add(supportAbility);
            }
        }

        public JSONNode SaveToJSON()
        {
            JSONNode node = new JSONObject();
            node["m_bHired"] = m_bHired;
            node["m_bUnlocked"] = m_bUnlocked;
            node["m_evolved"] = m_evolved;
            node["m_fAttackSpeed"] = m_fAttackSpeed;
            node["m_iCurrentLevel"] = m_iCurrentLevel.ToInt();
            node["m_iFruitType"] = (int) m_iFruitType;
            node["m_iID"] = m_iID;
            node["m_SupportState"] = (int)m_SupportState;

            JSONNode nodeArray = new JSONArray();
            for(int i = 0; i < m_SupportsAbilityList.Count; i++)
                nodeArray.Add(m_SupportsAbilityList[i].SaveToJSON());

            node["m_SupportsAbilityList"] = nodeArray;

            return node;
        }

	}
}