using System;
using System.Collections.Generic;
namespace Sompom.GamePlay.Enemy
{
	public class SMPZoneData
	{
		public int zone_id;
		public string zone_name;
		public string zone_top_bg;
		public string zone_middle_bg;
		public string zone_bottom_bg;
		public List<int> boss;
		public List<int> season_id;
        public List<int> bossOrdering;
		public List<int> ghost;
		public List<int> bossGhost;
		public float mid_bg_y_pos = 0;
		public float top_by_y_pos = 0;
		
		public SMPZoneData ()
		{
            boss = new List<int>();
			season_id = new List<int>();
            bossOrdering = new List<int>();
			ghost = new List<int>();
			bossGhost = new List<int>();
		}
	}
}

