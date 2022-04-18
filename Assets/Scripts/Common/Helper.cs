//----------------------------------------------------------------------------------------------------------------//
	/*
	 *		Name			: Helper
	 *		Create Date		:	01-03-2016
	 *		Modified		:	01-03-2016
	 *		Author			:	Ly Ratana
	 *		Author Modify	:	Ly Ratana
	 *		Sumary			: 	Function use as genreral.
	*/
//----------------------------------------------------------------------------------------------------------------//

using UnityEngine;
using System.Collections.Generic;
//using Sompom.Common;
//using Sompom.GamePlay;
using Sompom.Inventory;
//using CureType = SMPItemGamePlayImpactCureFreezePoisonSheep.CureType;

#if UNITY_IOS
using UnityEngine.iOS;
#endif

public class Helper
{

	public static bool IsTablet
	{
		get
		{
#if UNITY_ANDROID
			float yInches = DisplayMetricsAndroid.HeightPixels / DisplayMetricsAndroid.YDPI;
			float xInches = DisplayMetricsAndroid.WidthPixels / DisplayMetricsAndroid.XDPI;
			double diagonalInches = Mathf.Sqrt((xInches * xInches) + (yInches * yInches));

			if (diagonalInches >= 6.5f)
			{
				return true;
			}
			else
			{
				return false;
			}
#else
				string model = SystemInfo.deviceModel;
				return (model.Contains("iPad") || model.Contains("iPhone4"));
#endif
		}
	}

	private static string get_level = "";
	public static string GetLevelString(double level, int lenght)
	{
		get_level = "";
		char[] str_level = level.ToString().ToCharArray();

		for (int i = 0; i < lenght - str_level.Length; i++)
		{
			get_level += "0";
		}
		get_level += level.ToString();
		return get_level;
	}

	public static Color GetColor()
	{
		try
		{
			string hex = COLOR_HEX[Random.Range(0, COLOR_HEX.Length)];

			byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
			byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
			byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
			return new Color32(r, g, b, 255);
		}
		catch (System.Exception e)
		{
			Debug.Log("error : " + e.Message);
			return Color.gray;

		}

	}

	public static Color HexToColor(string hex)
	{
		try
		{
			byte r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
			byte g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
			byte b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
			return new Color32(r, g, b, 255);
		}
		catch (UnityException e)
		{
			Debug.Log(e.Message);
			return Color.blue;
		}
	}

	public static List<T> Shuffle<T>(List<T> list) {
		int n = list.Count;
		System.Random rnd = new System.Random();
		while (n > 1) {
			int k = (rnd.Next(0, n) % n);
			n--;
			T value = list[k];
			list[k] = list[n];
			list[n] = value;
		}
		return list;
	}

	public static string GetHeroWingSpriteName(int level)
	{
		if (level < 500)
		{
			return "";
		}
		else
		{
			if (level < 5000)
			{
				return "wing_bronze_right";
			}
			else if (level < 10000)
			{
				return "wing_silver_right";
			}
			else if (level < 15000)
			{
				return "wing_gold_right";
			}
			else
			{
				return "wing_platinium_right";
			}
		}
	}
	public static RankType GetHeroRankTYPE(int level)
	{
		if (level < 500)
		{
			return RankType.NONE;
		}
		else
		{
			if (level < 5000)
			{
				return RankType.BRONZE;
			}
			else if (level < 10000)
			{
				return RankType.SILVER;
			}
			else if (level < 15000)
			{
				return RankType.GOLD;
			}
			else
			{
				return RankType.PLATINIUM;
			}
		}
	}
	public static int GetHeroMinLevelMatchingRankType (RankType rankType)
	{
		switch(rankType)
		{
			case RankType.NONE:
			return 1;

			case RankType.BRONZE:
			return 500;

			case RankType.SILVER:
			return 5000;

			case RankType.GOLD:
			return 10000;

			case RankType.PLATINIUM:
			return 15000;

			default:
			return 1;
		}
	}
	public static RankType GetSupportRankTYPE(int level)
	{
		if (level < 1111)
		{
			return RankType.NONE;
		}
		else
		{
			if (level < 2222)
			{
				return RankType.BRONZE;
			}
			else if (level < 5555)
			{
				return RankType.SILVER;
			}
			else if (level < SMPConstanceMaxLevel.SUPPORT_MAX_LEVEL)
			{
				return RankType.GOLD;
			}
			else
			{
				return RankType.PLATINIUM;
			}
		}
	}

	public static int GetSupportMinLevelMatchingRankType (RankType rankType)
	{
		switch(rankType)
		{
			case RankType.NONE:
			return 1;

			case RankType.BRONZE:
			return 1111;

			case RankType.SILVER:
			return 2222;

			case RankType.GOLD:
			return 5555;

			case RankType.PLATINIUM:
			return SMPConstanceMaxLevel.SUPPORT_MAX_LEVEL;

			default:
			return 1;
		}
	}
	
	public static ItemColorType[] GetItemColorByBattleShortType(ItemBattleShortcutType type)
	{
		ItemColorType[] colors = null;
		switch (type)
		{
			case ItemBattleShortcutType.defense:
				colors = new ItemColorType[] {ItemColorType.orange, ItemColorType.purple };
				break;
			case ItemBattleShortcutType.attack:
				colors = new ItemColorType[] { ItemColorType.orange, ItemColorType.rouge };
				break;
			case ItemBattleShortcutType.health:
				colors = new ItemColorType[] { ItemColorType.blue, ItemColorType.green, ItemColorType.brown };
				break;
		}
		return colors;
	}

	public static int GetBoarderRankIndex(HERO_COLOR color, int level)
	{
		if(color == HERO_COLOR.HERO)
		{
			if (level < 500)
			{
				//before have a wing we use the index zero
				return 0;
			}
			else
			{
				//test rule, just 500 levels increase one rank
				int index = 1 + Mathf.FloorToInt((level - 500) * 1.0f / 500f);

				int maxRank = 9;
				index = Mathf.Min(maxRank, index);
				return index;
			}
		}
		else
		{
			if (level < 1111)
			{
				//before have a wing we use the index zero
				return 0;
			}
			else
			{
				//test rule, just 1111 levels increase one rank
				int index = 1 + Mathf.FloorToInt((level - 1111) * 1.0f / 1111);

				int maxRank = 8;
				index = Mathf.Min(maxRank, index);
				return index;
			}
		}
	}
	
	public static Color GetColorForButton(int index)
	{
		var color = Color.white;
		if (index == 2)
		{
			color.a = 0.4f;
		}

		return color;
	}

	public static Color GetColorForHexButton(int index)
	{
		var color = Helper.HexToColor(Helper.HOK_MOK_COLOR_HEX_FOR_BUTTON[index]);
		if (index == 2)
		{
			color.a = 0.4f;
		}

		return color;
	}

	public static string COLOR_FREEZE_PROPERTY_COLOR
	{
		get
		{
			return "B6EEF9";
		}
	}

	public static string COLOR_FREEZE_TINT_COLOR
	{
		get
		{
			return "05A8EA";
		}
	}

	public static string COLOR_POISON_PROPERTY_COLOR
	{
		get
		{
			return "88FF3D";
		}
	}

	public static string COLOR_POISON_TINT_COLOR
	{
		get
		{
			return "097B17";
		}
	}

	public static string[] HOK_MOK_COLOR_HEX_FOR_BUTTON = new string[]
	{
		"029292",//Hire
		"8B961C",//lv update
		"000000",//deactive
		"ff9000",//unlock
		"7F32A0",//store
		"029292",//change
		"DF8B1D" //store_gold
	};

	public static string[] HOK_MOK_COLOR_HEX_FOR_HERO_AVATAR_BOARDER = new string[]
	{
		"ee3524",//RED
		"FFFFFF",
		"FFFFFF",
		"007eff",//BLUE
		"ffb229",//orange
		"5b00b0"//PURPLE
	};

	public static string[] HOK_MOK_COLOR_HEX_FOR_BG_ELEMENT = new string[]
	{
		"182338",
		"131C2E"
	};

	public static Color[] HOK_MOK_COLOR_HEX_FOR_BG_SUBHEADER = new Color[]
	{
		new Color(0,0,0,0.37f)
	};
	
	public static string[] HOK_MOK_COLOR_HEX_HP_PROGROGRESS = new string[]
	{
		"5CA811",
		"F5A106",
		"FF0000"
	};

	public static string[] HOK_MOK_COLOR_HEX_PET_SUPPORT_TEAM_ELEMENT_COLOR = new string[]
	{
		"FF9000",
		"64C1E5",
		"FF4200"
	};

	public static string GetHexHeroSkillColorById(int id)
	{
		switch (id)
		{
			case 0:
				return "D14422FF";
			case 1:
				return "7bc416FF";
			case 2:
				return "A653F1FF";
			case 3:
				return "009be4FF";
			case 4:
				return "ff8814FF";
			case 5:
				return "FFCE53FF";
			case 6:
				return "009be4FF";
			case 7:
				return "009be4FF";
			case 8:
				return "009be4FF";
			case 10:
				return "b62b08FF";
			default:
				return "FFFFFF";
		}
	}

	public static string GetHexHeroSkillTopColorById(int id)
	{
		switch (id)
		{
			case 0:
				return "F5431FFF";
			case 1:
				return "79B72EFF";
			case 2:
				return "A817C7FF";
			case 3:
				return "009EE8FF";
			case 4:
				return "FE8915FF";
			case 5:
				return "FFCC00FF";
			case 6:
				return "009EE8FF";
			case 7:
				return "009EE8FF";
			case 8:
				return "009EE8FF";
			case 10:
				return "F5431FFF";
			default:
				return "FFFFFF";
		}
	}

	public static string GetHexHeroSkillBottomColorById(int id)
	{
		switch (id)
		{
			case 0:
				return "F15D0CFF";
			case 1:
				return "B5CE0AFF";
			case 2:
				return "BC1BE4FF";
			case 3:
				return "00CAE8FF";
			case 4:
				return "FEA915FF";
			case 5:
				return "FFF600FF";
			case 6:
				return "00CAE8FF";
			case 7:
				return "00CAE8FF";
			case 8:
				return "00CAE8FF";
			case 10:
				return "F15D0CFF";
			default:
				return "FFFFFF";
		}
	}

	public static MoveAroundProperty GetBallPropertyHeroSkill(int id)
	{
		MoveAroundProperty property = new MoveAroundProperty();
		switch(id)
		{
			case 0:
				property.rotateDirection = new Vector3(-7, 0, 185);
				property.rotateY = 0;
				break;
			case 1:
				property.rotateDirection = new Vector3(0, 0, 0);
				property.rotateY = 173.256f;
				break;
			case 2:
				property.rotateDirection = new Vector3(-7, 0, 0);
				property.rotateY = 0;
				break;
			case 3:
				property.rotateDirection = new Vector3(-7, 0, 185);
				property.rotateY = 0;
				break;
			case 4:
				property.rotateDirection = new Vector3(-7, 0, 25);
				property.rotateY = 0;
				break;
			case 5:
				property.rotateDirection = new Vector3(0, 0, 0);
				property.rotateY = 173.256f;
				break;
			case 6:
				property.rotateDirection = new Vector3(-7, 0, 200);
				property.rotateY = 0;
				break;
			case 7:
				property.rotateDirection = new Vector3(-7, 0, 15);
				property.rotateY = 0;
				break;
			case 8:
				property.rotateDirection = new Vector3(-7, 0, 25);
				property.rotateY = 0;
				break;
			default:
				property.rotateDirection = new Vector3(0, 0, 0);
				property.rotateY = 0;
				break;
		}
		return property;
	}

	public static string GetHexColorByFruitType(int type)
	{
		switch (type)
		{
			case 0:
				return "FD1800FF";
			case 1:
				return "CB985EFF";
			case 2:
				return "386418FF";
			case 3:
				return "007994FF";
			case 4:
				return "DE6E00FF";
			case 5:
				return "9D00FDFF";
			case 6:
				return "221F1FFF";
			default:
				return "FFFFFF";
		}
	}

	public static Color GetColorByFruitType(int type)
	{
		string hex = GetHexColorByFruitType(type);
		byte r, g, b;
		r = byte.Parse(hex.Substring(0, 2), System.Globalization.NumberStyles.HexNumber);
		g = byte.Parse(hex.Substring(2, 2), System.Globalization.NumberStyles.HexNumber);
		b = byte.Parse(hex.Substring(4, 2), System.Globalization.NumberStyles.HexNumber);
		return new Color32(r, g, b, 255);
	}

	public static string[] COLOR_HEX =new string[]
	{
		"00AC92",
		"EF4D4E",
		"40979F",
		"D93C06",
		"6C2B49",
		"C63D6F",
		"69979A",
		"1983CD",
		"CB3754",
		"DC557B",
		"64A242",
		"543D3D",
		"C15179",
		"223556",
		"1979AA",
		"5B3F89",
		"D24737",
		"BF67AB",
		"00C895",
		"DD3E00",
		"5D68BD",
		"B6351B",
		"169A70",
		"41639E",
		"A94D28",
		"1C609C",
		"DB6B6B",
		"900058",
		"DE6534",
		"D6B836",
		"C82E44",
		"538DCE",
		"3B8C1E",
		"13B2F4",
		"E75257",
		"F4811F",
		"97C52A",
		"1C8DAF",
		"DD9A18",
		"CF4040",
		"15B4BD",
		"D1406C",
		"FB4B27",
		"7A88D0",
		"FDA44D",
		"D59B00",
		"49BDB7",
		"E85032",
		"965BA5",
		"62A9DF",
		"c75019",
		"245E93",
		"3798D3",
		"592705",
		"34BC98",
		"E94C3D",
		"D15418",
		"4BBA6E",
		"2794B4",
		"009AB5",
		"5F67D3",
		"FA3743",
		"BC2D36",
		"9B7A63",
		"DE5C42",
		"D87447",
		"FF8E50",
		"5580A6",
		"F49C14",
		"FC8A52",
		"025092",
		"B1B800",
		"D54C42",
		"CF9B70",
		"65885F",
		"27BD7E",
		"A5C257",
		"FA2B0B",
		"FB6A3F",
		"F78F11",
		"219B9C",
		"EBA23F",
		"15A58F",
		"ED3A54",
		"DC2A42",
		"FF901A",
		"B92E6C",
		"8554B5",
		"E50E13",
		"235ED3",
		"5D54B2",
		"911AB9",
		"B54B76",
		"6E48B9",
		"EC4F3D",
		"FB8A00",
		"E31231",
		"FF6A68",
		"007AFF",
		"E24C34",
		"7E7EC6",
		"FF6432",
		"00BFC0",
		"5523B7",
		"E14B4B",
		"00A4E8",
		"CA0D13",
		"B25900",
		"00B8A7",
		"BF0006",
		"E16337",
		"E96F2C",
		"D85900",
		"FF9337",
		"F3894F",
		"EA3852",
		"5A7816",
		"405D0",
	};

	public class MoveAroundProperty
	{
		public float rotateY;
		public Vector3 rotateDirection;
	}
}
