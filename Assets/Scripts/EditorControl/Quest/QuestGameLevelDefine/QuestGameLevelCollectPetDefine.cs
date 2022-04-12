
public class QuestGameLevelCollectPetDefine : QuestGameLevelBaseDefine
{
	private int maxPet = 39;

	public override int GameLevelDefine()
	{
		var petUnlockTarget = questData.target;
		return GetGameLevelPetUnlock(petUnlockTarget);
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
