using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorController : MonoBehaviour
{
    [SerializeField] private UIController uiController;

    public int GameLv
    {
        get
        {
            int num;
            if (!int.TryParse(uiController.inpGameLevelNum.text, out num))
            {
                num = 1;
            }

            return num;
        }
    }
    public int HeroLv
    {
        get
        {
            int num;
            if (!int.TryParse(uiController.inpHeroLevelNum.text, out num))
            {
                num = 1;
            }

            return num;
        }
    }
    public int TapPerSec
    {
        get
        {
            int num;
            if (!int.TryParse(uiController.inpTapPerSeNum.text, out num))
            {
                num = 5;
            }

            return num;
        }
    }
    
    
    void Start()
    {
        uiController.inpGameLevelNum.text = "1";
        uiController.inpHeroLevelNum.text = "1";
        uiController.inpTapPerSeNum.text = "5";
    }

    public void OnLevelNumChanged(string value)
    {
        RefreshStat();
    }
    public void OnHeroLevelNumChanged(string value)
    {
        RefreshStat();
    }
    public void OnTapPerSecNumChanged(string value)
    {
        CalculateWhenToDie();
    }

    void RefreshStat()
    {
        uiController.textBossHp.text = GetBossHp(GameLv).ToReadableV2();
        uiController.textGhostHp.text = GetGhostHp(GameLv).ToReadableV2();
        uiController.textHeroDmg.text = GetHeroDmg(HeroLv).ToReadableV2();
        CalculateWhenToDie();
    }

    void CalculateWhenToDie()
    {
        var heroDmg = GetHeroDmg(HeroLv);
        var dps = heroDmg * TapPerSec;
        Debug.Log($"Hero DPS : {dps}");

        var ghostHp = GetGhostHp(GameLv);
        var secToKillGhost = ghostHp / dps;
        
        var bossHp = GetBossHp(GameLv);
        var secToKillBoss = bossHp / dps;
        
        Debug.Log($"Ghost die in : {secToKillGhost}");
        Debug.Log($"Boss die in : {secToKillBoss}");

        uiController.textBossDieIn.text = $"{secToKillBoss} s";
        uiController.textGhosDieIn.text = $"{secToKillGhost} s";
    }
    
    
    SMPNum GetHeroDmg(int lv)
    {
        var commonRatio = new SMPNum(SMPMathCore.GetSeriesCommonRatioByLevel(lv, SequenceName.DMGHero));
        var firstTerm = SMPMathCore.GetSeriesFirstTermByLevel(lv, SequenceName.DMGHero);
        return firstTerm * commonRatio.Pow(lv - 1);
    }
    SMPNum GetBossHp(int lv)
    {
        var commonRatio = new SMPNum(SMPMathCore.GetSeriesCommonRatioByLevel(lv, SequenceName.HPBoss));
        var firstTerm = SMPMathCore.GetSeriesFirstTermByLevel(lv, SequenceName.HPBoss);
        return firstTerm * commonRatio.Pow(lv - 1);
    }
    SMPNum GetGhostHp(int lv)
    {
        var commonRatio = new SMPNum(SMPMathCore.GetSeriesCommonRatioByLevel(lv, SequenceName.HPGhost));
        var firstTerm = SMPMathCore.GetSeriesFirstTermByLevel(lv, SequenceName.HPGhost);
        return firstTerm * commonRatio.Pow(lv - 1);
    }
}
