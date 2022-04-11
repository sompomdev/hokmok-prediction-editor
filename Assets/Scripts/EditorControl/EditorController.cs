using UnityEngine;

public class EditorController : MonoBehaviour
{
    [SerializeField] private UIController uiController;

	public static EditorController instance;

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

	public SMPNum currentGold
	{
		get
		{
			int num;
			if (!int.TryParse(uiController.inpCurrentGold.text, out num))
			{
				num = 0;
			}
			return new SMPNum(num);
		}
	}

	public SMPNum goldPerUpdateLv
	{
		get
		{
			int num;
			if (!int.TryParse(uiController.inpGoldPerLv.text, out num))
			{
				num = 0;
			}
			return new SMPNum(num);
		}
	}

	public SMPNum goldDrop
	{
		get
		{
			return GetGoldToDrop(GameLv);
		}
	}

	private void Awake()
	{
		instance = this;
	}

	void Start()
    {
        uiController.inpGameLevelNum.text = "1";
        uiController.inpHeroLevelNum.text = "1";
        uiController.inpTapPerSeNum.text = "5";
		uiController.inpCurrentGold.text = "50";
		uiController.inpGoldPerLv.text = "100";
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
		uiController.textGoldDrop.text = goldDrop.ToReadableV2();
        CalculateWhenToDie();
    }

    void CalculateWhenToDie()
    {
        var heroDmg = GetHeroDmg(HeroLv);
        var dps = heroDmg * TapPerSec;
        //Debug.Log($"Hero DPS : {dps}");

        var ghostHp = GetGhostHp(GameLv);
        var secToKillGhost = ghostHp / dps;
        
        var bossHp = GetBossHp(GameLv);
        var secToKillBoss = bossHp / dps;
        
        //Debug.Log($"Ghost die in : {secToKillGhost}");
        //Debug.Log($"Boss die in : {secToKillBoss}");

        uiController.textBossDieIn.text = $"{secToKillBoss} s";
        uiController.textGhosDieIn.text = $"{secToKillGhost} s";
    }
    
	public SMPNum GetTimeToKillBoss()
	{
		return GetTimeToKillBoss(GameLv);
	}

	public SMPNum GetTimeToKillBoss(int gameLv)
	{
		var heroDmg = GetHeroDmg(HeroLv);
		var dps = heroDmg * TapPerSec;
		var bossHp = GetBossHp(gameLv);
		var secToKillBoss = bossHp / dps;
		return secToKillBoss;
	}

	public SMPNum GetTimeToKillGhost()
	{
		return GetTimeToKillGhost(GameLv);
	}

	public SMPNum GetTimeToKillGhost(int gameLv)
	{
		var heroDmg = GetHeroDmg(HeroLv);
		var dps = heroDmg * TapPerSec;
		var ghostHp = GetGhostHp(gameLv);
		var secToKillGhost = ghostHp / dps;
		return secToKillGhost;
	}

	public SMPNum GetCurrentHeroDMG()
	{
		return GetHeroDmg(HeroLv);
	}

    public SMPNum GetHeroDmg(int lv)
    {
        var commonRatio = new SMPNum(SMPMathCore.GetSeriesCommonRatioByLevel(lv, SequenceName.DMGHero));
        var firstTerm = SMPMathCore.GetSeriesFirstTermByLevel(lv, SequenceName.DMGHero);
        return firstTerm * commonRatio.Pow(lv - 1);
    }

    public SMPNum GetBossHp(int lv)
    {
        var commonRatio = new SMPNum(SMPMathCore.GetSeriesCommonRatioByLevel(lv, SequenceName.HPBoss));
        var firstTerm = SMPMathCore.GetSeriesFirstTermByLevel(lv, SequenceName.HPBoss);
        return firstTerm * commonRatio.Pow(lv - 1);
    }

    public SMPNum GetGhostHp(int lv)
    {
        var commonRatio = new SMPNum(SMPMathCore.GetSeriesCommonRatioByLevel(lv, SequenceName.HPGhost));
        var firstTerm = SMPMathCore.GetSeriesFirstTermByLevel(lv, SequenceName.HPGhost);
        return firstTerm * commonRatio.Pow(lv - 1);
    }
	
	private const float PERIOD_OF_TIME_CONVERT = 60;

	public SMPNum GetConvertScoreFromDMGToKillBoss(SMPNum dmg)
	{
		return GetConvertScoreFromDMGToKillBoss(dmg, GameLv);
	}

	public SMPNum GetConvertScoreFromDMGToKillGhost(SMPNum dmg)
	{
		return GetConvertScoreFromDMGToKillGhost(dmg, GameLv);
	}

	public SMPNum GetConvertScoreFromDMGToKillBoss(SMPNum dmg, int gameLv)
	{
		var dps = dmg * TapPerSec;
		var bossHp = GetBossHp(GameLv);
		var secToKillBoss = bossHp / dps;
		return (PERIOD_OF_TIME_CONVERT / secToKillBoss) * goldDrop;
	}

	public SMPNum GetConvertScoreFromDMGToKillGhost(SMPNum dmg, int gameLv)
	{
		var dps = dmg * TapPerSec;
		var ghostHp = GetGhostHp(GameLv);
		var secToKillGhost = ghostHp / dps;
		return (PERIOD_OF_TIME_CONVERT / secToKillGhost) * goldDrop;
	}

	public SMPNum GetCovertScoreFromTime(float time)
	{
		var goldKillGhost = GetConvertScoreFromDMGToKillGhost(GetCurrentHeroDMG());
		return goldKillGhost / time;
	}

	public SMPNum GetCovertScoreFromTime(float time, int gameLv)
	{
		var goldKillGhost = GetConvertScoreFromDMGToKillGhost(GetCurrentHeroDMG(), gameLv);
		return goldKillGhost / time;
	}

	public SMPNum GetCovertScoreFromTime(SMPNum time)
	{
		var goldKillGhost = GetConvertScoreFromDMGToKillGhost(GetCurrentHeroDMG());
		return goldKillGhost / time;
	}

	public SMPNum GetCovertScoreFromTime(SMPNum time, int gameLv)
	{
		var goldKillGhost = GetConvertScoreFromDMGToKillGhost(GetCurrentHeroDMG(), gameLv);
		return goldKillGhost / time;
	}

	public SMPNum GetBattleScoreDefault()
	{
		return GetCovertScoreFromTime(PERIOD_OF_TIME_CONVERT);
	}

	public SMPNum GetGoldToDrop(int gameLv)
	{
		var coins = SMPMathGamePlay.GetUnBaseOnLevel(gameLv, SequenceName.DropCoins);
		return coins;
	}
}
