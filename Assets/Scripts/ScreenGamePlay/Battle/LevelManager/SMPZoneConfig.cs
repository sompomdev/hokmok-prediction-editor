using UnityEngine;

public static class SMPZoneConfig
{
    public static int GetZoneId (int zoneIndex)
    {
        if (zoneIndex >= SMPQuestTemplateConstance.MAX_ZONE)
        {
            int timeOfBigger = Mathf.FloorToInt(zoneIndex / SMPQuestTemplateConstance.MAX_ZONE);
            zoneIndex = zoneIndex - (SMPQuestTemplateConstance.MAX_ZONE * timeOfBigger);
        }
        int zoneID = zoneIndex + 1;

        return zoneID;
    }

    public static string GetZoneName(int zoneID)
    {
        int timeOfBigger = 0;
        int zoneIndex = zoneID - 1;
        if (zoneIndex >= SMPQuestTemplateConstance.MAX_ZONE)
        {
            timeOfBigger = Mathf.FloorToInt(zoneIndex / SMPQuestTemplateConstance.MAX_ZONE);
            zoneIndex = zoneIndex - (SMPQuestTemplateConstance.MAX_ZONE * timeOfBigger);
        }
        zoneID = zoneIndex + 1;
        var zoneData = EditorDatas.instance.GetZoneData(zoneID);
        string areaName = zoneData.zone_name;
        bool isrounding = timeOfBigger > 0;
        if (isrounding)
        {
            areaName = areaName + " " + timeOfBigger;   
        }

        return areaName;
    }
}