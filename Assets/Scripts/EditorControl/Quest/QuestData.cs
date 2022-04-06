using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestData
{
	public int questId;
	public string questName;
	[HideInInspector]
	public SMPNum ratio;
	public QuestTypeForPriority questType;
	public string questRatioClass;
	public int priority;
}

public enum QuestTypeForPriority
{
	COIN_FARMING,
	DMG_FARMING,
	TUTORIAL,
	USER_SELF_CHALANGE,
	STAGE_REACH,
	DECORATION
}
