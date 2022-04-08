using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestData
{
	public int questId;
	public string questName;

	[HideInInspector]
	public SMPNum score;
	[HideInInspector]
	public int gameLvTarget;

	public QuestTypeForPriority questType;
	public string questRatioClass;
	public int priority;
	public int target;
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
