
public class QuestGameLevelUpdateHeroLvDefine : QuestGameLevelBaseDefine
{
	public override int GameLevelDefine()
	{
		var levelTarget = questData.target;
		var gameLv = 0;
		var dmgBalance = new SMPNum();
		var dmgTarget = EditorController.instance.GetHeroDmg(levelTarget);
		do
		{
			gameLv++;
			//var hp = EditorController.instance.GetBossHp(gameLv);
			var hp = EditorController.instance.GetGhostHp(gameLv);
			var tap = EditorController.instance.TapPerSec;
			dmgBalance = hp / (QuestConstance.TAP_PER_SECOND * tap);
		}
		while (dmgBalance < dmgTarget);

		return gameLv;
	}
}
