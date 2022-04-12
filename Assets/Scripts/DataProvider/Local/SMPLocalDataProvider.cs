using System.Collections;
using System.Collections.Generic;
//using Sompom.Common;
using UnityEngine;

public class SMPLocalDataProvider 
{
    #region EquipmentItem
    const string equipmentItemFileName = "Data/Equipment/equipmentItems";
	const string heroSlotEquippableDataFileName = "Data/Equipment/heroSlotEquippableData";
	#endregion
	#region INVENTORY
	const string supportDataFileName = "Data/SupportData";
    const string heroDataFileName = "Data/HeroesData";
    const string userPassiveSkillDataFileName = "Data/UserPassiveSkillData";
    const string shopSkillDataFileName = "Data/ShopSkillData";
    const string userSkillDataFileName = "Data/UserSkillData";
    const string heroAndSkillDataFileName = "Data/HeroesAndSkillData";
    const string petDataFileName = "Data/petsdata";
	const string monsterPoisonDataFileName = "Data/enemyPoison";
	const string monsterFreezeDataFileName = "Data/enemyFreeze";
	const string visualEffectDataFileName = "Data/visualEffectDatas";
	const string gameConstanceConfigDataFileName = "Data/gameConstanceConfig";
	const string itemLootDataFileName = "Data/itemLootData";
	//static string petLocaleNameDataFileName {
 //       get {
 //           return "Data/petslocalizename_" + (SMPLocalizeNameLanguage)(GameData.Instance().language);
 //       }
 //   }
    public static string GetEquipmentItemData()
    {
        return GetDataAtPath(equipmentItemFileName);
    }
	public static string GetHeroSlotEquippableData()
	{
		return GetDataAtPath(heroSlotEquippableDataFileName);
	}
    public static string GetSupportData ()
    {
        return GetDataAtPath(supportDataFileName);
    }
    public static string GetHeroData ()
    {
        return GetDataAtPath(heroDataFileName);
    }
    public static string GetUserPassiveSkillData ()
    {
        return GetDataAtPath(userPassiveSkillDataFileName);
    }
    public static string GetShopSkillData ()
    {
        return GetDataAtPath(shopSkillDataFileName);
    }
    public static string GetUserSkillData ()
    {
        return GetDataAtPath(userSkillDataFileName);
    }
    public static string GetHeroAndSkillData ()
    {
        return GetDataAtPath(heroAndSkillDataFileName);
    }
    public static string GetPetData ()
    {
        return GetDataAtPath(petDataFileName);
    }
    //public static string GetPetLocaleNameData ()
    //{
    //    return GetDataAtPath(petLocaleNameDataFileName);
    //}
	public static string GetItemLootData()
	{
		return GetDataAtPath(itemLootDataFileName);
	}
    #endregion

    #region ACHIEVEMENT
    const string achievementDataFileName = "Data/AchievementData";
    public static string GetAchievementData ()
    {
        return GetDataAtPath(achievementDataFileName);
    }
    #endregion

    #region MINI-QUEST
    const string questDataFileName = "Data/Quest/quest_data-31-12-2021"; //"Data/Quest/quest_data";

    const string dailyQuestDataFileName = "Data/Quest/daily_quest_data";
    public static string GetQuestData ()
    {
        return GetDataAtPath(questDataFileName);
    }
    public static string GetDailyQuestData ()
    {
        return GetDataAtPath(dailyQuestDataFileName);
    }
    #endregion

    #region ASSET-BUNDLE
    const string assetBundleGroupRefDataFileName = "Data/AssetbundleGroupRef";
	const string assetWeaponGroupRefDataFileName = "Data/AssetbundleWeaponGroupRef";
	const string assetItemIconGroupRefDataFileName = "Data/AssetbundleItemIconGroupRef";
	const string assetBossGroupRefDataFileName = "Data/AssetbundleBossGroupRef";
	public static string GetAssetBundleGroupRefData ()
    {
        return GetDataAtPath(assetBundleGroupRefDataFileName);
    }
	public static string GetAssetWeaponGroupRefData()
	{
		return GetDataAtPath(assetWeaponGroupRefDataFileName);
	}
	public static string GetAssetItemIconGroupRefData()
	{
		return GetDataAtPath(assetItemIconGroupRefDataFileName);
	}
	public static string GetAssetBossGroupRefData()
	{
		return GetDataAtPath(assetBossGroupRefDataFileName);
	}
	#endregion

	#region ENEMY
	const string enemyByZoneDataFileName = "Data/enemysdatabyzone";
    const string enemyDataFileName = "Data/enemysdata";
    //static string enemyLocaleNameDataFileName {
    //    get {
    //        return "Data/enemyslocalizename_" + (SMPLocalizeNameLanguage)(GameData.Instance().language);
    //    }
    //}
    
    public static string GetEnemyByZoneData ()
    {
        return GetDataAtPath(enemyByZoneDataFileName);
    }
    public static string GetEnemyData ()
    {
        return GetDataAtPath(enemyDataFileName);
    }
    //public static string GetEnemyLocaleNameData ()
    //{
    //    return GetDataAtPath(enemyLocaleNameDataFileName);
    //}
    #endregion

    #region EFFECT
    const string customCombineEffectDataFileName = "Data/customCombinEffectDatas";
    const string supportEffectDataFileName = "Data/supportEffectDatas";
    const string monsterEffectDataFileName = "Data/monsterEffectDatas";
    const string petEffectDataFileName = "Data/petEffectDatas";
    const string unlockHeroEffectDataFileName = "Data/unlockHeroEffectDatas";
    const string heroSlashEffectDataFileName = "Data/heroSlashEffectDatas";
    const string heroAndWeaponDataFileName = "Data/heroAndWeaponDatas";
    const string weaponAndSlashDataFileName = "Data/weaponAndSlashDatas";

    public static string GetCustomCombineEffectData ()
    {
        return GetDataAtPath(customCombineEffectDataFileName);
    }
    public static string GetSupportEffectData ()
    {
        return GetDataAtPath(supportEffectDataFileName);
    }
    public static string GetMonsterEffectData ()
    {
        return GetDataAtPath(monsterEffectDataFileName);
    }
    public static string GetPetEffectData ()
    {
        return GetDataAtPath(petEffectDataFileName);
    }
    public static string GetUnlockHeroEffectData ()
    {
        return GetDataAtPath(unlockHeroEffectDataFileName);
    }
    public static string GetHeroSlashEffectData ()
    {
        return GetDataAtPath(heroSlashEffectDataFileName);
    }
    public static string GetHeroAndWeaponData()
    {
        return GetDataAtPath(heroAndWeaponDataFileName);
    }
    public static string GetWeaponAndSlashData()
    {
        return GetDataAtPath(weaponAndSlashDataFileName);
    }
    public static string GetMonsterPoison()
	{
		return GetDataAtPath(monsterPoisonDataFileName);
	}
	public static string GetMonsterFreeze()
	{
		return GetDataAtPath(monsterFreezeDataFileName);
	}
	public static string GetVisualEffectData()
	{
		return GetDataAtPath(visualEffectDataFileName);
	}
	public static string GetGameConstanceConfigData()
	{
		return GetDataAtPath(gameConstanceConfigDataFileName);
	}
	#endregion

	#region STAGE
	//static string stageLocaleNameData {
 //       get {
 //           return "Data/stageslocalizename_" + (SMPLocalizeNameLanguage)(GameData.Instance().language);
 //       }
 //   }
 //   public static string GetStageLocaleNameData ()
 //   {
 //       return GetDataAtPath(stageLocaleNameData);
 //   }
    #endregion

    private static string GetDataAtPath(string path)
    {
        TextAsset txt = Resources.Load(path) as TextAsset;
        if (txt != null)
            return txt.text;
        return null;
    }
}
