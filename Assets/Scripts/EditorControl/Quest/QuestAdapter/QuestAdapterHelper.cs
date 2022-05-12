using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;
using System;

public class QuestAdapterHelper : MonoBehaviour
{
	public static QuestAdapterHelper instance;

	public List<QuestGLVDefineAdapterData> glvDefineDatas;

	private void Awake()
	{
		instance = this;
		LoadGamelevelDefineAdapterData();
	}

	public int GetGameLevelDefine(SMPProgressModel progressModel)
	{
		var strategy = _getStrategy(progressModel);
		if (strategy != null)
		{
			return strategy.GameLevelDefine();
		}
		return 0;
	}
	public int GetAppearLevelDefine(SMPProgressModel progressModel)
	{
		var strategy = _getStrategy(progressModel);
		if (strategy != null)
		{
			return strategy.AppearLevelDefine();
		}
		
		return 1;
	}

	private QuestGameLevelBaseDefine _getStrategy(SMPProgressModel progressModel)
	{
		QuestGLVDefineAdapterData data = null;
		if(progressModel.duration > 0)
		{
			data = glvDefineDatas.FirstOrDefault(g => g.eventName == progressModel.eventName
			                                          && g.progressType == progressModel.progressType
			                                          && g.isDuration);
		}
		else
		{
			data = glvDefineDatas.FirstOrDefault(g => g.eventName == progressModel.eventName
			                                          && g.progressType == progressModel.progressType
			                                          && !g.isDuration);
		}

		if(data != null)
		{
			QuestData questData = new QuestData();
			questData.target = progressModel.target;
			questData.target2 = progressModel.target2;
			questData.bigTargetPower = progressModel.bigTarget;
			questData.duration = progressModel.duration;
			questData.questGameLevelDefineClass = data.questGameLevelDefineClass;
			questData.powerUpType = (int)progressModel.powerUpType_GS;
			questData.petId = progressModel.petId;
			questData.heroId = progressModel.heroId;
			questData.supportId = progressModel.supportId;
			questData.bossType = progressModel.bossType;
			questData.fruitType = (int)progressModel.fruitType_GS;

			Type t = Type.GetType(questData.questGameLevelDefineClass);
			QuestGameLevelBaseDefine qDefine = (QuestGameLevelBaseDefine)Activator.CreateInstance(t);
			qDefine.questData = questData;
			return qDefine;
		}
		Debug.LogError("Can't define game level " + progressModel.eventName);
		return null;
	}

	private void LoadGamelevelDefineAdapterData()
	{
		var textData = Resources.Load("Data/questGLVDefineAdapterData") as TextAsset;
		glvDefineDatas = JsonConvert.DeserializeObject<List<QuestGLVDefineAdapterData>>(textData.text);
	}
}
