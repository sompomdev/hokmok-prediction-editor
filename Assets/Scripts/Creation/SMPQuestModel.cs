using System;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
   

    public enum QuestEventName
    {
        dynamic,
        initData,
        reachStage,
		completeStage,
        unlockHero,
        heroUpdateLevel,
		supportUpdateLevel,
        unlockSupporter,
		unlockSkillSupport,
        unlockPowerUp,
        updatePowerUp,
        collectGold,
        tap,
        tutorial,
        killGhost,
        defeatBossBattle,
        collectZoneBossCrown,
        defeatBigBoss,
        defeatBossRevenge,
        tapOnTheBird,
        watchTheVideo,
        petUnlock,
        petUpdateLevel,
        gameLaunched,
        passBossFight,
        failedBossFight,
        matchCombo,
		matchInRow,
		matchInCol,
		matchInAll,
		collectDiamondFromBird,
        collectDiamond,
        makeResurrection,
        makeHeroResurrection,
        makeSupportResurrection,
        usePowerUp,
        usePowerUpEnd,
        useThunderAttackPowerUp,
        useTwinShadowPowerUp,
        useLastHandPowerUp,
        useFastAndFuriousPowerUP,
        useAngerOfGodPowerUp,
        useGoldFingerPowerUp,
        usePetAlliancePowerUp,
        useShieldOfGodPowerUp,
        useFlyingSupporterPowerUp,
        gameWorldLoop,
        usePerk,
        usePerkMakeItRain,
        usePerkPowerOfHolding,
        usePerkDoom,
        usePerkManaPortion,
		criticriticalTap,
		playingTime,
        updateGhostRoundReduced,
        refreshCurrentDps,
        onFruitMatch,
		shareToFacebook,
		shareToTwitter,
        playMasterMind,
        onMasterMindInArow,
        onWinMasterMind,
        onCompletedQuest,
        onUnlockNewZone,
    }

    public enum ProgressType
    {
        count_by_one,
        count_by_one_one_week_limit,
        count_by_one_one_day_limit,
        check_reach,
        count_in_duration,
        count_come_back_to_game_consecutive,
        count_pass_boss_fight_consecutive,
		count_in_staying_boss,
        check_n_hero_level_reach,
        check_n_pet_level_reach,
        combine_power_up,
        play_game_on_the_weekend,
        check_full_support_reach,
        check_full_active_support_reach,
        check_full_flying_support_reach,
        check_full_hero_reach,
        check_full_team_reach,
        use_n_time_n_perk,
        use_n_time_n_powerup,
        count_update_powerup_each_hero,
        count_unlock_powerup_and_use_it,
		count_by_minute,
		count_by_hour,
		count_by_day,
        count_upgrade_n_pet,
        count_upgrade_a_pet_n_time,
        count_support_evolve,
        hero_reach_rank,
        support_reach_rank,
        count_fruit_match_by_color,
        count_match_combo_by_boss_type,
        count_use_powerup_by_type,
        count_revive_a_character,
        count_all_supports_reach_evolve,
        count_all_heroes_reach_rank,
        check_match
    }
    
	[System.Serializable]
	public class SMPProgressModel
    {
        private static int instanceCounter;
        private int instanceId;

        public int progressTitleCode;
        public QuestEventName eventName_GS { get; set; }
        public ProgressType progressType_GS { get; set; }
        public HERO_COLOR fruitType_GS { get; set; }
        public ActiveSkillType powerUpType_GS { get; set; }
        public int bossType;
        public int supportId;
        public int heroId;
        public int zoneId;
        public int petId;
        public int target;
        public int target2;
        public SMPNum bigReward_GS { get; set; }
        public SMPNum bigTarget_GS { get; set; }
        public int duration;
        public SMPNum bigProgress_GS { get; set; }
        public int progress;
        public string lastLaunchDate;
        public List<string> identifiers;
        public IDictionary<string, bool> powerUpUsedDic;
        public IDictionary<string, int> countDic;

		//for serialize
		public string eventName;
		public string progressType;
		public string fruitType;
		public string powerUpType;
		public string bigReward;
		public string bigTarget;
		public string bigProgress;

        //for save of total time play in second
		public uint totalTimeSinceCount;

        public void UpdateNecessaryInfo (SMPProgressModel model)
        {
            bigProgress_GS = model.bigProgress_GS;
            progress = model.progress;
            lastLaunchDate = model.lastLaunchDate;
            identifiers = model.identifiers;
            powerUpUsedDic = model.powerUpUsedDic;
            countDic = model.countDic;
            totalTimeSinceCount = model.totalTimeSinceCount;
        }

        public SMPProgressModel Copy ()
        {
            var copy = new SMPProgressModel();
            copy.progressTitleCode = progressTitleCode;
            copy.eventName_GS = eventName_GS;
            copy.progressType_GS = progressType_GS;
            copy.fruitType_GS = fruitType_GS;
            copy.bossType = bossType;
            copy.powerUpType_GS = powerUpType_GS;
            copy.supportId = supportId;
            copy.heroId = heroId;
            copy.zoneId = zoneId;
            copy.petId = petId;
            copy.target = target;
            copy.target2 = target2;
            copy.duration = duration;
            copy.progress = progress;
            copy.lastLaunchDate = lastLaunchDate;
            copy.identifiers = identifiers != null ? new List<string>(identifiers) : null;
            copy.powerUpUsedDic = powerUpUsedDic != null ? new Dictionary<string, bool>(powerUpUsedDic) : null;
            copy.countDic = countDic != null ? new Dictionary<string, int>(countDic) : null;

			copy.totalTimeSinceCount = 0;

            if (!object.ReferenceEquals(bigTarget_GS, null))
            {
                copy.bigTarget_GS = SMPNum.FromPower(bigTarget_GS.Power);
            }
            if (!object.ReferenceEquals(bigReward_GS, null))
            {
                copy.bigReward_GS = SMPNum.FromPower(bigReward_GS.Power);
            }
            if (!object.ReferenceEquals(bigProgress_GS, null))
            {
                copy.bigProgress_GS = SMPNum.FromPower(bigProgress_GS.Power);
            }

            return copy;
        }

        public SMPProgressModel()
        {
            instanceId = ++instanceCounter;
        }
        public SMPProgressModel(string fromJsonString)
        {
            instanceId = ++instanceCounter;

            if (!string.IsNullOrEmpty(fromJsonString))
            {
                var node = JSON.Parse(fromJsonString);
                progressTitleCode = node["progressTitleCode"].AsInt;
                supportId = node["supportId"];
                eventName = node["eventName"];
                progressType = node["progressType"];
                heroId = node["heroId"];
                zoneId = node["zoneId"];
                petId = node["petId"];
                bossType = node["bossType"];
                target = node["target"];
                target2 = node["target2"];
                duration = node["duration"];
                progress = node["progress"];
                lastLaunchDate = node["lastLaunchDate"];
                bigTarget = node["bigTarget"];

				totalTimeSinceCount = node["totalTimeSinceCount"].AsUInt;

                if (node["identifiers"] != null)
                {
                    identifiers = new List<string>();
                    foreach (var item in node["identifiers"].AsArray.Children)
                    {
                        identifiers.Add(item.Value);
                    }
                }

                if (node["powerUpUsedDic"] != null)
                {
                    powerUpUsedDic = new Dictionary<string, bool>();
                    foreach (var item in node["powerUpUsedDic"].AsArray.Children)
                    {
                        powerUpUsedDic.Add(item["key"], item["value"]);
                    }
                }

                if (node["countDic"] != null)
                {
                    countDic = new Dictionary<string, int>();
                    foreach(var item in node["countDic"].AsArray.Children)
                    {
                        countDic.Add(item["key"], item["value"]);
                    }
                }

				// var eName = QuestEventName.collectGold;
    //             if (!Enum.TryParse<QuestEventName>(node["eventName"].Value, out eName))
    //             {
    //                 throw new InvalidCastException($"There is a problem with Event Name string in quest JSON! => {node["eventName"].Value}");
    //             }
				// else
				// {
				// 	eventName_GS = eName;
				// }

				// var ePT = ProgressType.check_reach;
				// if (!Enum.TryParse<ProgressType>(node["progressType"].Value, out ePT))
    //             {
    //                 throw new InvalidCastException("There is a problem with Progress Type string in quest JSON!");
    //             }
				// else
				// {
				// 	progressType_GS = ePT;
				// }

				var eFT = HERO_COLOR.HERO;
				if (node["fruitType"] != null && !Enum.TryParse<HERO_COLOR>(node["fruitType"].Value, out eFT))
                {
                    throw new InvalidCastException("There is a problem with Fruit(HERO_COLOR) Type string in quest JSON!");
                }
				else
				{
					fruitType_GS = eFT;
				}

				var eATST = ActiveSkillType.ANGER_OF_GOD;
                if (node["powerUpType"] != null && !Enum.TryParse<ActiveSkillType>(node["powerUpType"].Value, out eATST))
                {
                    throw new InvalidCastException("There is a problem with powerUp(ActiveSkillType) Type string in quest JSON!");
                }
				else
				{
					powerUpType_GS = eATST;
				}

                string powerReward = node["bigReward"];
                if (string.IsNullOrWhiteSpace(powerReward))
                {
                    bigReward_GS = new SMPNum(0);
                }
                else
                {
                    bigReward_GS = SMPNum.FromPower(powerReward);
                }

                string power = node["bigTarget"];
                if (string.IsNullOrWhiteSpace(power))
                {
                    bigTarget_GS = null;
                }
                else
                {
                    bigTarget_GS = SMPNum.FromPower(power);
                }

                string powerBigProgress = node["bigProgress"];
                if (string.IsNullOrWhiteSpace(powerBigProgress))
                {
                    if (object.ReferenceEquals(bigTarget_GS, null))
                    {
                        bigProgress_GS = null;
                    }
                    else
                    {
                        bigProgress_GS = new SMPNum(0);
                    }
                    
                }
                else
                {
                    bigProgress_GS = SMPNum.FromPower(powerBigProgress);
                }
            }
        }
        
        public JSONNode SaveToJSON()
        {
            JSONNode node = new JSONObject();
            node["progressTitleCode"] = progressTitleCode;
            node["eventName"] = eventName;
            node["progressType"] = progressType;
		//node["fruitType"] = fruitType_GS.ToString();
		//node["powerUpType"] = powerUpType_GS.ToString();
		//node["supportId"] = supportId;
		//node["bossType"] = bossType;
		node["heroId"] = heroId;
		//node["zoneId"] = zoneId;
		//node["petId"] = petId;
		if (target != 0)
                node["target"] = target;
            if (target2 != 0)
                node["target2"] = target2;
            if (duration > 0)
                node["duration"] = duration;
            //node["lastLaunchDate"] = lastLaunchDate;
			//node["totalTimeSinceCount"] = totalTimeSinceCount;

            if (bigTarget != null && bigTarget.Length > 0)
                node["bigTarget"] = int.Parse(bigTarget);

			// if (identifiers != null)
   //          {
   //              JSONNode nodeHeroIds = new JSONArray();
   //              for (int i = 0; i < identifiers.Count; i++)
   //                  nodeHeroIds.Add(identifiers[i]);
   //
   //              node["identifiers"] = nodeHeroIds;
   //          }
   //
   //          if (powerUpUsedDic != null)
   //          {
   //              JSONNode nodePowerUsed = new JSONArray();
   //              foreach (KeyValuePair<string, bool> item in powerUpUsedDic)
   //              {
   //                  JSONNode itemNode = new JSONObject();
   //                  itemNode["key"] = item.Key;
   //                  itemNode["value"] = item.Value;
   //
   //                  nodePowerUsed.Add(itemNode);
   //              }
   //
   //              node["powerUpUsedDic"] = nodePowerUsed;
   //          }
   //
   //          if (countDic != null)
   //          {
   //              JSONNode nodeRoot = new JSONArray();
   //              foreach(KeyValuePair<string, int> item in countDic)
   //              {
   //                  JSONNode itemNode = new JSONObject();
   //                  itemNode["key"] = item.Key;
   //                  itemNode["value"] = item.Value;
   //
   //                  nodeRoot.Add(itemNode);
   //              }
   //              node["countDic"] = nodeRoot;
   //          }
   //
   //
   //          if (!object.ReferenceEquals(bigReward_GS, null))
   //              node["bigReward"] = bigReward_GS.StringForSave();
   //          
   //          if (!object.ReferenceEquals(bigTarget_GS, null))
   //              node["bigTarget"] = bigTarget_GS.StringForSave();
   //
   //          bool alreadySaved = false;
   //
   //          if (progressType_GS == ProgressType.count_in_duration
   //              || progressType_GS == ProgressType.combine_power_up)
   //          {
   //              if (!IsValidated())
   //              {
   //                  node["progress"] = 0;
   //
   //                  if (!object.ReferenceEquals(bigProgress_GS, null))
   //                      node["bigProgress"] = SMPNum.DEFINE_ZERO;
   //
   //                  alreadySaved = true;
   //              }
   //          }
   //
   //          if (!alreadySaved)
   //          {
   //              node["progress"] = progress;
   //
   //              if (!object.ReferenceEquals(bigProgress_GS, null))
   //                  node["bigProgress"] = bigProgress_GS.StringForSave();
   //          }

            
            


            return node;
        }

		public void PrepareSaveString()
		{
			eventName = eventName_GS.ToString();
			progressType = progressType_GS.ToString();
			fruitType = fruitType_GS.ToString();
			powerUpType = powerUpType_GS.ToString();
			bigReward = bigReward_GS?.StringForSave();
			bigTarget = bigTarget_GS?.StringForSave();
			bigProgress = bigProgress_GS?.StringForSave();
		}

        public int GetUniqueId ()
        {
            return instanceId;
        }

        public bool IsValidated ()
        {
            if (object.ReferenceEquals(bigTarget_GS, null))
            {
                return progress >= target;
            }
            else
            {
                return bigProgress_GS >= bigTarget_GS;
            }
        }

        public void Reset ()
        {
            if (object.ReferenceEquals(bigProgress_GS, null))
            {
                progress = 0;
            }
            else
            {
                bigProgress_GS = new SMPNum(0);
            }

			totalTimeSinceCount = 0;
        }
        
    }

[System.Serializable]    
public class SMPQuestData
{
    public List<SMPQuestModel> models;
}
[System.Serializable]
public class MyQuestModel
{
    public string id;
    public bool skippable;
    public bool isDynamic;
}
[System.Serializable]
public class MyProgressModel
{
    
}

    [System.Serializable]
	public class SMPQuestModel
    {
        private static int instanceCounter;
        private int instanceId;

        public int kpiBossLevel;
        public int kpiBossKilled;
        public int kpiGameLevelReward;
        public int kpiGameLevelShouldAppear;

        public string id;
        public int questTitleCode;
        public bool skippable;
        public bool isDynamic;
        public bool isDaily;
        public int level;
        public int skipPrice;
        public bool validated;
        public bool active;
        public bool needToClaim;
        public int tutorialNum;
        public string iconName;
        public List<SMPProgressModel> ordered;
        public List<SMPProgressModel> concurrent;
		public int dynamicAvailable;
		public float questRatio;

		public void UpdateNecessaryInfo (SMPQuestModel model)
        {
            if (id == model.id)
            {
                level = model.level;
                validated = model.validated;
                active = model.active;

                for (int i = 0; i < ordered.Count; i++)
                {
                    if (i < model.ordered.Count)
                    {
                        ordered[i].UpdateNecessaryInfo(model.ordered[i]);
                    }
                }
            }
        }

		public SMPQuestModel Copy ()
        {
            var copy = new SMPQuestModel();
            copy.id = id;
            copy.questTitleCode = questTitleCode;
            copy.skippable = skippable;
            copy.isDynamic = isDynamic;
            copy.isDaily = isDaily;
            copy.level = level;
            copy.skipPrice = skipPrice;
            copy.validated = validated;
            copy.active = active;
            copy.needToClaim = needToClaim;
            copy.tutorialNum = tutorialNum;
            copy.iconName = iconName;
            copy.kpiBossKilled = kpiBossKilled;
            copy.kpiBossLevel = kpiBossLevel;
            ordered.ForEach(p => {
                copy.ordered.Add(p.Copy());
            });
            concurrent.ForEach(p => {
                copy.concurrent.Add(p.Copy());
            });
            return copy;
        }

        public SMPQuestModel()
        {
            instanceId = ++instanceCounter;
            ordered = new List<SMPProgressModel>();
            concurrent = new List<SMPProgressModel>();
        }
        public SMPQuestModel(string fromJsonString)
        {
            instanceId = ++instanceCounter;

            ordered = new List<SMPProgressModel>();
            concurrent = new List<SMPProgressModel>();

            if (!string.IsNullOrEmpty(fromJsonString))
            {
                var root = JSON.Parse(fromJsonString);
                validated = root["validated"].AsBool;
                active = root["active"].AsBool;
                tutorialNum = root["tutorialNum"];
                skippable = root["skippable"].AsBool;
                isDynamic = root["isDynamic"].AsBool;
                isDaily = root["isDaily"].AsBool;
                needToClaim = root["needToClaim"].AsBool;
                skipPrice = root["skipPrice"].AsInt;
                level = root["level"].AsInt;
                questTitleCode = root["questTitleCode"].AsInt;
                id = root["id"];
                iconName = root["iconName"];
				dynamicAvailable = root["dynamicAvailable"].AsInt;
				questRatio = root["questRatio"].AsFloat;

                kpiBossKilled = root["kpiBossKilled"].AsInt;
                kpiBossLevel = root["kpiBossLevel"].AsInt;
                kpiGameLevelReward = root["kpiGameLevelReward"].AsInt;
                kpiGameLevelShouldAppear = root["kpiGameLevelShouldAppear"].AsInt;
                

                var orderedArrayNode = root["ordered"].AsArray;
                foreach(var node in orderedArrayNode.Children)
                {
                    var progressModel = new SMPProgressModel(node.ToString());
                    ordered.Add(progressModel);
                }

                var concurrentArrayNode = root["concurrent"].AsArray;
                foreach (var node in concurrentArrayNode.Children)
                {
                    var progressModel = new SMPProgressModel(node.ToString());
                    concurrent.Add(progressModel);
                }

            }
        }

        public JSONNode SaveToJSON()
        {
            JSONNode node = new JSONObject();
            node["id"] = id;
            node["skippable"] = skippable;
            node["isDynamic"] = isDynamic;
            node["skipPrice"] = skipPrice;
            node["level"] = level;
            node["iconName"] = iconName;
			node["dynamicAvailable"] = dynamicAvailable;
            // node["kpiBossLevel"] = kpiBossLevel;
            node["kpiGameLevelReward"] = kpiGameLevelReward;
            node["kpiGameLevelShouldAppear"] = kpiGameLevelShouldAppear;
            

            JSONNode nodeOrderedArray = new JSONArray();
            for (int i = 0; i < ordered.Count; i++)
                nodeOrderedArray.Add(ordered[i].SaveToJSON());

            node["ordered"] = nodeOrderedArray;

            JSONNode nodeConcurrentdArray = new JSONArray();
            for (int i = 0; i < concurrent.Count; i++)
                nodeConcurrentdArray.Add(concurrent[i].SaveToJSON());

            node["concurrent"] = nodeConcurrentdArray;;
            return node;
        }

        public int GetUniqueId()
        {
            return instanceId;
        }

        public override string ToString()
        {
            return $"Quest id : {instanceId}";
        }

        public void ResetProgress()
        {
            ordered.ForEach(progressModel => {
                progressModel.Reset();
            });
            concurrent.ForEach(progressModel => {
                progressModel.Reset();
            });
        }

		public void PrepareSaveString()
		{
			ordered.ForEach(progressModel => {
				progressModel.PrepareSaveString();
			});
			concurrent.ForEach(progressModel => {
				progressModel.PrepareSaveString();
			});
		}
    }// class SMPQuestModel

	[System.Serializable]
	public class SMPQuestCategorized 
    {
        public List<SMPQuestModel> activeQuests;
        public List<SMPQuestModel> completedQuests;
        public List<SMPQuestModel> dynamicQuests;
        public List<SMPQuestModel> dailyQuests;
        public List<SMPQuestModel> skipQuests;

        public string dailyQuestLastTime;
        public int availableBecomeActiveQuestCounter;

        public SMPQuestCategorized(string jsonString)
        {
            activeQuests = new List<SMPQuestModel>();
            completedQuests = new List<SMPQuestModel>();
            dynamicQuests = new List<SMPQuestModel>();
            dailyQuests = new List<SMPQuestModel>();
            skipQuests = new List<SMPQuestModel>();



            if (!string.IsNullOrWhiteSpace(jsonString) && jsonString != "null")
            {
                try
                {
                    var root = JSONNode.Parse(jsonString);

                    dailyQuestLastTime = root["dailyQuestLastTime"];
                    availableBecomeActiveQuestCounter = root["availableBecomeActiveQuestCounter"];

                    foreach (var item in root["activeQuests"].AsArray.Children)
                    {
                        activeQuests.Add(new SMPQuestModel(item.ToString()));
                    }

                    foreach (var item in root["completedQuests"].AsArray.Children)
                    {
                        completedQuests.Add(new SMPQuestModel(item.ToString()));
                    }

                    foreach (var item in root["dynamicQuests"].AsArray.Children)
                    {
                        dynamicQuests.Add(new SMPQuestModel(item.ToString()));
                    }

                    foreach (var item in root["dailyQuests"].AsArray.Children)
                    {
                        dailyQuests.Add(new SMPQuestModel(item.ToString()));
                    }

                    foreach (var item in root["skipQuests"].AsArray.Children)
                    {
                        skipQuests.Add(new SMPQuestModel(item.ToString()));
                    }
                }
                catch (Exception e)
                {
                    Debug.LogError(e.ToString());
                }
            }
        }

        public JSONNode ToJSON()
        {
            JSONNode node = new JSONObject();

            node["dailyQuestLastTime"] = dailyQuestLastTime;
            node["availableBecomeActiveQuestCounter"] = availableBecomeActiveQuestCounter;

            node["activeQuests"] = new JSONArray();
            activeQuests.ForEach(q => {
                node["activeQuests"].Add(q.SaveToJSON());
            });

            node["completedQuests"] = new JSONArray();
            completedQuests.ForEach(q => {
                node["completedQuests"].Add(q.SaveToJSON());
            });

            node["dynamicQuests"] = new JSONArray();
            dynamicQuests.ForEach(q => {
                node["dynamicQuests"].Add(q.SaveToJSON());
            });

            node["dailyQuests"] = new JSONArray();
            dailyQuests.ForEach(q => {
                node["dailyQuests"].Add(q.SaveToJSON());
            });

            node["skipQuests"] = new JSONArray();
            skipQuests.ForEach(q => {
                node["skipQuests"].Add(q.SaveToJSON());
            });

            return node;
        }

		public void PrepareSaveString()
		{
			activeQuests.ForEach(s => s.PrepareSaveString());
			completedQuests.ForEach(s => s.PrepareSaveString());
			dynamicQuests.ForEach(s => s.PrepareSaveString());
			dailyQuests.ForEach(s => s.PrepareSaveString());
			skipQuests.ForEach(s => s.PrepareSaveString());
		}
    }// class SMPQuestCategorized
//namespace
