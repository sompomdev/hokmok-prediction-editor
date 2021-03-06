using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Serialization;

[System.Serializable]
public class QuestData
{
	public int questId;
	public string questName;

	[JsonIgnore]
	//[HideInInspector]
	public SMPNum score = new SMPNum(0);
	[HideInInspector]
	public int gameLvTarget;

	public QuestTypeForPriority questType;
	public string questRatioClass;
	public int target;
	public int target2;
	public int powerUpType;
	public int petId;
	public int heroId;
	public int supportId;
	public int bossType;
	public int fruitType;

	public string bigTargetPower;
	[JsonIgnore]
	public SMPNum bigTarget_GS {
		get
		{
			return SMPNum.FromPower(bigTargetPower);
		}
	}

	public float duration;

	public string questGameLevelDefineClass;
}

public enum QuestTypeForPriority
{
	GOLD_FARMING,
	DMG_FARMING,
	TUTORIAL,
	USER_SELF_CHALLANGE,
	STAGE_REACH,
	DECORATION
}

public enum RankType
{
	NONE,
	BRONZE,
	SILVER,
	GOLD,
	PLATINIUM
}