//----------------------------------------------------------------------------------------------------------------//
/*
	 *		Name			: 	SMPUserSkillData
	 *		Create Date		:	23-12-2016
	 *		Modified		:	23-12-2016
	 *		Author			:	Ly Ratana
	 *		Author Modify	:	Ly Ratana
	 *		Sumary			: 	
	*/
//----------------------------------------------------------------------------------------------------------------//


using UnityEngine;
using System.Collections;
using SimpleJSON;

public enum ActiveSkillType
{
	UNKOWN = -1,
    THUNDER_ATTACK = 0,//HeavenlyStrike_Skill
	TWIN_SHADOW,//ShadowClone_Skill
	LAST_HAND,//CriticalStrike_Skill
	FAST_AND_FURIOUS, //SMPSkillWarCry
	ANGER_OF_GOD, //SMPBerserkerRageSkill
	GOLD_FINGER,//Hand_of_Midas_Skill
	ANGER_OF_PET,//AngerOfPet_Skill
	PROTECTION,//Protection_Skill
	FLYING_SUPPORT,//SupportFly_Skill
	THE_TEAMMATE = 10//Teammate_Skill_container
}

public enum AvailableType
{
	ALWAYS,
	ONLY_GHOST_MODE,
	ONLY_BOSS_MODE
}
public class SMPUserSkillData 
{
	public int m_iID; // is ActiveSkillType
	public string m_sName;
	public string ic_name;
	public int Level_Unlock;
    public bool is_unlocked;
	public float m_fDuration;
	public float m_fCoolDownDuration;
    public SMPNum m_sCost;
	public int base_Mana;
	public int base_ManaCap;
	public double manaConsumtion;
	public double manaCapBonus;
    public int m_iLv;
	public AvailableType availableType;

	public bool BossModeOnly { get{ return availableType == AvailableType.ONLY_BOSS_MODE;}}
	public bool GhostModeOnly { get{ return availableType == AvailableType.ONLY_GHOST_MODE;}}
	public bool NormalMode { get{ return availableType == AvailableType.ONLY_GHOST_MODE || availableType == AvailableType.ALWAYS;}}

	public bool IsTwinShadow { get { return m_iID == (int)ActiveSkillType.TWIN_SHADOW; } }

	public SMPUserSkillData(){}
	public SMPUserSkillData(string fromJsonString)
	{
		if(!string.IsNullOrEmpty(fromJsonString))
		{
			var node = JSON.Parse(fromJsonString);
			m_iID = node["m_iID"].AsInt;
			ic_name = node["ic_name"];
			Level_Unlock = node["Level_Unlock"].AsInt;
			is_unlocked = node["is_unlocked"].AsBool;
			m_fDuration = node["m_fDuration"].AsFloat;
			m_fCoolDownDuration = node["m_fCoolDownDuration"].AsFloat;
			base_Mana = node["base_Mana"].AsInt;
			base_ManaCap = node["base_ManaCap"].AsInt;
			m_iLv = node["m_iLv"].AsInt;
			availableType = (AvailableType)node["availableType"].AsInt;
		}
	}
}


public class SMPPassiveSkillData
{
    public int m_iID;
    public string m_sName;
    public int Level_Unlock;
    public bool is_unlocked;
    public SMPNum m_sCost;
    public int m_iLv;

    public SMPPassiveSkillData() { }
    public SMPPassiveSkillData(string fromJsonString)
    {
        if (!string.IsNullOrEmpty(fromJsonString))
        {
            var node = JSON.Parse(fromJsonString);
            m_iID = node["m_iID"].AsInt;
            Level_Unlock = node["Level_Unlock"].AsInt;
            is_unlocked = node["is_unlocked"].AsBool;
            m_iLv = node["m_iLv"].AsInt;
        }
    }
}
