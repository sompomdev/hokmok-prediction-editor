using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class QuestConstance
{
	public const float KILL_PER_SECOND = 4;
	public const int GHOST_PER_WAVE = 9;
	public const int STAGE_COUNTER_PRE_REACH = 1;

	public const int GHOST_FARM_PER_QUEST = 10;

	public const int UNLOCK_HERO_STAGE_COUNT = 10;
	public const int MAX_HERO = 8;
	public const int MAX_SUPPORT = 20;
	public const int MAX_ACTIVE_SUPPORT = 4;
	public const int MAX_FLYING_SUPPORT = 4;

	public const float TIME_PER_BOSS = 4;
	public const float TIME_PER_GHOST = 1;

	public const int STAGE_TO_DROP_ONE_DIAMOND = 10;
	public const int DIAMOND_GAME_STARTUP = 90;

	public const int MAX_ZONE = 102;
	public const int MAX_LEVEL_ON_STAGE = 10;
	public const int STAGE_COUNTER_PRE_WORLD_REACH = 2;

	public const float TIME_PER_BIRD_APPEAR = 70; //from [40,100]
	public const float PERCENT_NOT_VIDEO_BIRD = 0.5f;
	public const float PERCENT_NOT_DIAMOND_BIRD = 0.9f;

	public const float AVERAGE_SECOND_PER_LUNCH_GAME = 1800;// 30 minutes

	public const float MANA_POTION_DURATION_COOL_DOWN = 12 * 3600; //12 hours in seconds
}
