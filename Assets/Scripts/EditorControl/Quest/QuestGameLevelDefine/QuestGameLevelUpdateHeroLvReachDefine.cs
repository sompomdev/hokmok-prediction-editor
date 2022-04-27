
public class QuestGameLevelUpdateHeroLvReachDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var levelTarget = questData.target;
		return GetGameLevelFromGoldEarningBallance(1, levelTarget);
	}
}
