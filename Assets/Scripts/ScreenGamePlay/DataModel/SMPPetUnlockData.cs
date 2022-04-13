/*//————————————————————————————————————————//
	Company Name : Sompom Game Studio 
	Developer Name 	: Mr.Puthear San
		Unity Developer
//————————————————————————————————————————//*/

using SimpleJSON;
using CodeStage.AntiCheat.ObscuredTypes;
using System;

public enum SMPPetRotationState
{
	AVAILABLE,
	RECOVERING,
	ACTIVE
}
[System.Serializable]
public class SMPPetRotation
{
	public SMPPetRotationState state;
	public DateTime startTime_GS { get; set; }
	public float attackCounter;
	public float recoverDurationOnPassive;

	//for serialize
	public string startTime;

	public void SetState (SMPPetRotationState state)
	{
		if(this.state != state)
		{
			startTime_GS = DateTime.Now;
			this.state = state;
		}
	}
	public void ResetAttackCounter ()
	{
		attackCounter = 0;
	}
	
	public SMPPetRotation(){}
	public SMPPetRotation(string fromJsonString)
	{
		var node = JSON.Parse(fromJsonString);

		state = (SMPPetRotationState)node["state"].AsInt;
		attackCounter = node["attackCounter"].AsFloat;
		recoverDurationOnPassive = node["recoverDurationOnPassive"].AsFloat;


		string _startTime = node["startTime"];
		long _timeLong = Convert.ToInt64(_startTime);
		startTime_GS = DateTime.FromBinary(_timeLong);
	}
	public JSONNode SaveToJSON()
	{
		JSONNode node = new JSONObject();
		node["state"] = (int)state;
		node["startTime"] = startTime_GS.ToBinary().ToString();
		node["attackCounter"] = attackCounter;
		node["recoverDurationOnPassive"] = recoverDurationOnPassive;

		return node;
	}


	public void PrepareSaveString()
	{
		startTime = startTime_GS.ToBinary().ToString();
	}
}
[System.Serializable]
public class SMPPetUnlockData 
{
	public int id;
	public ObscuredInt level_GS { get; set; }
	public bool m_Unlocked;
	public bool m_hired;

	//for serialize
	public int level;

	public SMPPetRotation petRotation;

	public SMPPetUnlockData ()
	{
		petRotation = new SMPPetRotation();
	}
	public SMPPetUnlockData (string fromJsonString)
	{
		var node = JSON.Parse(fromJsonString);
		id = node["id"].AsInt;
		level_GS = node["level"].AsInt;
		m_Unlocked = node["m_Unlocked"].AsBool;
		m_hired = node["m_hired"].AsBool;

		if (node["petRotation"] != null)
		{
			petRotation = new SMPPetRotation(node["petRotation"].ToString());
		}
		else
		{
			petRotation = new SMPPetRotation();
		}
		
	}
	public JSONNode SaveToJSON()
	{
		JSONNode node = new JSONObject();
		node["id"] = id;
		node["level"] = level_GS.ToInt();
		node["m_Unlocked"] = m_Unlocked;
		node["m_hired"] = m_hired;
		node["petRotation"] = petRotation.SaveToJSON();
		return node;
	}

	public void PrepareSaveString()
	{
		level = level_GS;
		petRotation.PrepareSaveString();
	}
}
