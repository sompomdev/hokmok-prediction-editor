
public class QuestGameLevelReachStageDefine : QuestGameLevelBaseDefine
{
	//"Complete [n] Levels in total"
	
	public override int GameLevelDefine()
	{
		//now we can use this for Base Reach Stage, Complete [n]st stage, Beat [n] levels
		//but for the repeating will change
		return questData.target;
	}
}
