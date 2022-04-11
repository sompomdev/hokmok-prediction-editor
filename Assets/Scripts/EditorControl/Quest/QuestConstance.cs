using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class QuestConstance
{
	public const float TAP_PER_SECOND = 4;
	public const int GHOST_PER_WAVE = 9;
	public const int STAGE_COUNTER_PRE_REACH = 1;

	public static int HeroLevelSkillUnlock(int skillId)
	{
		switch (skillId)
		{
			case 0:
				return 50;

			case 1:
				return 100;

			case 2:
				return 200;

			case 3:
				return 300;

			case 4:
				return 400;

			case 5:
				return 500;

			case 6:
				return 510;

			case 7:
				return 520;

			case 8:
				return 530;

			case 10:
				return 30;
		}

		return 0;
	}

	public static SMPNum HeroSkillCostUnlock(int skillId)
	{
		switch (skillId)
		{
			case 0:
				return new SMPNum(1) * 2790;

			case 1:
				return new SMPNum(1) * 103730;

			case 2:
				return new SMPNum(1) * 143470000;

			case 3:
				return new SMPNum(1) * 1750;

			case 4:
				return new SMPNum(1) * 1750;

			case 5:
				return new SMPNum(1) * 1750;

			case 6:
				return new SMPNum(1) * 1750;

			case 7:
				return new SMPNum(1) * 1750;

			case 8:
				return new SMPNum(1) * 1750;

			case 10:
				return new SMPNum(1) * 1750;
		}

		return new SMPNum(0);
	}
}
