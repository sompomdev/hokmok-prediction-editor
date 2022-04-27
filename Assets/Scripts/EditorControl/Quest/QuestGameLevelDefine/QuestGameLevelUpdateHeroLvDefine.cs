
public class QuestGameLevelUpdateHeroLvDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var updateTime = questData.target;
		return GetGameLevelFromGoldEarningBallance(1, updateTime+1);//coz 1 is have ready
	}
}
