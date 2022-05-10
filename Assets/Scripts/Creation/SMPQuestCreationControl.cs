using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SimpleJSON;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SMPQuestCreationControl : MonoBehaviour
{
	[SerializeField] private string customPath;

	[SerializeField] private TMP_InputField inpId;
	[SerializeField] private TMP_InputField inpDynamicAvailable;
	[SerializeField] private TMP_InputField inpSkipPrice;
	[SerializeField] private TMP_InputField inpIconName;

	[SerializeField] private Toggle tggSkippable;
	[SerializeField] private Toggle tggIsDynamic;

	[SerializeField] private TMP_InputField inpTitleCode;
	[SerializeField] private TMP_InputField inpEventName;
	[SerializeField] private TMP_InputField inpTarget;
	[SerializeField] private TMP_InputField inpTarget2;
	[SerializeField] private TMP_InputField inpBigTarget;
	[SerializeField] private TMP_InputField inpDuration;
	[SerializeField] private TMP_InputField inpProgressType;

	[SerializeField] private TextMeshProUGUI textIndexing;
	[SerializeField] private TextMeshProUGUI textTitle;
	[SerializeField] private TextMeshProUGUI textKpiGameLvReward;
	[SerializeField] private TextMeshProUGUI textKpiGameLvShouldAppear;
	[SerializeField] private TextMeshProUGUI textRewardExpected;

	[SerializeField] private SMPQuestScrollViewControl scrollViewControl;

	private List<SMPQuestModel> models;
	private string path;
	private int currentIndex = 0;

	private SMPGameLanguage gameLangauge;
	// Start is called before the first frame update
	void Start()
	{
		gameLangauge = new SMPGameLanguage();

		if (customPath.Length > 0)
		{
			path = customPath;
		}
		else
		{
			path = Application.persistentDataPath + "/quest_data.json";
		}


		inpIconName.text = "achm_528";
		tggSkippable.isOn = true;
		tggIsDynamic.isOn = true;

		models = new List<SMPQuestModel>();

		if (File.Exists(path))
		{
			var json = File.ReadAllText(path);
			var rootNode = JSONArray.Parse(json) as SimpleJSON.JSONArray;
			foreach (var node in rootNode)
			{
				var questModel = new SMPQuestModel(node.ToString());
				models.Add(questModel);
			}

			Sort();

			UpdateDisplay();
		}

		DefineGameLevel();

		scrollViewControl.RefreshContent(models);
	}

	void Sort()
	{
		models = models.OrderBy(q => q.kpiBossLevel).ToList();
	}

	void UpdateDisplay()
	{
		if (models.Count <= 0 || currentIndex < 0 || currentIndex >= models.Count) return;

		var quest = models[currentIndex];
		inpId.text = quest.id;
		tggSkippable.isOn = quest.skippable;
		tggIsDynamic.isOn = quest.isDynamic;
		inpDynamicAvailable.text = quest.dynamicAvailable.ToString();
		inpSkipPrice.text = quest.skipPrice.ToString();
		inpIconName.text = quest.iconName;

		if (quest.ordered == null || quest.ordered.Count <= 0) return;
		var progress = quest.ordered[0];
		inpTitleCode.text = progress.progressTitleCode.ToString();
		inpEventName.text = progress.eventName;
		inpTarget.text = progress.target.ToString();
		inpTarget2.text = progress.target2.ToString();
		inpBigTarget.text = progress.bigTarget;
		inpDuration.text = progress.duration.ToString();
		inpProgressType.text = progress.progressType;

		textIndexing.text = $"{currentIndex + 1}/{models.Count}";

		textTitle.text = GetDescription(progress);
	}

	private void DefineGameLevel()
	{
		if (models.Count <= 0 || currentIndex < 0 || currentIndex >= models.Count) return;
		var quest = models[currentIndex];
		if (quest.ordered == null || quest.ordered.Count <= 0) return;
		var progress = quest.ordered[0];

		var gameLv = QuestAdapterHelper.instance.GetGameLevelDefine(progress);
		var appearLv = QuestAdapterHelper.instance.GetAppearLevelDefine(progress);
		if (gameLv > 0)
		{
			quest.kpiBossLevel = gameLv;
			quest.kpiGameLevelShouldAppear = appearLv;
			if (quest.kpiGameLevelShouldAppear <= 0) quest.kpiGameLevelShouldAppear = 1;

			textKpiGameLvReward.text = gameLv.ToString();
			textKpiGameLvShouldAppear.text = quest.kpiGameLevelShouldAppear.ToString();

			var reward = SMPMathGamePlay.GetUnBaseOnLevel(gameLv, SequenceName.DropCoins).Round();
			if (reward < 1) reward = SMPNum.FromNum(1);
			textRewardExpected.text = reward.ToReadableAlphabetV2() + " coins";
		}
		else
		{
			textKpiGameLvReward.text = "?";
			textKpiGameLvShouldAppear.text = "?";
			textRewardExpected.text = "?";
		}
	}

	// Update is called once per frame
	void Update()
	{

	}

	int TryGetValue(string text)
	{
		int value = 0;
		if (text.Length > 0)
		{
			int.TryParse(text, out value);
		}

		return value;
	}
	public void Save()
	{
		var found = models.FirstOrDefault(t => t.id == inpId.text);
		SMPProgressModel progress = null;//new SMPProgressModel();
		if (found.ordered != null && found.ordered.Count > 0)
		{
			progress = found.ordered[0];
		}
		else
		{
			progress = new SMPProgressModel();
		}
		progress.progressTitleCode = int.Parse(inpTitleCode.text);
		progress.eventName = inpEventName.text;
		if (TryGetValue(inpTarget.text) > 0)
		{
			progress.target = TryGetValue(inpTarget.text);
		}
		if (TryGetValue(inpTarget2.text) > 0)
		{
			progress.target2 = TryGetValue(inpTarget2.text);
		}

		if (TryGetValue(inpBigTarget.text) > 0)
		{
			progress.bigTarget = TryGetValue(inpBigTarget.text).ToString();
			progress.bigTarget_GS = SMPNum.FromPower(progress.bigTarget);
		}
		if (TryGetValue(inpDuration.text) > 0)
		{
			progress.duration = TryGetValue(inpDuration.text);
		}
		progress.progressType = inpProgressType.text;

		Debug.Log("Progress petid" + progress.petId);

		if (found != null)
		{
			found.level = 1;
			found.id = inpId.text;
			found.skippable = tggSkippable.isOn;
			found.isDynamic = tggIsDynamic.isOn;
			found.dynamicAvailable = int.Parse(inpDynamicAvailable.text);
			found.skipPrice = int.Parse(inpSkipPrice.text);
			found.iconName = inpIconName.text;
			found.ordered.Clear();
			found.ordered.Add(progress);
		}
		else
		{
			SMPQuestModel model = new SMPQuestModel();
			model.level = 1;
			model.id = inpId.text;
			model.skippable = tggSkippable.isOn;
			model.isDynamic = tggIsDynamic.isOn;
			model.dynamicAvailable = int.Parse(inpDynamicAvailable.text);
			model.skipPrice = int.Parse(inpSkipPrice.text);
			model.iconName = inpIconName.text;
			model.ordered = new List<SMPProgressModel>();
			model.ordered.Add(progress);

			models.Add(model);
		}

		// Sort();

		UpdateDisplay();

		DefineGameLevel();

		scrollViewControl.RefreshData(models);

		//SAVE
		JSONNode nodeOrderedArray = new JSONArray();
		for (int i = 0; i < models.Count; i++)
			nodeOrderedArray.Add(models[i].SaveToJSON());

		var json = nodeOrderedArray.ToString();
		File.WriteAllText(path, json);

		Debug.Log("Saved successfully!");
	}


	public void Previous()
	{
		currentIndex--;
		if (currentIndex < 0) currentIndex = 0;
		UpdateDisplay();
		DefineGameLevel();
	}
	public void Next()
	{
		currentIndex++;
		if (currentIndex >= models.Count) currentIndex = models.Count - 1;
		UpdateDisplay();
		DefineGameLevel();
	}

	private string GetDescription(SMPProgressModel model)
	{

		var description = "";
		if (model.eventName == "tutorial")
		{
			description = gameLangauge.GetTutorialMatchDescriptions(model.progressTitleCode);
		}
		else
		{
			description = gameLangauge.progress_des[model.progressTitleCode];
		}

		if (!object.ReferenceEquals(model.bigTarget_GS, null))
		{
			description = description.Replace("[n]", model.bigTarget_GS.ToString("0"));
		}
		else
		{
			description = description.Replace("[n]", model.target.ToString("0"));
		}
		if (model.duration > 0)
		{
			description = description.Replace("[t]", model.duration.ToString("0"));
		}

		if (description.Contains("[n2]"))
		{
			description = description.Replace("[n2]", model.target2.ToString("0"));
		}

		if (description.Contains("[hero_name]"))
		{
			description = description.Replace("[hero_name]", gameLangauge.hero_names[model.heroId - 1]);
		}

		if (description.Contains("[support_name]"))
		{
			description = description.Replace("[support_name]", gameLangauge.supporters_info[model.supportId - 1].name);
		}

		if (description.Contains("[rank_title]"))
		{
			description = description.Replace("[rank_title]", gameLangauge.rank_title[model.target - 1]);
		}

		if (description.Contains("[fruit_type]"))
		{
			description = description.Replace("[fruit_type]", gameLangauge.fruit_type[(int)model.fruitType_GS]);
		}

		if (description.Contains("[boss_type]"))
		{
			description = description.Replace("[boss_type]", gameLangauge.boss_type[model.bossType]);
		}

		if (description.Contains("[powerup_name]"))
		{
			description = description.Replace("[powerup_name]", gameLangauge.hero_active_skill_names[(int)model.powerUpType_GS]);
		}

		if (description.Contains("[pet_name]"))
		{
			var pet = EditorDatas.instance.GetPetData(model.petId);
			if (pet != null)
			{
				description = description.Replace("[pet_name]", pet.petName);
			}

		}

		if (description.Contains("[world_name]"))
		{
			var zoneName = SMPZoneConfig.GetZoneName(model.target);
			description = description.Replace("[world_name]", zoneName);
		}

		return description;
	}

}
