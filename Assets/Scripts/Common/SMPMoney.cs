//----------------------------------------------------------------------------------------------------------------//
/*
	 *		Name			:	Helper
	 *		Create Date		:	27-10-2016
	 *		Modified		:	27-10-2016
	 *		Author			:	Gaucher Jimmy
	 *		Author Modify	:	Gaucher Jimmy
	 *		Sumary			: 	Function use as genreral for money.
	*/
//----------------------------------------------------------------------------------------------------------------//

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class SMPMoney 
{

	public static List<string> TypeOfMoney = new List<string>()
	{
		"",
		"K",
		"M",
		"B",
		"T",
		"aa",
		"bb",
		"cc",
		"dd",
		"ee",
		"ff",
		"gg",
		"hh",
		"ii",
		"jj",
		"kk",
		"ll",
		"mm",
		"nn",
		"oo",
		"pp",
		"qq",
		"rr",
		"ss",
		"tt",
		"uu",
		"vv",
		"ww",
		"xx",
		"yy",
		"zz"
	};
	//Get the Money without letter (ex get 85840 for 85,84K with the GetMoney function)
	public static string GetRealValue (string _CurrentMoney)
	{
		if (_CurrentMoney == null)
		{
			Debug.LogError ("_CurrentMoney is null");
			return null;
		}

		//Check if the string contain a money
		for (int i = 1; i < TypeOfMoney.Count; i++)
		{
			string _CurrentMoneyUpper = _CurrentMoney;//.ToUpper ();
			if (_CurrentMoney.Contains(TypeOfMoney[i]) || _CurrentMoneyUpper.Contains(TypeOfMoney[i]))
			{
				//Check the right letter and remove it
				//_CurrentMoney = _CurrentMoney.Replace(TypeOfMoney[i], "\0");
				_CurrentMoney = _CurrentMoney.Remove(_CurrentMoney.Length - TypeOfMoney[i].Length);

				//Split string if 2 part number
				int _TempIndexSecond = 0;
				if (_CurrentMoney.Contains("."))
				{
					string[] _CurrentMoneySplited = _CurrentMoney.Split('.');
					_TempIndexSecond = _CurrentMoneySplited [1].Length;
					_CurrentMoney = _CurrentMoneySplited [0] + _CurrentMoneySplited [1];
				}
				//add number of 0 depend of letter
				if ((i * 3) - _TempIndexSecond > 0)
				{
					string _TempStringForInsert = new string ('0', (i * 3) - _TempIndexSecond);
					_CurrentMoney += _TempStringForInsert;
				}
				return _CurrentMoney;
			}
		}
		double result;
		if (double.TryParse (_CurrentMoney, out result)) {
			return result.ToString ("0");
		} else {
			return double.PositiveInfinity.ToString ();
		}
	}

	//Get the Money with letter (ex get 85,84K)
	public static string GetMoney (string _CurrentMoney)
	{
		if (_CurrentMoney == null)
		{
			_CurrentMoney = "";
		}
		//Variables for final return
		string _sMoneyReturned = "";
		string _sMoneyFindMain = "";
		string _sMoneyFindSecond = "";

		string _sTypeOfMoney = "";
		// STEP 1 :Check if the string contain a money
		_CurrentMoney = GetRealValue (_CurrentMoney);

		if (_CurrentMoney == "Infinity")
		{
			return "MAX";
		}

		if (_CurrentMoney == null)
		{
			Debug.LogError ("_CurrentMoney is null");
			return null;
		}

		//step 2 : GET THE RIGHT LETTER OF NUMBER
		if (_CurrentMoney.Count () > 3)
		{
			//Try to chatch the right type of money
			int _iTypeOfMoney = _CurrentMoney.Count () / 3;



			if (_CurrentMoney.Count () % 3 == 0) {
				if (_iTypeOfMoney-1 >= TypeOfMoney.Count)
				{
					double result;
					if (double.TryParse (_CurrentMoney, out result)) {
						return result.ToString ("0.##E+0");	
					} else {
						return "MAX";
					}

				}
				_sTypeOfMoney = TypeOfMoney [_iTypeOfMoney - 1];
			}
			else {
				if (_iTypeOfMoney >= TypeOfMoney.Count)
				{
					double result;
					if (double.TryParse (_CurrentMoney, out result)) {
						return result.ToString ("0.##E+0");	
					} else {
						return "MAX";
					}

				}
				_sTypeOfMoney = TypeOfMoney [_iTypeOfMoney];
			}
		}
		//Step 3 : Resize the string for number
		if (_CurrentMoney.Count() > 0)
		{
			//Take the Main digit (before ",")
			int _iDigitMain = _CurrentMoney.Count () % 3;
			if (_iDigitMain != 0)
			{
				for (int i = 0; i < _iDigitMain; i++)
				{
					_sMoneyFindMain += _CurrentMoney [i];
				}

				_sMoneyReturned += _sMoneyFindMain;
			}
			else
			{
                for (int i = 0; i < 3; i++)
                {
                    if (i < _CurrentMoney.Length)
                    {
                        _sMoneyFindMain += _CurrentMoney[i];
                    }
                }
				_iDigitMain = _sMoneyFindMain.Length;
				_sMoneyReturned += _sMoneyFindMain;
			}
			//Take the second digit (after ","
			if (_CurrentMoney.Count () > 0)
			{
				for (int i = 0 + _iDigitMain; i < 2 + _iDigitMain; i++)
				{
                    if (i < _CurrentMoney.Length)
                    {
                        _sMoneyFindSecond += _CurrentMoney[i];
                    }
				}
				// Add "," if needed
				if (_iDigitMain > 0 && _sMoneyFindSecond != "")
					_sMoneyReturned += ".";
				//Add to the main string the second digit string
				_sMoneyReturned += _sMoneyFindSecond;
			}
			//Add the type of money to the Main string
			_sMoneyReturned += _sTypeOfMoney;
			return _sMoneyReturned;
		}
		else
			return "";
  	}

	public static int IndexTypeOfMoney (string _TypeOfMoneyIndex)
	{
		//Get the index of the type of money
		int _iIndex = - 1;
		for (int i = 0; i < TypeOfMoney.Count; i++)
		{
			if (TypeOfMoney[i] == _TypeOfMoneyIndex)
			{
				_iIndex = i;
				break;
			}
		}
		//if type of money not find
		if (_iIndex == -1)
		{			
			Debug.LogError ("_TypeOfMoneySubstract not correct or doesn't exist in list");
			return 0;
		}

		return _iIndex;
	}

	public static string ReverseString( string _String )
	{
		char[] charArray = _String.ToCharArray();
		Array.Reverse( charArray );
		return new string( charArray ).ToString();
	}

	//Add 2 sting can be receive xxx,xxx / xxxxxxx / xxxxKK / xxx,xxxKK return a REALNUMBER !
	public static string AddString (string _CurrentString, string _NeedAddString)
	{
		//If _current is empty
		if (_CurrentString == "")
		{
			return _NeedAddString;
		}
		else if (_NeedAddString == "")
		{
			return _CurrentString;
		}

		string realCurrentString = GetRealValue (_CurrentString);
		string realNeedAddString = GetRealValue (_NeedAddString);
		if (realCurrentString == "Infinity" || realNeedAddString == "Infinity")
		{
			return "MAX";
		}

		BigInteger b1 = new BigInteger (realCurrentString, 10);
		BigInteger b2 = new BigInteger (realNeedAddString, 10);

		BigInteger b = b1 + b2;

		return b.ToString();
	}

    public static string MinusString (string _CurrentString, string _NeedAddString)
    {
        //If _current is empty
        if (_CurrentString == "")
        {
            return _NeedAddString;
        }
        else if (_NeedAddString == "")
        {
            return _CurrentString;
        }
	string _TempCurrentString = GetRealValue (_CurrentString);
	string _TempNeedMinusString = GetRealValue (_NeedAddString);

	if (_TempCurrentString == "Infinity" || _TempNeedMinusString == "Infinity")
	{
		return double.PositiveInfinity.ToString ();
	}
	BigInteger b1 = new BigInteger (_TempCurrentString, 10);
	BigInteger b2 = new BigInteger (_TempNeedMinusString, 10);

        BigInteger b = b1 - b2;

        return b.ToString();
    }

	//Substract 2 sting can be receive xxx,xxx / xxxxxxx / xxxxKK / xxx,xxxKK return a REALNUMBER !
	public static string SubstractString (string _CurrentString, string _NeedSubstractString)
	{
		if (_CurrentString == null || _NeedSubstractString == null || _CurrentString.Contains('-'))
		{
//			Debug.LogError ("Null");
			return "0";
		}
		//If _current is empty
		if (_CurrentString == "")
		{
			return "NotEnougt";
		}
		if (_CurrentString == "NotEnougt")
		{
			return "NotEnougt";
		}
		else if (_NeedSubstractString == "")
		{
			return _CurrentString;
		}

		//Get the real string for each 
		string _TempCurrentString = GetRealValue (_CurrentString);
		string _TempNeedSubstractString = GetRealValue (_NeedSubstractString);

		if (_TempCurrentString == "Infinity" || _TempNeedSubstractString == "Infinity")
		{
			return double.PositiveInfinity.ToString ();
		}

		BigInteger b1 = new BigInteger (_TempCurrentString, 10);
		BigInteger b2 = new BigInteger (_TempNeedSubstractString, 10);
		BigInteger b = b1 - b2;

		return b.ToString();
	}
	//Multiply 2 sting can be receive xxx,xxx / xxxxxxx / xxxxKK / xxx,xxxKK return a REALNUMBER !
	public static string MultiplyString (string _CurrentString, string _FactorString)
	{
		//Protect multiply & all * 0 = 0
		if (_CurrentString == null || _CurrentString == "" || _FactorString == null || _FactorString == "")
		{
			return "";
		}

		//Get the real string for each 
		string _TempCurrentString = GetRealValue (_CurrentString);
		string _TempFactorString = GetRealValue (_FactorString);

		//Debug.Log ("real value : " + _TempFactorString);

		if (_TempFactorString == "Infinity" || _TempCurrentString == "Infinity")
		{
			return double.PositiveInfinity.ToString ();
		}

		BigInteger b1 = new BigInteger (_TempCurrentString, 10);
		BigInteger b2 = new BigInteger (_TempFactorString, 10);
		BigInteger b = b1 * b2;

		return b.ToString();
	}
	//Multiply string with float can be receive xxx,xxx / xxxxxxx / xxxxKK / xxx,xxxKK return a REALNUMBER !
	public static string MultiplyString (string _CurrentString, float _FactorFloat)
	{
		//Protect multiply & all * 0 = 0
		if (_CurrentString == null || _CurrentString == "" || _FactorFloat == 0)
		{
			return "";
		}

		//Get the real string for each 
		string _TempCurrentString = GetRealValue (_CurrentString);

		BigInteger b1 = new BigInteger (_TempCurrentString,10);
		BigInteger b2 = new BigInteger (((int)_FactorFloat).ToString(),10);
		BigInteger b = b1 * b2;

		return b.ToString();
	}
	//Divide string with String can be receive xxx,xxx / xxxxxxx / xxxxKK / xxx,xxxKK return a REALNUMBER !
	public static string DivideString (string _Divisor, string _Numerator)
	{
		string _TempDivisor = GetRealValue (_Divisor);
		string _TempNumerator = GetRealValue (_Numerator);

		if (_TempDivisor == "Infinity")
		{
			return double.PositiveInfinity.ToString ();
		}
	
		BigInteger b1 = new BigInteger (_TempDivisor,10);
		BigInteger b2 = new BigInteger (_TempNumerator,10);
		BigInteger b = b1 / b2;

		return b.ToString();
	}

    public static string[] DivideStringWithRemain (string _Divisor, string _Numerator)
    {
        string _TempDivisor = GetRealValue (_Divisor);
        string _TempNumerator = GetRealValue (_Numerator);

        BigInteger b1 = new BigInteger (_TempDivisor,10);
        BigInteger b2 = new BigInteger (_TempNumerator,10);
        BigInteger b = b1 / b2;
        BigInteger br = b + (b1 % b2);

        return new string[2]{b.ToString(), br.ToString()};
    }

	public static float GetCurrentPercentage(string _currentValues,string _maxValues)
	{
		if (_currentValues == "Infinity" || _maxValues == "Infinity")
		{
			return 0;
		}
		if (_currentValues == null || _currentValues.Length == 0 || _maxValues == null || _maxValues.Length == 0)
		{
			Debug.Log ("Can not Calculate On your values . please input again !");
			return 0;
		}

		string _TempCurrentString = GetRealValue (_currentValues);
		string _TempMaxValueString = GetRealValue (_maxValues);

		BigInteger b1 = new BigInteger (_TempCurrentString, 10);
		BigInteger b2 = new BigInteger (_TempMaxValueString, 10);

		return float.Parse(((b1 * 100) / b2).ToString());
	}

	//Divide string with String can be receive xxx,xxx / xxxxxxx / xxxxKK / xxx,xxxKK return a REALNUMBER !
	public static string PercentageString(string _CurrentString, string _MaxValueString)
	{
		if (_CurrentString == null || _CurrentString.Length == 0 || _MaxValueString == null || _MaxValueString.Length == 0)
		{
			return "";
		}
		
		string _TempCurrentString = GetRealValue (_CurrentString);
		string _TempMaxValueString = GetRealValue (_MaxValueString);

		BigInteger b1 = new BigInteger (_TempCurrentString, 10);
		BigInteger b2 = new BigInteger (_TempMaxValueString, 10);

		return ((b1 * b2)/100).ToString();
	}

   

	public static bool IsBigValues(string _currentString_compare,string _currentString_need_compare)
	{
		if (_currentString_compare == "Infinity" || _currentString_need_compare == "Infinity")
		{
			return false;
		}

		if (_currentString_compare == null || _currentString_compare.Length == 0 || _currentString_need_compare == null || _currentString_need_compare.Length == 0)
		{
			Debug.LogError ("Please input real values for compare !");
			return false;
		}

		bool isBigValue = false;

		string _TempCurrentString = GetRealValue (_currentString_compare);
		string _TempMaxValueString = GetRealValue (_currentString_need_compare);

		BigInteger b1 = new BigInteger (_TempCurrentString, 10);
		BigInteger b2 = new BigInteger (_TempMaxValueString, 10);

		if (b1 > b2)
			isBigValue = true;
		else
			isBigValue = false;

		return isBigValue;
	}

    public static bool IsBigOrEqualValues(string _currentString_compare,string _currentString_need_compare)
    {
        if (_currentString_compare == "Infinity" || _currentString_need_compare == "Infinity")
        {
            return false;
        }

        if (_currentString_compare == null || _currentString_compare.Length == 0 || _currentString_need_compare == null || _currentString_need_compare.Length == 0)
        {
            Debug.LogError ("Please input real values for compare !");
            return false;
        }

        bool isBigValue = false;

        string _TempCurrentString = GetRealValue (_currentString_compare);
        string _TempMaxValueString = GetRealValue (_currentString_need_compare);

        BigInteger b1 = new BigInteger (_TempCurrentString, 10);
        BigInteger b2 = new BigInteger (_TempMaxValueString, 10);

        if (b1 >= b2)
            isBigValue = true;
        else
            isBigValue = false;

        return isBigValue;
    }

	public static string GetValueByPercentageString(string _currentString, int percentage)
	{
		string _TempCurrentString = GetRealValue (_currentString);

		BigInteger b1 = new BigInteger (_TempCurrentString, 10);

		return ((b1 * percentage) / 100).ToString ();
	}

    #region Puthear Method

    private static string[] sizeSIUnit = 
        {   "",
            "K",
            "M",
            "B",
            "T",
            "aa",
            "bb",
            "cc",
            "dd",
            "ee",
            "ff",
            "gg",
            "hh",
            "ii",
            "jj",
            "kk",
            "ll",
            "mm",
            "nn",
            "oo",
            "pp",
            "qq",
            "rr",
            "ss",
            "tt",
            "uu",
            "vv",
            "ww",
            "xx",
            "yy",
            "zz"
        };

    public static string ToReadableSIUnit(double value)
    {
        // Get the exponent
        // Since logn(x) = y means "Multiply 'n' by itself 'y' times to get 'x'",
        // the integer part of the log base 10 of any number is the exponent.
        // (This is called the "characteristic" in math parlance)
        // Since we are using longs which don't have a faractional part, this can't be negative.
        if (value < 1000)
        {
            return value.ToString("0");
        }
        if (double.IsInfinity(value) || value >= double.MaxValue)
        {
            return "MAX";
        }
        //Debug.Log("===============================Value to check : " + value);
        double exponent = (double)Math.Log10(value);
        int group = (int)(exponent / 3);
        if (group >= sizeSIUnit.Length)
        {
            return value.ToString("0.##E+0"); 
        }
        else if (group<0)
        {
            group = 0;
        }
        double divisor = Math.Pow(10, group * 3);
        return string.Format("{0:0.00}{1}", value / divisor, sizeSIUnit[group]);
    }

    public static double PercentageDouble(double current, int max)
    {
        return ((current * max)/100);
    }

    public static float GetCurrentPercentageDouble(double _currentValues,double _maxValues)
    {
        return float.Parse(((_currentValues* 100) / _maxValues).ToString());
    }

    public static double DoubleSIParse(string value)
    {
        if (value == "MAX")
        {
            return double.PositiveInfinity;
        }
        if (value.Contains("E+"))
        {
            double result;
            if (double.TryParse (value, out result)) {
                return result;
            } else {
                return double.PositiveInfinity;
            }
        }
        for (int i = sizeSIUnit.Length - 1; i >= 1; i--)
        {
            if (value.Contains(sizeSIUnit[i].ToUpper()))
            {
                value = value.Replace(sizeSIUnit[i].ToUpper(), "");
                return double.Parse(value) * Math.Pow(10, i * 3);
            }
        }
        try
        {
            return double.Parse(value);
        }
        catch (Exception er)
        {
            Debug.LogError("Can't parse double : "+value +" : " + er.Message);
            return 0;
        }
    }

    #endregion
}
