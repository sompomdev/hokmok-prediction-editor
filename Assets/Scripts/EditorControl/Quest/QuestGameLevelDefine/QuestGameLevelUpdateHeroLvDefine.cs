
public class QuestGameLevelUpdateHeroLvDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var levelTarget = questData.target;
		return GetGameLevelFromGoldEarningBallance(1, levelTarget);
	}
}
