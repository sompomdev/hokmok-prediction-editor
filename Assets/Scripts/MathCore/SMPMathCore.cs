using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SequenceName 
{
    CostHero,
    DropCoins,
    CostSupport,
    HPGhost,
    HPBoss,
    DMGHero,
	DMGBoss
}

public class SequenceInterval 
{
    public int start;
    public int max;
    public int indexInterval;

    public SequenceInterval (int s, int m)
    {
        start = s;
        max = m;
    }
}

public class SMPMathCore 
{
    const int K_GAME_INTRO = 0;
    const int K_GAME_TUNNEL_1 = 1;
    const int K_GAME_TUNNEL_2 = 2;
    const int K_GAME_TUNNEL_3 = 3;

	private static bool isDebug = true;

    public static List<SequenceInterval> getSequences(SequenceName sequenceName) {

        List<SequenceInterval> result = new List<SequenceInterval>();

        switch (sequenceName) {
            case SequenceName.CostHero:
            case SequenceName.DropCoins:
            default : 
                result = new List<SequenceInterval>() {
                    // new SequenceInterval(1, 100),
                    // new SequenceInterval(101, 999),
                    // new SequenceInterval(1000, 3000),
                    // new SequenceInterval(3001, 500000)
                    new SequenceInterval(1, 100),
                    new SequenceInterval(101, 1000),
                    new SequenceInterval(1001, 3000),
                    new SequenceInterval(3001, 500000)
                };
            break;
        }
        return result;
    }

    public static SequenceInterval getSequenceIntervalInfoFor(int level, SequenceName sequenceName) {
        var seq = getSequences(sequenceName);
        SequenceInterval result = null;
        if (seq == null) {
            return null;
        }

        for (int i = 0; i < seq.Count; i++)
        {
            var interval = seq[i];
            if (level >= interval.start && level <= interval.max)
            {
                result = interval;
                result.indexInterval = i;
            }
        }

        if ( result == null ) {
            Debug.Log (result);
        }

        return result;
    }

    public static double GetSeriesCommonRatioByLevel(int level, SequenceName seriesName)
    {


        var interval = getSequenceIntervalInfoFor(level, seriesName);
        var indexInterval = interval != null ? interval.indexInterval : -1;

        var r = GetSeriesCommonRatio(indexInterval, seriesName);

        return r;
    }

    public static double GetSeriesCommonRatio(int indexInterval, SequenceName seriesName)
    {

		if(isDebug)
		{
			return SMPRatioDebugData.GetSeriesCommonRatioDebug(indexInterval, seriesName);
		}

        var value = 1.0;

        var r = -1.0;

        if (seriesName == SequenceName.DropCoins)
        {
            switch (indexInterval)
            {
                case K_GAME_INTRO:
                    value = 1.1;
                    break;
                case K_GAME_TUNNEL_1:
                    value = 1.2;
                    break;
                case K_GAME_TUNNEL_2:
                    value = 1.15;
                    break;
                case K_GAME_TUNNEL_3:
                    value = 1.15;
                    break;
                default:
                    value = 1.1;
                    break;
            }

        }
        else if (seriesName == SequenceName.CostHero)
        {

            switch (indexInterval)
            {
                case K_GAME_INTRO:
                    value = 1.1;
                    //value = 2;
                    break;
                case K_GAME_TUNNEL_1:
                    value = 1.25;
                    //value = 3;
                    break;
                case K_GAME_TUNNEL_2:
                    value = 1.327;
                    //value = 4;
                    break;
                case K_GAME_TUNNEL_3:
                    value = 1.327;
                    //value = 5;
                    break;
                default:
                    value = 1.25;
                    //value = 6;
                    break;
            }

        }
        else if (seriesName == SequenceName.CostSupport)
        {
            switch (indexInterval)
            {
                case K_GAME_INTRO:
                    value = 1.05;
                    break;
                case K_GAME_TUNNEL_1:
                    value = 1.1;
                    break;
                case K_GAME_TUNNEL_2:
                    value = 1.15;
                    break;
                case K_GAME_TUNNEL_3:
                    value = 1.18;
                    break;
                default:
                    value = 1.18;
                    break;
            }

        }
        else if (seriesName == SequenceName.HPBoss)
        {
            switch (indexInterval)
            {
                case K_GAME_INTRO:
                    value = 1.04;
                    break;
                case K_GAME_TUNNEL_1:
                    value = 1.06;
                    break;
                case K_GAME_TUNNEL_2:
                    value = 1.08;
                    break;
                case K_GAME_TUNNEL_3:
                    value = 1.12;
                    break;
                default:
                    value = 1.12;
                    break;
            }

        }
        else if (seriesName == SequenceName.HPGhost)
        {
            switch (indexInterval)
            {
                case K_GAME_INTRO:
                    value = 1.02;
                    break;
                case K_GAME_TUNNEL_1:
                    value = 1.03;
                    break;
                case K_GAME_TUNNEL_2:
                    value = 1.04;
                    break;
                case K_GAME_TUNNEL_3:
                    value = 1.06;
                    break;
                default:
                    value = 1.02;
                    break;
            }

        }
        else if (seriesName == SequenceName.DMGHero)
        {
            switch (indexInterval)
            {
                case K_GAME_INTRO:
                    value = 1.075;
                    break;
                case K_GAME_TUNNEL_1:
                    value = 1.095;
                    break;
                case K_GAME_TUNNEL_2:
                    value = 1.1;
                    break;
                case K_GAME_TUNNEL_3:
                    value = 1.2;
                    break;
                default:
                    value = 1.3;
                    break;
            }
        }
		else if (seriesName == SequenceName.DMGBoss)
		{
			switch (indexInterval)
			{
				case K_GAME_INTRO:
					value = 1.075;
					break;
				case K_GAME_TUNNEL_1:
					value = 1.095;
					break;
				case K_GAME_TUNNEL_2:
					value = 1.1;
					break;
				case K_GAME_TUNNEL_3:
					value = 1.2;
					break;
				default:
					value = 1.3;
					break;
			}

		}

		if (value == 1.0)
        {
            throw new Exception("cant have a ratio of 1, will create pb with logbase for interval " + indexInterval + " " + seriesName);
        }
        r = value;

        return r;
    }

    public static SMPNum GetSeriesFirstTermByLevel(int level, SequenceName seriesName)
    {
        var interval = getSequenceIntervalInfoFor(level, seriesName);
        var indexInterval = interval != null ? interval.indexInterval : -1;

        var r = GetSeriesFirstTerm(indexInterval, seriesName);

        return r;
    }

    public static SMPNum GetSeriesFirstTerm(int indexInterval, SequenceName seriesName)
    {
		if(isDebug)
		{
			return SMPNum.FromNum(SMPRatioDebugData.GetFirstTermRatioDebug(indexInterval, seriesName));
		}

        var value = 1.0;

        var firstTerm = 1.0;

        if (seriesName == SequenceName.DropCoins)
        {
            switch (indexInterval)
            {
                case K_GAME_INTRO:
                    value = 1;
                    break;
                case K_GAME_TUNNEL_1:
                    value = 1;
                    break;
                case K_GAME_TUNNEL_2:
                    value = 1;
                    break;
                case K_GAME_TUNNEL_3:
                    value = 1;
                    break;
                default:
                    value = 1;
                    break;
            }

        }
        else if (seriesName == SequenceName.CostHero)
        {

            switch (indexInterval)
            {
                case K_GAME_INTRO:
                    value = 5;
                    break;
                case K_GAME_TUNNEL_1:
                    value = 10;
                    break;
                case K_GAME_TUNNEL_2:
                    value = 15;
                    break;
                case K_GAME_TUNNEL_3:
                    value = 20;
                    break;
                default:
                    value = 25;
                    break;
            }

        }
        else if (seriesName == SequenceName.CostSupport)
        {
            switch (indexInterval)
            {
                case K_GAME_INTRO:
                    value = 5;
                    break;
                case K_GAME_TUNNEL_1:
                    value = 10;
                    break;
                case K_GAME_TUNNEL_2:
                    value = 30;
                    break;
                case K_GAME_TUNNEL_3:
                    value = 40;
                    break;
                default:
                    value = 50;
                    break;
            }

        }
        else if (seriesName == SequenceName.HPGhost)
        {
            switch (indexInterval)
            {
                case K_GAME_INTRO:
                    value = 20;
                    break;
                case K_GAME_TUNNEL_1:
                    value = 30;
                    break;
                case K_GAME_TUNNEL_2:
                    value = 40;
                    break;
                case K_GAME_TUNNEL_3:
                    value = 50;
                    break;
                default:
                    value = 60;
                    break;
            }

        }
        else if (seriesName == SequenceName.HPBoss)
        {
            switch (indexInterval)
            {
                case K_GAME_INTRO:
                    value = 20;
                    break;
                case K_GAME_TUNNEL_1:
                    value = 1000;
                    break;
                case K_GAME_TUNNEL_2:
                    value = 1000;
                    break;
                case K_GAME_TUNNEL_3:
                    value = 1000;
                    break;
                default:
                    value = 1000;
                    break;
            }

        }
        else if (seriesName == SequenceName.DMGHero)
        {
            switch (indexInterval)
            {
                case K_GAME_INTRO:
                    value = 1;
                    break;
                case K_GAME_TUNNEL_1:
                    value = 2;
                    break;
                case K_GAME_TUNNEL_2:
                    value = 3;
                    break;
                case K_GAME_TUNNEL_3:
                    value = 4;
                    break;
                default:
                    value = 5;
                    break;
            }

        }

        firstTerm = value;

        return SMPNum.FromNum(firstTerm);
    }

    public static SMPNum GetTermValueForSeries(int level, SequenceName seriesName)
    {

        var commonRatio = GetSeriesCommonRatioByLevel(level, seriesName);
        if (commonRatio == -1)
        {
            throw new Exception("cant generate series without ratio");
        }
        //Debug.Log("Level : " + level);
        var rPowered = new SMPNum(commonRatio).Pow(level - 1);//SMPNum.pow(commonRatio, level - 1);

        var firstTermOfSequence = new SMPNum(1);

        return firstTermOfSequence * rPowered;
    }

    public static int GetUnUsingSum(SMPNum sum, SMPNum firstTerm, double cmRatio, int current = 1)
    {
        if (current <= 0)
        {
            throw new Exception("Current must be bigger than zero!");
        }
        var u1 = firstTerm;
        var u = u1 * SMPNum.FromNum(cmRatio).Pow(current - 1);
        var first = (sum * (cmRatio - 1) / u + 1);
        var result = first.Log(cmRatio);

        int level = 0;

        if (result.IsIntInifinity())
        {
            level = int.MaxValue;
        }
        else
        {
            //Debug.Log("Level=========================");
            //result.DisplayDetails();
            level = (int)result.ToFloatIfPossible();

            //Debug.Log("Level=========================");
        }
        

        return level;
    }

    public static SMPNum GeometrySum(int n, SMPNum firstTerm, double cmRatio, int current = 1)
    {
        if (current <= 0)
        {
            throw new Exception("Current must be bigger than zero!");
        }

        var u1 = firstTerm;
        var u = u1 * SMPNum.FromNum(cmRatio).Pow(current - 1);
        //var sum = u * ((1 - SMPNum.FromNum(cmRatio).Pow(n)) / (1 - cmRatio ));
        var sum = u * ((SMPNum.FromNum(cmRatio).Pow(n) - 1) / (cmRatio - 1));

        //Debug.Log("Geometry sum : " + sum);

        return sum;
    }
}
