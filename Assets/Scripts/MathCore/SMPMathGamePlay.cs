using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMPMathGamePlay 
{
    public static int GetMaxLevelThatCanBuyWithExistingGold(SMPNum _gold, int _currentLv, SequenceName sequenceName)
    {
        int level = 0;
        var sequenceIntervals = SMPMathCore.getSequences(sequenceName);
        for (int i = 0; i < sequenceIntervals.Count; i++)
        {
            var interval = sequenceIntervals[i];

            if (interval.max <= _currentLv)
            {
                continue;
            }

            var cmRatio = SMPMathCore.GetSeriesCommonRatio(i, sequenceName);
            var firstTerm = SMPMathCore.GetSeriesFirstTerm(i, sequenceName);
            var newFirstTerm = firstTerm;
            var newCurrentLv = 0;

            SMPNum cost = new SMPNum(0);
            var levelToGet = 0;
            

            if (i == 0)
            {
                newCurrentLv = _currentLv;
                levelToGet = interval.max - _currentLv;
                cost = SMPMathCore.GeometrySum(levelToGet, firstTerm, cmRatio, _currentLv + 1); ;
            }
            else
            {
                if (_currentLv >= interval.start && _currentLv <= interval.max)
                {
                    levelToGet = interval.max - _currentLv;
                    newCurrentLv = _currentLv - sequenceIntervals[i - 1].max;
                }
                else
                {
                    levelToGet = interval.max - sequenceIntervals[i - 1].max;
                }

                newFirstTerm = GetUnBaseOnLevelAndFirstTerm(interval.start, firstTerm, sequenceName);
                cost = SMPMathCore.GeometrySum(levelToGet, newFirstTerm, cmRatio, newCurrentLv + 1); ;
            }

            //cost.DisplayDetails();

            if (cost < _gold)
            {
                level += levelToGet;
                _gold = _gold - cost;

                //Debug.Log("If cost : =================");
                //cost.DisplayDetails();
                //Debug.Log("If cost : =================");
            }
            else
            {
                var lv = SMPMathCore.GetUnUsingSum(_gold, newFirstTerm, cmRatio, newCurrentLv + 1);
                level += lv;
                //Debug.Log("Level : " + level);
                break;
            }
        }

        return level;
    }


    public static SMPNum GetUnBaseOnLevelAndFirstTerm(int level, SMPNum firstTerm, SequenceName sequenceName)
    {
        var firstTermOfSequence = firstTerm;//new SMPNum(firstTerm);
        var termMatchingLevel = SMPMathCore.GetTermValueForSeries(level, sequenceName);
        var result = termMatchingLevel * firstTermOfSequence;

        return result;

    }

    public static SMPNum GetUnBaseOnLevel(int level, SequenceName sequenceName)
    {
        if (level == 0) return new SMPNum(0);

        var firstTerm = SMPMathCore.GetSeriesFirstTermByLevel(level, sequenceName);
        var result = GetUnBaseOnLevelAndFirstTerm(level, firstTerm, sequenceName);

        return result;

    }

    public static SMPNum SumBaseOnCurrentLvAndTargetLv(int currentLv, int targetLv, SequenceName sequenceName)
    {
        SMPNum sum = new SMPNum();
        var sequenceIntervals = SMPMathCore.getSequences(sequenceName);
        var currentInterval = SMPMathCore.getSequenceIntervalInfoFor(targetLv, sequenceName);


        for (int i = 0; i <= currentInterval.indexInterval; i++)
        {
            //Debug.Log("i : " + i);
            var interval = sequenceIntervals[i];
            if (interval.max <= currentLv)
            {
                continue;
            }

            var cmRatio = SMPMathCore.GetSeriesCommonRatio(i, sequenceName);
            var firstTerm = SMPMathCore.GetSeriesFirstTerm(i, sequenceName);
            var newCurrentLv = 0;

            if (interval.max < targetLv)
            {
                var newFirstTerm = firstTerm;
                int newN = interval.max - currentLv;
                if (i == 0)
                {
                    newCurrentLv = currentLv;
                }
                else
                {
                    if (currentLv >= interval.start && currentLv <= interval.max)
                    {
                        newN = interval.max - currentLv;
                        newCurrentLv = currentLv - sequenceIntervals[i - 1].max;
                    }
                    else
                    {
                        newN = interval.max - sequenceIntervals[i - 1].max;
                    }

                    newFirstTerm = GetUnBaseOnLevelAndFirstTerm(sequenceIntervals[i - 1].max + 1, firstTerm, sequenceName);
                }

                var sumPart = SMPMathCore.GeometrySum(n: newN, firstTerm: newFirstTerm, cmRatio: cmRatio, newCurrentLv + 1);
                sum += sumPart;
            }
            else
            {
                var newFirstTerm = firstTerm;
                int newN = targetLv - currentLv;
                if (i == 0)
                {
                    newCurrentLv = currentLv;
                }
                else
                {
                    if (currentLv >= interval.start && currentLv <= interval.max)
                    {
                        newN = targetLv - currentLv;
                        newCurrentLv = currentLv - sequenceIntervals[i - 1].max;
                    }
                    else
                    {
                        newN = targetLv - sequenceIntervals[i - 1].max;
                    }

                    newFirstTerm = GetUnBaseOnLevelAndFirstTerm(sequenceIntervals[i - 1].max + 1, firstTerm, sequenceName);
                }
                //Debug.Log("New n : " + newN);
                //Debug.Log("newFirstTerm : " + newFirstTerm);
                //Debug.Log("cmRatio : " + cmRatio);
                //Debug.Log("newCurrentLv : " + newCurrentLv);
                var sumPart = SMPMathCore.GeometrySum(n: newN, firstTerm: newFirstTerm, cmRatio: cmRatio, newCurrentLv + 1);
                //Debug.Log("sumPart : " + sumPart);
                sum += sumPart;
            }
        }

        return sum;
    }
    public static SMPNum SumFromTheBeginning(int n, SequenceName sequenceName)
    {
        SMPNum sum = new SMPNum();
        var sequenceIntervals = SMPMathCore.getSequences(sequenceName);
        var currentInterval = SMPMathCore.getSequenceIntervalInfoFor(n, sequenceName);

        for (int i = 0; i <= currentInterval.indexInterval; i++)
        {
            var interval = sequenceIntervals[i];
            var cmRatio = SMPMathCore.GetSeriesCommonRatio(i, SequenceName.CostHero);
            var firstTerm = SMPMathCore.GetSeriesFirstTerm(i, sequenceName);

            if (interval.max < n)
            {
                var newFirstTerm = firstTerm;
                int newN = interval.max;
                if (i > 0)
                {
                    newN = interval.max - sequenceIntervals[i - 1].max;
                    newFirstTerm = GetUnBaseOnLevelAndFirstTerm(sequenceIntervals[i - 1].max + 1, firstTerm, sequenceName);
                }

                var sumPart = SMPMathCore.GeometrySum(n: newN, firstTerm: newFirstTerm, cmRatio: cmRatio);
                sum += sumPart;
            }
            else
            {
                var newFirstTerm = firstTerm;
                int newN = n;
                if (i > 0)
                {
                    newN = n - sequenceIntervals[i - 1].max;
                    newFirstTerm = GetUnBaseOnLevelAndFirstTerm(sequenceIntervals[i - 1].max + 1, firstTerm, sequenceName);
                }

                var sumPart = SMPMathCore.GeometrySum(n: newN, firstTerm: newFirstTerm, cmRatio: cmRatio);
                sum += sumPart;
            }
        }

        return sum;
    }

}//class
