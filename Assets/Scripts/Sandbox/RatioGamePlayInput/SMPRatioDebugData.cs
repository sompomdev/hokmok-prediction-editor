using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//using Sompom.Common;

public static class SMPRatioDebugData
{
	const int K_GAME_INTRO = 0;
	const int K_GAME_TUNNEL_1 = 1;
	const int K_GAME_TUNNEL_2 = 2;
	const int K_GAME_TUNNEL_3 = 3;

	private static bool IsInitDebug
	{
		get
		{
			return PlayerPrefs.GetInt("SMP_IsInitDebug", 0) == 1;
		}
		set
		{
			PlayerPrefs.SetInt("SMP_IsInitDebug", value ? 1 : 0);
		}
	}

	public static float GetSeriesCommonRatioDebug(int indexInterval, SequenceName seriesName)
	{
		//Debug.Log("Exit SeriesCommon_" + seriesName + indexInterval);
		//return PlayerPrefs.GetFloat("SeriesCommon_" + seriesName + indexInterval, 0);
		return GetRatioFromDictionary("SeriesCommon_" + seriesName + indexInterval);
	}

	public static void SetSeriesCommonRatioDebug(int indexInterval, SequenceName seriesName, float ratio)
	{
		PlayerPrefs.SetFloat("SeriesCommon_" + seriesName + indexInterval, ratio);
		SetRatioToDictionary("SeriesCommon_" + seriesName + indexInterval, ratio);
	}

	public static float GetFirstTermRatioDebug(int indexInterval, SequenceName seriesName)
	{
		//Debug.Log("Exit FirstTerm_" + seriesName + indexInterval);
		//return PlayerPrefs.GetFloat("FirstTerm_" + seriesName + indexInterval, 0);
		return GetRatioFromDictionary("FirstTerm_" + seriesName + indexInterval);
	}

	public static void SetFirstTermRatioDebug(int indexInterval, SequenceName seriesName, float ratio)
	{
		PlayerPrefs.SetFloat("FirstTerm_" + seriesName + indexInterval, ratio);
		SetRatioToDictionary("FirstTerm_" + seriesName + indexInterval, ratio);
	}

	public static void SetRatioConfigByKey(string key, float ratio)
	{
		string pre = "";
		if(key.Contains("Common"))
		{
			key = key.Replace(" Common", "");
			pre = "SeriesCommon_";
		}
		else
		{
			key = key.Replace(" FirstTerm", "");
			pre = "FirstTerm_";
		}
		if(key.Contains("_INTRO"))
		{
			key = key.Replace("_INTRO", "0");
		}
		else if(key.Contains("_TUNNEL_"))
		{
			key = key.Replace("_TUNNEL_", "");
		}
		else
		{
			key = key.Replace("_DEFAULT", "4");
		}

		string keyType = pre + key;
		if(PlayerPrefs.GetFloat(keyType,-1000) == 0)
		{
			Debug.LogError("NotExit: "+ keyType);
		}
		else
		{
			PlayerPrefs.SetFloat(keyType, ratio);
			SetRatioToDictionary(keyType, ratio);
		}
	}

	public static float GetRatioFromDictionary(string key)
	{
		var dic = new Dictionary<string, float>(); //GameData.Instance().ratioConfigDic;
		if(!dic.ContainsKey(key))
		{
			dic.Add(key,PlayerPrefs.GetFloat(key, 0));
		}
		return dic[key];
	}

	public static void SetRatioToDictionary(string key, float ratio)
	{
		var dic = new Dictionary<string, float>();//GameData.Instance().ratioConfigDic;
		if (!dic.ContainsKey(key))
		{
			dic.Add(key, PlayerPrefs.GetFloat(key, 0));
		}
		else
		{
			dic[key] = ratio;
		}
	}

	public static void InitializeDebugData()
	{
		if (IsInitDebug) return;

		ResetInitData();

		IsInitDebug = true;
	}

	public static void ResetInitData()
	{
		for (int kTunnel = 0; kTunnel < 5; kTunnel++)
		{
			for (int series = 0; series < 7; series++)
			{
				var seriesName = (SequenceName)series;
				SetSeriesCommonRatioDebug(kTunnel, seriesName, GetInitSeriesCommonRatio(kTunnel, seriesName));
				SetFirstTermRatioDebug(kTunnel, seriesName, GetInitSeriesFirstTermRatio(kTunnel, seriesName));
			}
		}
	}

	private static float GetInitSeriesCommonRatio(int indexInterval, SequenceName seriesName)
	{
		var value = 1.0f;

		var r = -1.0f;

		if (seriesName == SequenceName.DropCoins)
		{
			switch (indexInterval)
			{
				case K_GAME_INTRO:
					value = 1.1f;
					break;
				case K_GAME_TUNNEL_1:
					value = 1.2f;
					break;
				case K_GAME_TUNNEL_2:
					value = 1.15f;
					break;
				case K_GAME_TUNNEL_3:
					value = 1.15f;
					break;
				default:
					value = 1.1f;
					break;
			}

		}
		else if (seriesName == SequenceName.CostHero)
		{

			switch (indexInterval)
			{
				case K_GAME_INTRO:
					value = 1.1f;
					break;
				case K_GAME_TUNNEL_1:
					value = 1.25f;
					break;
				case K_GAME_TUNNEL_2:
					value = 1.327f;
					break;
				case K_GAME_TUNNEL_3:
					value = 1.327f;
					break;
				default:
					value = 1.25f;
					break;
			}

		}
		else if (seriesName == SequenceName.CostSupport)
		{
			switch (indexInterval)
			{
				case K_GAME_INTRO:
					value = 1.05f;
					break;
				case K_GAME_TUNNEL_1:
					value = 1.1f;
					break;
				case K_GAME_TUNNEL_2:
					value = 1.15f;
					break;
				case K_GAME_TUNNEL_3:
					value = 1.18f;
					break;
				default:
					value = 1.18f;
					break;
			}

		}
		else if (seriesName == SequenceName.HPBoss)
		{
			switch (indexInterval)
			{
				case K_GAME_INTRO:
					value = 1.04f;
					break;
				case K_GAME_TUNNEL_1:
					value = 1.06f;
					break;
				case K_GAME_TUNNEL_2:
					value = 1.08f;
					break;
				case K_GAME_TUNNEL_3:
					value = 1.12f;
					break;
				default:
					value = 1.12f;
					break;
			}

		}
		else if (seriesName == SequenceName.HPGhost)
		{
			switch (indexInterval)
			{
				case K_GAME_INTRO:
					value = 1.02f;
					break;
				case K_GAME_TUNNEL_1:
					value = 1.03f;
					break;
				case K_GAME_TUNNEL_2:
					value = 1.04f;
					break;
				case K_GAME_TUNNEL_3:
					value = 1.06f;
					break;
				default:
					value = 1.02f;
					break;
			}

		}
		else if (seriesName == SequenceName.DMGHero)
		{
			switch (indexInterval)
			{
				case K_GAME_INTRO:
					value = 1.075f;
					break;
				case K_GAME_TUNNEL_1:
					value = 1.095f;
					break;
				case K_GAME_TUNNEL_2:
					value = 1.1f;
					break;
				case K_GAME_TUNNEL_3:
					value = 1.2f;
					break;
				default:
					value = 1.3f;
					break;
			}
		}
		else if (seriesName == SequenceName.DMGBoss)
		{
			switch (indexInterval)
			{
				case K_GAME_INTRO:
					value = 1.075f;
					break;
				case K_GAME_TUNNEL_1:
					value = 1.095f;
					break;
				case K_GAME_TUNNEL_2:
					value = 1.1f;
					break;
				case K_GAME_TUNNEL_3:
					value = 1.2f;
					break;
				default:
					value = 1.3f;
					break;
			}

		}

		if (value == 1.0)
		{
			throw new Exception("cant have a ratio of 1, will create pb with logbase for interval " + indexInterval + " " + seriesName);
		}
		r = value;

		return r;
	}

	private static float GetInitSeriesFirstTermRatio(int indexInterval, SequenceName seriesName)
	{
		var value = 1.0f;

		var firstTerm = 1.0f;

		if (seriesName == SequenceName.DropCoins)
		{
			switch (indexInterval)
			{
				case K_GAME_INTRO:
					value = 1;
					break;
				case K_GAME_TUNNEL_1:
					value = 1;
					break;
				case K_GAME_TUNNEL_2:
					value = 1;
					break;
				case K_GAME_TUNNEL_3:
					value = 1;
					break;
				default:
					value = 1;
					break;
			}

		}
		else if (seriesName == SequenceName.CostHero)
		{

			switch (indexInterval)
			{
				case K_GAME_INTRO:
					value = 5;
					break;
				case K_GAME_TUNNEL_1:
					value = 10;
					break;
				case K_GAME_TUNNEL_2:
					value = 15;
					break;
				case K_GAME_TUNNEL_3:
					value = 20;
					break;
				default:
					value = 25;
					break;
			}

		}
		else if (seriesName == SequenceName.CostSupport)
		{
			switch (indexInterval)
			{
				case K_GAME_INTRO:
					value = 5;
					break;
				case K_GAME_TUNNEL_1:
					value = 10;
					break;
				case K_GAME_TUNNEL_2:
					value = 30;
					break;
				case K_GAME_TUNNEL_3:
					value = 40;
					break;
				default:
					value = 50;
					break;
			}

		}
		else if (seriesName == SequenceName.HPGhost)
		{
			switch (indexInterval)
			{
				case K_GAME_INTRO:
					value = 20;
					break;
				case K_GAME_TUNNEL_1:
					value = 30;
					break;
				case K_GAME_TUNNEL_2:
					value = 40;
					break;
				case K_GAME_TUNNEL_3:
					value = 50;
					break;
				default:
					value = 60;
					break;
			}

		}
		else if (seriesName == SequenceName.HPBoss)
		{
			switch (indexInterval)
			{
				case K_GAME_INTRO:
					value = 20;
					break;
				case K_GAME_TUNNEL_1:
					value = 1000;
					break;
				case K_GAME_TUNNEL_2:
					value = 1000;
					break;
				case K_GAME_TUNNEL_3:
					value = 1000;
					break;
				default:
					value = 1000;
					break;
			}

		}
		else if (seriesName == SequenceName.DMGHero)
		{
			switch (indexInterval)
			{
				case K_GAME_INTRO:
					value = 1;
					break;
				case K_GAME_TUNNEL_1:
					value = 2;
					break;
				case K_GAME_TUNNEL_2:
					value = 3;
					break;
				case K_GAME_TUNNEL_3:
					value = 4;
					break;
				default:
					value = 5;
					break;
			}

		}

		firstTerm = value;
		return firstTerm;
		//return SMPNum.FromNum(firstTerm);
	}
}
