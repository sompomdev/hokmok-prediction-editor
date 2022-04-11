
public class QuestGameLevelCollectPetDefine : QuestGameLevelBaseDefine
{
	private int maxPet = 39;

	public override int GameLevelDefine()
	{
		var petUnlockTarget = questData.target;
		int lvUnlock = 0;
		if(petUnlockTarget < 10)
		{
			//under 100 gamelevel => unlock 1 pet per 10 level
			lvUnlock = petUnlockTarget * 10;
		}
		else
		{
			//upper 100 gamelevel => unlock 1 pet per 100 level
			//minus 9 pecause we got 9 pet will unlock before 100 game level ready
			lvUnlock = (petUnlockTarget - 9) * 100;
		}
		return lvUnlock;
	}

	/*formula unlock egg
	public void OnBossDeath(int gameLv)
	{
		gameLv = gameLv + 1;
		if (gameLv < 100)
		{
			if (gameLv % 10 == 0)
			{
				CheckAvailableEggToDrop();
			}
		}
		else
		{
			if (gameLv % 100 == 0)
			{
				CheckAvailableEggToDrop();
			}
		}
	}*/
}
