using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGameLevelClearNBoss : QuestGameLevelBaseDefine
{

    //Clear [n] boss monsters
	
    public override int GameLevelDefine()
    {
        var missionCount = questData.target;
        var gameLevel = missionCount;//one level for one mission or one Boss
        return gameLevel;
    }
}
