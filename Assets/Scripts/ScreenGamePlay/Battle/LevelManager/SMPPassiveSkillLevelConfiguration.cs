public static class SMPPassiveSkillLevelConfiguration
{
	public static int GetStageForUnlockNextLevel(int level, int addLevel)
	{
		return (level + addLevel) * 235;
	}

	public static int GetMaxLevelCanUnlockOnStage(int stage, int currentLevel)
	{
		int lvUnlock = (stage / 235) - currentLevel;
		if(lvUnlock < 1)
		{
			return 0;
		}
		return lvUnlock;
	}
}
