using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMPQuestScrollViewControl : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private RectTransform content;
    private SMPGameLanguage gameLangauge;

    private void Awake()
    {
        gameLangauge = new SMPGameLanguage();
    }

    public void RefreshData(List<SMPQuestModel> models)
    {
        for (int i = 0; i < models.Count; i++)
        {
            var progress = models[i].ordered[0];
            foreach (Transform itemUI in content)
            {
                var itemScript = itemUI.GetComponent<SMPQuestItemList>();
                if (itemScript.Matching(models[i].id))
                {
                    itemScript.SetTitle(GetDescription(progress));
                    itemScript.SetGameLevel( models[i].kpiGameLevelReward > 0 ? "Rewarded at Lv" + models[i].kpiGameLevelReward .ToString() : "?");
                }
            }
        }
    }
    public void RefreshContent (List<SMPQuestModel> models)
    {
        var itemHeight = 100.0f;
        var space = 5.0f;

        for (int i = 0; i < models.Count; i++)
        {
            var progress = models[i].ordered[0];
            var newItem = Instantiate(prefab, content);
            newItem.transform.localScale = Vector3.one;
            newItem.SetActive(true);
            var script = newItem.GetComponent<SMPQuestItemList>();
            script.SetTitle(GetDescription(progress));
            script.SetGameLevel( models[i].kpiGameLevelReward  > 0 ? "Rewarded at Lv" + models[i].kpiGameLevelReward .ToString() : "?");
            script.SetQuestId(models[i].id);
        }
        
        content.sizeDelta = new Vector2(content.sizeDelta.x, itemHeight * models.Count + space * models.Count);
    }
    
    private string GetDescription (SMPProgressModel model)
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
                // var pet = GameSystem.Instance().gameControl.inventoryTapController.PetControl.petDatas.Find(p =>p.petID == model.petId);
                // if (pet != null)
                // {
                //     description = description.Replace("[pet_name]", pet.petName);
                // }
                
            }

            if (description.Contains("[world_name]"))
            {
                // var zoneData = GameData.Instance().gameDataHelper.GetZoneDataById(model.target);
                // description = description.Replace("[world_name]", zoneData.zone_name);
            }

            return description;
        }

    
}
