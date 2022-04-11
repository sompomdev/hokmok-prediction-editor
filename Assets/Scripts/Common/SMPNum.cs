using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class SMPNum : IComparable {
	public static List<string> DefaultTypeOfMoney = new List<string>()
	{
		"",
		"K",
		"M",
		"B",
		"T"
	};
	
	public static List<string> AlphabetTypeOfMoney = new List<string>()
	{
		"A",
		"B",
		"C",
		"D",
		"E",
		"F",
		"G",
		"H",
		"I",
		"J",
		"K",
		"L",
		"M",
		"N",
		"O",
		"P",
		"Q",
		"R",
		"S",
		"T",
		"U",
		"V",
		"W",
		"X",
		"Y",
		"Z",
	};
		public const string DEFINE_ZERO = "number-is-zero";
		public bool isZero = false;
		public static double _main = 2;
		private double _power;

	public void ValidateFromSave(string value)
	{
		if (value != DEFINE_ZERO)
		{
			double expected;
			if (double.TryParse(value, out expected))
			{
				SetPower(expected);
			}
		}
		else
		{
			isZero = true;
		}
	}
		
		public double Power 
		{
			get{
				return _power;
			}
			set 
			{
				
				_power = value;
				if(double.IsInfinity(_power))
				{
					throw new OverflowException("_power is infinity number!");
				}
				else
				{
					isZero = false;
					CheckAndRoundInit();
				}
			}
		}
		private void CheckAndRoundInit ()
		{
			// if (!isZero)
			// {
			// 	double valueInDouble = _main * System.Math.Pow(10,_power);
			// 	if (valueInDouble < 1) valueInDouble = 1;
			// 	if (valueInDouble < 1000)
			// 	{
			// 		valueInDouble = Math.Round(valueInDouble);
			// 		_power = System.Math.Log10(valueInDouble/_main);
			// 		if(double.IsInfinity(_power))
			// 		{
			// 			throw new OverflowException("_power is infinity number!");
			// 		}
			// 	}
			// }
		}

		public SMPNum Round ()
		{
			if (!isZero)
			{
				double valueInDouble = _main * System.Math.Pow(10,_power);
				if (valueInDouble < 1) valueInDouble = 1;
				if (valueInDouble < 1000)
				{
					valueInDouble = Math.Round(valueInDouble);
					_power = System.Math.Log10(valueInDouble/_main);
					if(double.IsInfinity(_power))
					{
						throw new OverflowException("_power is infinity number!");
					}
					//Debug.Log(" valueInDouble : " + valueInDouble);
					valueInDouble = _main * System.Math.Pow(10,_power);
					//Debug.Log(" after round : " + valueInDouble);
				}

			}

			return this;
		}

		public SMPNum () {
			isZero = true;
		}
		public SMPNum(double number)
		{
			if (number.ToString() == "NaN")
			{
				throw new OverflowException("SMPNumber cannot init with NaN number!");
			}
			if(double.IsInfinity(number))
			{
				throw new OverflowException("SMPNumber cannot init with infinity number!");
			}
			if (number < 0)
			{
				throw new OverflowException("SMPNumber cannot init with negative number! "+number);
			}
			if(number == 0)
			{
				isZero = true;
				// throw new OverflowException("SMPNumber cannot init with zero number!");
			}
			else
			{
				isZero = false;
				_power = System.Math.Log10(number/_main);
				if(double.IsInfinity(_power))
				{
					throw new OverflowException("_power is infinity number!");
				}

				CheckAndRoundInit();
			}
			
		}
		public static SMPNum FromNum(double number)
		{
			return new SMPNum(number);
		}
		public static SMPNum FromPower(double power)
		{
			SMPNum newNum = new SMPNum();
			newNum.Power = power;
			return newNum;
		}
		public static SMPNum FromPower(string power)
		{
			SMPNum newNum = new SMPNum();
			if (power == DEFINE_ZERO)
			{
				newNum.isZero = true;	
			}
			else
			{
				newNum.PowerFromString(power);
			}
			
			return newNum;
		}
		public void SetPower (double power)
		{
			if(double.IsInfinity(power))
			{
				throw new OverflowException("Cannot set power with infinity number!");
			}
			isZero = false;
			_power = power;
			CheckAndRoundInit();
		}
		public void SetNum (double number)
		{
			if(double.IsInfinity(number))
			{
				throw new OverflowException("SMPNumber cannot init with infinity number!");
			}
			if (number < 0)
			{
				throw new OverflowException("SMPNumber cannot init with negative number!");
			}
			if(number == 0)
			{
				isZero = true;
			}
			else
			{
				isZero = false;
				_power = System.Math.Log10(number/_main);
				if(double.IsInfinity(_power))
				{
					throw new OverflowException("_power is infinity number!");
				}
				CheckAndRoundInit();
			}
		}
		public void SetNum (SMPNum number)
		{
			if (object.ReferenceEquals(number, null))
			{
				throw new OverflowException("SMPNumber cannot init with null number!");
			}
			if (number.isZero)
			{
				isZero = true;
			}
			else
			{
				isZero = false;
				_power = number.Power;
				CheckAndRoundInit();
			}
		}

		public static bool IsNull (SMPNum number)
		{
			if (object.ReferenceEquals(number, null))
			{
				return true;
			}
			return false;
		}

		public string StringForSave ()
		{
			if (isZero)
			{
				return DEFINE_ZERO;
			}
			return Power.ToString();
		}
		private void PowerFromString(string power)
		{
			double powerDouble ;
			if (double.TryParse(power,out powerDouble))
			{
				isZero = false;
				Power = powerDouble;
			}
			else
			{
				throw new InvalidCastException("Try to cast invalid string to double!");
			}
		}
		public SMPNum Pow (int power)
		{
			SMPNum result = Pow(this,power);
			return result;
		}
		public SMPNum Pow (float power)
		{
			SMPNum result = Pow(this,power);
			return result;
		}
		public static SMPNum Pow (SMPNum b, int power)
		{
			if (object.ReferenceEquals(b, null))
			{
				throw new ArgumentNullException("main side");
			}
			SMPNum newMain = new SMPNum();
			newMain.Power = b.Power;

			SMPNum result = new SMPNum(1);
			while (power != 0) {

				if ((power & 1) != 0)
					result *= newMain;
				power >>= 1;
				newMain *= newMain;
			}

			return result;
		}
		public static SMPNum Pow (SMPNum b, float power)
		{
			if (object.ReferenceEquals(b, null))
			{
				throw new ArgumentNullException("main side");
			}

			int powerFloor = Mathf.FloorToInt(power);
			power = power - powerFloor;

			SMPNum newMain = new SMPNum();
			newMain.Power = b.Power;

			SMPNum result = new SMPNum(1);
			while (powerFloor != 0) {

				if ((powerFloor & 1) != 0)
				{
					result *= newMain;
				}
				powerFloor >>= 1;
				newMain *= newMain;
			}


			double newNum = Math.Pow(SMPNum._main, power);
			SMPNum newMain2 = new SMPNum(newNum);

			double newPower = b.Power * power;
			SMPNum newMain3 = SMPNum.FromPower(newPower);
			newMain3 /= 2;

			SMPNum newMain4 = newMain2 * newMain3;
			result *= newMain4;


			return result;
		}
		public SMPNum Log (double baseNumber)
		{
			SMPNum result = Log(this,baseNumber);
			return result;
		}
		public static SMPNum Log (SMPNum b, double baseNumber)
		{
			if (object.ReferenceEquals(b, null))
			{
				throw new ArgumentNullException("main side");
			}

			var log1 = System.Math.Log(_main, baseNumber);
			var log2 = System.Math.Log(10, baseNumber);

			SMPNum result = null;
			if (b.Power < 0) //that mean the number is smaller than 2
			{
				result = new SMPNum(Math.Log(b.ToDoubleIfPossible(), baseNumber));
			}
			else
			{
				result = new SMPNum(1) * log1 + log2 * b.Power;
			}

		return result;
		}
		public static SMPNum operator + (SMPNum leftSide, SMPNum rightSide)
		{
			if (object.ReferenceEquals(leftSide, null))
			{
				throw new ArgumentNullException("leftSide");
			}
			if (object.ReferenceEquals(rightSide, null))
			{
				throw new ArgumentNullException("rightSide");
			}

			if (leftSide.isZero) return rightSide;
			if (rightSide.isZero) return leftSide;

			double middlePower = (leftSide.Power >= rightSide.Power)? leftSide.Power:rightSide.Power; 
			double leftSidePower1 = leftSide.Power - middlePower;
			double rightSidePower1 = rightSide.Power - middlePower;

			// Debug.Log("middlePower : " + middlePower);
			// Debug.Log("leftSidePower1 : " + leftSidePower1);
			// Debug.Log("rightSidePower1 : " + rightSidePower1);

			double temp1 = System.Math.Pow(10,leftSidePower1) + System.Math.Pow(10,rightSidePower1);
			if(double.IsInfinity(temp1))
			{
				throw new OverflowException("Calculation!");
			}
			//Debug.Log("Temp : " + temp1);
			SMPNum newLeftSide = new SMPNum();
			newLeftSide.Power = middlePower;
		
			SMPNum newRightSide = new SMPNum(temp1);

			newLeftSide = newLeftSide * newRightSide;

			return newLeftSide;
		}
		public static SMPNum operator + (SMPNum leftSide, double rightSideDouble)
		{
			SMPNum rightSide = new SMPNum (rightSideDouble);
			if (double.IsInfinity(rightSideDouble))
			{
				throw new OverflowException("rightSide is infinity!");
			}

			if (leftSide.isZero) return rightSide;
			if (rightSide.isZero) return leftSide;

			SMPNum result = leftSide + rightSide;

			return result;
		}
		public static SMPNum operator + (double leftSideDouble, SMPNum rightSide)
		{
			SMPNum leftSide = new SMPNum (leftSideDouble);

			if (double.IsInfinity(leftSideDouble))
			{
				throw new OverflowException("leftSideDouble is infinity!");
			}

			SMPNum result = leftSide + rightSide;

			return result;
		}

		public static SMPNum operator - (SMPNum leftSide, SMPNum rightSide)
		{
			if (object.ReferenceEquals(leftSide, null))
			{
				throw new ArgumentNullException("leftSide");
			}
			if (object.ReferenceEquals(rightSide, null))
			{
				throw new ArgumentNullException("rightSide");
			}


			// Debug.Log("leftSide : ");
			// leftSide.DisplayFullNumber();
			// Debug.Log("rightSide : ");
			// rightSide.DisplayFullNumber();
			
			// Debug.Log("right side is " + rightSide.isZero);

			if (leftSide.isZero) return rightSide;
			if (rightSide.isZero) return leftSide;
			
			if (rightSide.Power > leftSide.Power)
			{
				//throw new Exception("LeftSide need to be bigger!");
				return new SMPNum(0);

			}else if(rightSide.Power == leftSide.Power)
			{
				return new SMPNum(0);
			}

			if (!leftSide.IsDoubleInifinity() && !rightSide.IsDoubleInifinity())
			{
				double left = leftSide.ToDoubleIfPossible();
				//left = System.Math.Floor(left);
				double right = rightSide.ToDoubleIfPossible();
				//right = System.Math.Floor(right);
				double result = left - right;
				return new SMPNum(result);
			}


			double middlePower = (leftSide.Power >= rightSide.Power)? leftSide.Power:rightSide.Power; 
			double leftSidePower1 = leftSide.Power - middlePower;
			double rightSidePower1 = rightSide.Power - middlePower;
			double temp1 = System.Math.Pow(10,leftSidePower1) - System.Math.Pow(10,rightSidePower1);
			if(double.IsInfinity(temp1))
			{
				throw new OverflowException("Calculation!");
			}
			SMPNum newLeftSide = new SMPNum();
			newLeftSide.Power = middlePower;
		
			SMPNum newRightSide = new SMPNum(temp1);

			newLeftSide = newLeftSide * newRightSide;

			return newLeftSide;
		}
		public static SMPNum operator - (SMPNum leftSide, double rightSideDouble)
		{
			SMPNum rightSide = new SMPNum (rightSideDouble);
			//rightSide.DisplayDetails();
			if (double.IsInfinity(rightSideDouble))
			{
				throw new OverflowException("rightSideDouble is infinity!");
			}
			if (leftSide.isZero) return rightSide;
			if (rightSide.isZero) return leftSide;

			SMPNum result = leftSide - rightSide;

			return result;
		}
		public static SMPNum operator - (double leftSideDouble, SMPNum rightSide)
		{
			SMPNum leftSide = new SMPNum (leftSideDouble);
			if (double.IsInfinity(leftSideDouble))
			{
				throw new OverflowException("leftSideDouble is infinity!");
			}

			if (leftSide.isZero) return rightSide;
			if (rightSide.isZero) return leftSide;

			SMPNum result = leftSide - rightSide;

			return result;
		}


		public static SMPNum operator * (SMPNum leftSide, SMPNum rightSide)
		{
			if (object.ReferenceEquals(leftSide, null))
			{
				throw new ArgumentNullException("leftSide");
			}
			if (object.ReferenceEquals(rightSide, null))
			{
				throw new ArgumentNullException("rightSide");
			}

			if (leftSide.isZero) return leftSide;
			if (rightSide.isZero) return rightSide;

			SMPNum result = new SMPNum();
			double newMain = SMPNum._main * SMPNum._main;
			if (double.IsInfinity(newMain))
			{
				throw new OverflowException("newMain is infinity!");
			}
			double newPower = System.Math.Log10(newMain/SMPNum._main);
			result.Power = leftSide.Power + rightSide.Power + newPower;

			return result;
		}
		public static SMPNum operator * (SMPNum leftSide, double rightSideDouble)
		{
			if (double.IsInfinity(rightSideDouble))
			{
				throw new OverflowException("rightSide is infinity!");
			}
			if (object.ReferenceEquals(leftSide, null))
			{
				//leftSide = new SMPNum(0);
				throw new OverflowException("leftSide is null!");
			}

			SMPNum rightSide = new SMPNum(rightSideDouble);
			
			if (leftSide.isZero) return leftSide;
			if (rightSide.isZero) return rightSide;

			SMPNum result = leftSide * rightSide;
			return result;
		}
		public static SMPNum operator * (double leftSideDouble, SMPNum rightSide)
		{
			if (double.IsInfinity(leftSideDouble))
			{
				throw new OverflowException("leftSide is infinity!");
			}

			SMPNum leftSide = new SMPNum(leftSideDouble);
			if (leftSide.isZero) return leftSide;
			if (rightSide.isZero) return rightSide;

			SMPNum result = leftSide * rightSide;
			return result;
		}

		public static SMPNum operator / (SMPNum leftSide, SMPNum rightSide)
		{
			if (object.ReferenceEquals(leftSide, null))
			{
				throw new ArgumentNullException("leftSide");
			}
			if (object.ReferenceEquals(rightSide, null))
			{
				throw new ArgumentNullException("rightSide");
			}

			if (leftSide.isZero) return leftSide;
			if (rightSide.isZero || rightSide == 0) {
				throw new ArgumentNullException("Cannot devide by zero!");
			}

			SMPNum result = new SMPNum();
			double newMain = SMPNum._main / SMPNum._main;
			double newPower = System.Math.Log10(newMain/SMPNum._main);
			result.Power = leftSide.Power - rightSide.Power + newPower;

			return result;
		}
		public static SMPNum operator / (SMPNum leftSide, double rightSideDouble)
		{
			if (double.IsInfinity(rightSideDouble))
			{
				throw new OverflowException("rightSide is infinity!");
			}
			if (rightSideDouble == 0)
			{
				throw new OverflowException("rightSide is zero!");
			}
			SMPNum rightSide = new SMPNum(rightSideDouble);

			if (leftSide.isZero) return leftSide;
			if (rightSide.isZero) {
				throw new ArgumentNullException("Cannot devide by zero!");
			}

			SMPNum result = leftSide/rightSide;
			
			return result;
		}
		public static SMPNum operator / (double leftSideDouble, SMPNum rightSide)
		{
			if (double.IsInfinity(leftSideDouble))
			{
				throw new OverflowException("leftSideDouble is infinity!");
			}
			SMPNum leftSide = new SMPNum(leftSideDouble);
			if (leftSide.isZero) return leftSide;
			if (rightSide.isZero) {
				throw new ArgumentNullException("Cannot devide by zero!");
			}

			SMPNum result = leftSide/rightSide;
			
			return result;
		}
		public static bool operator < (SMPNum leftSide, SMPNum rightSide)
		{
			// Debug.Log("Leftside power : " + leftSide.Power);
			// Debug.Log("RightSide power : " + rightSide.Power);
			if (object.ReferenceEquals(leftSide, null))
			{
				throw new ArgumentNullException("leftSide");
			}

			if (object.ReferenceEquals(rightSide, null))
			{
				throw new ArgumentNullException("rightSide");
			}

			if (rightSide.isZero)
			{
				return false;
			}

			if (leftSide.isZero && !rightSide.isZero)
			{
				return true;
			}
			if (rightSide.isZero && leftSide.isZero)
			{
				return false;
			}

			if (leftSide.Power < rightSide.Power)
			{
				return true;
			}

			
			return false;
		}
		public static bool operator > (SMPNum leftSide, SMPNum rightSide)
		{
			// Debug.Log("Leftside power : " + leftSide.Power);
			// Debug.Log("RightSide power : " + rightSide.Power);

			if (object.ReferenceEquals(leftSide, null))
			{
				throw new ArgumentNullException("leftSide");
			}

			if (object.ReferenceEquals(rightSide, null))
			{
				throw new ArgumentNullException("rightSide");
			}

			if (leftSide.isZero)
			{
				return false;
			}

			if (rightSide.isZero && !leftSide.isZero)
			{
				return true;
			}

			if (rightSide.isZero && leftSide.isZero)
			{
				return false;
			}

			if (leftSide.Power > rightSide.Power)
			{
				return true;
			}

			
			return false;
		}
		public static bool operator < (SMPNum leftSide, double doubleRight)
		{
			var rightSide = new SMPNum(doubleRight);
			//Debug.Log("Leftside power : " + leftSide.Power);
			//Debug.Log("RightSide power : " + rightSide.Power);
			if (object.ReferenceEquals(leftSide, null))
			{
				throw new ArgumentNullException("leftSide");
			}

			if (object.ReferenceEquals(rightSide, null))
			{
				throw new ArgumentNullException("rightSide");
			}

			if (rightSide.isZero)
			{
				return false;
			}

			if (leftSide.isZero && !rightSide.isZero)
			{
				return true;
			}
			if (rightSide.isZero && leftSide.isZero)
			{
				return false;
			}

			if (leftSide.Power < rightSide.Power)
			{
				return true;
			}

			
			return false;
		}
		public static bool operator > (SMPNum leftSide, double doubleRight)
		{
			var rightSide = new SMPNum(doubleRight);
			// Debug.Log("Leftside power : " + leftSide.Power);
			// Debug.Log("RightSide power : " + rightSide.Power);

			if (object.ReferenceEquals(leftSide, null))
			{
				throw new ArgumentNullException("leftSide");
			}

			if (object.ReferenceEquals(rightSide, null))
			{
				throw new ArgumentNullException("rightSide");
			}

			if (leftSide.isZero)
			{
				return false;
			}

			if (rightSide.isZero && !leftSide.isZero)
			{
				return true;
			}

			if (rightSide.isZero && leftSide.isZero)
			{
				return false;
			}

			if (leftSide.Power > rightSide.Power)
			{
				return true;
			}

			
			return false;
		}
		public static bool operator < (double doubleLeft, SMPNum rightSide)
		{
			var leftSide = new SMPNum(doubleLeft);
			// Debug.Log("Leftside power : " + leftSide.Power);
			// Debug.Log("RightSide power : " + rightSide.Power);
			if (object.ReferenceEquals(leftSide, null))
			{
				throw new ArgumentNullException("leftSide");
			}

			if (object.ReferenceEquals(rightSide, null))
			{
				throw new ArgumentNullException("rightSide");
			}

			if (rightSide.isZero)
			{
				return false;
			}

			if (leftSide.isZero && !rightSide.isZero)
			{
				return true;
			}
			if (rightSide.isZero && leftSide.isZero)
			{
				return false;
			}

			if (leftSide.Power < rightSide.Power)
			{
				return true;
			}

			
			return false;
		}
		public static bool operator > (double doubleLeft, SMPNum rightSide)
		{
			var leftSide = new SMPNum(doubleLeft);
			// Debug.Log("Leftside power : " + leftSide.Power);
			// Debug.Log("RightSide power : " + rightSide.Power);

			if (object.ReferenceEquals(leftSide, null))
			{
				throw new ArgumentNullException("leftSide");
			}

			if (object.ReferenceEquals(rightSide, null))
			{
				throw new ArgumentNullException("rightSide");
			}

			if (leftSide.isZero)
			{
				return false;
			}

			if (rightSide.isZero && !leftSide.isZero)
			{
				return true;
			}

			if (rightSide.isZero && leftSide.isZero)
			{
				return false;
			}

			if (leftSide.Power > rightSide.Power)
			{
				return true;
			}

			
			return false;
		}
		
		
		public static bool operator == (SMPNum leftSide, SMPNum rightSide)
		{
			if (object.ReferenceEquals(leftSide, null))
			{
				throw new ArgumentNullException("leftSide");
			}

			if (object.ReferenceEquals(rightSide, null))
			{
				throw new ArgumentNullException("rightSide");
			}

			if (rightSide.isZero && !leftSide.isZero)
			{
				return false;
			}

			if (leftSide.isZero && !rightSide.isZero)
			{
				return false;
			}
			if (rightSide.isZero && leftSide.isZero)
			{
				return true;
			}

			if (leftSide.Power == rightSide.Power)
			{
				return true;
			}

			
			return false;
		}
		public static bool operator != (SMPNum leftSide, SMPNum rightSide)
		{
			// Debug.Log("Leftside power : " + leftSide.Power);
			// Debug.Log("RightSide power : " + rightSide.Power);
			if (object.ReferenceEquals(leftSide, null))
			{
				throw new ArgumentNullException("leftSide");
			}

			if (object.ReferenceEquals(rightSide, null))
			{
				throw new ArgumentNullException("rightSide");
			}

			if (rightSide.isZero && !leftSide.isZero)
			{
				return true;
			}

			if (leftSide.isZero && !rightSide.isZero)
			{
				return true;
			}
			if (rightSide.isZero && leftSide.isZero)
			{
				return false;
			}

			if (leftSide.Power != rightSide.Power)
			{
				return true;
			}

			
			return false;
		}
		public static bool operator == (SMPNum leftSide, double doubeRight)
		{
			var rightSide = new SMPNum(doubeRight);
			// Debug.Log("Leftside power : " + leftSide.Power);
			// Debug.Log("RightSide power : " + rightSide.Power);
			if (object.ReferenceEquals(leftSide, null))
			{
				throw new ArgumentNullException("leftSide");
			}

			if (object.ReferenceEquals(rightSide, null))
			{
				throw new ArgumentNullException("rightSide");
			}

			if (rightSide.isZero && !leftSide.isZero)
			{
				return false;
			}

			if (leftSide.isZero && !rightSide.isZero)
			{
				return false;
			}
			if (rightSide.isZero && leftSide.isZero)
			{
				return true;
			}

			if (leftSide.Power == rightSide.Power)
			{
				return true;
			}

			
			return false;
		}
		public static bool operator != (SMPNum leftSide, double doubeRight)
		{
			var rightSide = new SMPNum(doubeRight);
			// Debug.Log("Leftside power : " + leftSide.Power);
			// Debug.Log("RightSide power : " + rightSide.Power);
			if (object.ReferenceEquals(leftSide, null))
			{
				throw new ArgumentNullException("leftSide");
			}

			if (object.ReferenceEquals(rightSide, null))
			{
				throw new ArgumentNullException("rightSide");
			}

			if (rightSide.isZero && !leftSide.isZero)
			{
				return true;
			}

			if (leftSide.isZero && !rightSide.isZero)
			{
				return true;
			}
			if (rightSide.isZero && leftSide.isZero)
			{
				return false;
			}

			if (leftSide.Power != rightSide.Power)
			{
				return true;
			}

			
			return false;
		}
		public static bool operator == (double doubleLeft, SMPNum rightSide)
		{
			var leftSide = new SMPNum(doubleLeft);
			// Debug.Log("Leftside power : " + leftSide.Power);
			// Debug.Log("RightSide power : " + rightSide.Power);
			if (object.ReferenceEquals(leftSide, null))
			{
				throw new ArgumentNullException("leftSide");
			}

			if (object.ReferenceEquals(rightSide, null))
			{
				throw new ArgumentNullException("rightSide");
			}

			if (rightSide.isZero && !leftSide.isZero)
			{
				return false;
			}

			if (leftSide.isZero && !rightSide.isZero)
			{
				return false;
			}
			if (rightSide.isZero && leftSide.isZero)
			{
				return true;
			}

			if (leftSide.Power == rightSide.Power)
			{
				return true;
			}

			
			return false;
		}
		public static bool operator != (double doubleLeft, SMPNum rightSide)
		{
			var leftSide = new SMPNum(doubleLeft);
			// Debug.Log("Leftside power : " + leftSide.Power);
			// Debug.Log("RightSide power : " + rightSide.Power);
			if (object.ReferenceEquals(leftSide, null))
			{
				throw new ArgumentNullException("leftSide");
			}

			if (object.ReferenceEquals(rightSide, null))
			{
				throw new ArgumentNullException("rightSide");
			}

			if (rightSide.isZero && !leftSide.isZero)
			{
				return true;
			}

			if (leftSide.isZero && !rightSide.isZero)
			{
				return true;
			}
			if (rightSide.isZero && leftSide.isZero)
			{
				return false;
			}

			if (leftSide.Power != rightSide.Power)
			{
				return true;
			}

			
			return false;
		}
		

		public static bool operator >= (SMPNum leftSide, SMPNum rightSide)
		{
			if (object.ReferenceEquals(leftSide, null))
			{
				throw new ArgumentNullException("leftSide");
			}

			if (object.ReferenceEquals(rightSide, null))
			{
				throw new ArgumentNullException("rightSide");
			}

			bool bigger = leftSide > rightSide;
			bool equal = leftSide == rightSide;
			
			return bigger || equal;
		}
		public static bool operator <= (SMPNum leftSide, SMPNum rightSide)
		{
			if (object.ReferenceEquals(leftSide, null))
			{
				throw new ArgumentNullException("leftSide");
			}

			if (object.ReferenceEquals(rightSide, null))
			{
				throw new ArgumentNullException("rightSide");
			}

			bool bigger = leftSide < rightSide;
			bool equal = leftSide == rightSide;
			
			return bigger || equal;
		}
		public static bool operator >= (SMPNum leftSide, double doubleRight)
		{
			var rightSide = new SMPNum(doubleRight);
			if (object.ReferenceEquals(leftSide, null))
			{
				throw new ArgumentNullException("leftSide");
			}

			if (object.ReferenceEquals(rightSide, null))
			{
				throw new ArgumentNullException("rightSide");
			}

			bool bigger = leftSide > rightSide;
			bool equal = leftSide == rightSide;
			
			return bigger || equal;
		}
		public static bool operator <= (SMPNum leftSide, double doubleRight)
		{
			var rightSide = new SMPNum(doubleRight);
			if (object.ReferenceEquals(leftSide, null))
			{
				throw new ArgumentNullException("leftSide");
			}

			if (object.ReferenceEquals(rightSide, null))
			{
				throw new ArgumentNullException("rightSide");
			}

			bool bigger = leftSide < rightSide;
			bool equal = leftSide == rightSide;
			
			return bigger || equal;
		}
		public static bool operator >= (double doubleLeft, SMPNum rightSide)
		{
			var leftSide = new SMPNum(doubleLeft);
			if (object.ReferenceEquals(leftSide, null))
			{
				throw new ArgumentNullException("leftSide");
			}

			if (object.ReferenceEquals(rightSide, null))
			{
				throw new ArgumentNullException("rightSide");
			}

			bool bigger = leftSide > rightSide;
			bool equal = leftSide == rightSide;
			
			return bigger || equal;
		}
		public static bool operator <= (double doubleLeft, SMPNum rightSide)
		{
			var leftSide = new SMPNum(doubleLeft);
			if (object.ReferenceEquals(leftSide, null))
			{
				throw new ArgumentNullException("leftSide");
			}

			if (object.ReferenceEquals(rightSide, null))
			{
				throw new ArgumentNullException("rightSide");
			}

			bool bigger = leftSide < rightSide;
			bool equal = leftSide == rightSide;
			
			return bigger || equal;
		}
		public void TestDisplayWithNewMain (double newMain)
		{
			double power = System.Math.Round(this.Power);				
			double newPower = Math.Log10(2) + power - Math.Log10(newMain);

			// Debug.Log("New Main : " + newMain);
			// Debug.Log("New Power : " + newPower);
			// Debug.Log("Result : " + (newMain * System.Math.Pow(10,newPower)));	
			
		}

		public void DisplayFullNumber ()
		{
			if (isZero) Debug.Log("This num is Zero");
			Debug.Log("Number : " + (_main * System.Math.Pow(10,_power)).ToString("0.0000000"));
		}
		public string GetDisplayString ()
		{
			if (isZero)
			{
				return 0.ToString();
			}
			double res = _main * System.Math.Pow(10, Power);
			return _main + "*" + "10^" + _power + " == " + res.ToString("0.0000");
		}
		public void Display ()
		{
			//Debug.Log("Main : " + _main);
			//Debug.Log("Power : " + _power);
			//Debug.Log(_main + "*" + "10^" + _power + " == " + (_main * System.Math.Pow(10,_power)).ToString("0.0000000"));
			if (isZero) Debug.Log("This num is Zero");
			Debug.Log(_main + "*" + "10^" + _power + " == " + (_main * System.Math.Pow(10,_power)));

			//TestDisplayWithNewMain(3);
		}

		public override string ToString()
		{
			if (isZero)
			{
				return "0";
			}
			int type = PlayerPrefs.GetInt("type-number-display", 0);
			if (type == 0)
			{
				return ToReadableAlphabetV2();
			}
			else
			{
				return ToReadableV2();
			}
			//ToReadableV2(); //_main + "*" + "10^" + _power + " == " + (_main * System.Math.Pow(10,_power));
			//return _main + "*" + "10^" + _power;
		}
		public string ToString(string format)
		{
			if (isZero)
			{
				return 0.ToString(format);
			}
			int type = PlayerPrefs.GetInt("type-number-display", 0);
			if (type == 0)
			{
				return ToReadableAlphabetV2(format); //A3
			}
			else
			{
				return ToReadableV2(format); //scientific display
			}
		}
		public string ToString(string format, int maxLenght)
		{
			if (isZero)
			{
				return 0.ToString(format);
			}
			int type = PlayerPrefs.GetInt("type-number-display", 0);
			if (type == 0)
			{
				string s = ToReadableAlphabetV2(format);
				if(s.Length > maxLenght)
				{
					int ind = s.IndexOf(".");
					if(ind > 0)
					{
						if(s.Length - 1 == maxLenght)
						{
							s = s.Remove(ind+2, 1);
						}
						else
						{
							s = s.Remove(ind, 2);
						}
					}
				}
				return s; //A3
			}
			else
			{
				return ToReadableV2(format); //scientific display
			}
		}
	public void DisplayDetails ()
		{
			Debug.Log("Main : " + _main);
			Debug.Log("Power : " + _power);
			if (isZero) Debug.Log("This num is Zero");
			Debug.Log(_main + "*" + "10^" + _power + " == " + (_main * System.Math.Pow(10,_power)));
		}
		
		
		public string ToReadableV2 (string format = null)
		{
			if (isZero) return "0";

			double valueInDouble = _main * System.Math.Pow(10,_power);

			if (!double.IsInfinity(valueInDouble) && valueInDouble < 1000)
			{
				double floorValue = Mathf.Floor((float)valueInDouble);

				double howMany = valueInDouble - floorValue;
				if(format != null)
				{
					return valueInDouble.ToString(format);
				}
				if (howMany >= 0.01)
				{
					return valueInDouble.ToString("0.00");
				}
				else
				{
					return valueInDouble.ToString("0");
				}
			}


			if (SupportLetterFormat(valueInDouble.ToString("0")))
			{
				//return valueInDouble.ToString("0.00");
				string money = GetReadableAsLetterFormat(valueInDouble.ToString("0.00"));
				return money;
			}
			else
			{

				double power = this.Power;
				string final ;
				//System.Math.Pow(10,Power) * _main;

				double myMain = _main; 
				double myPower = power;
				//Debug.Log(" myPower  :" + myPower.ToString());
				double floorPower = System.Math.Floor(myPower);
				double powerRemaining = myPower - floorPower;
				myMain = myMain * System.Math.Pow(10, powerRemaining);

				if (!(myMain < 10))
				{
					myMain = myMain / 10; //because 2 = 0.2 * 10
					floorPower = floorPower + 1; //because 2 = 0.2 * 10, we divide main by 10 and increase power by 1
				}
				final = myMain.ToString("0.00") + "e" + floorPower;
				return final;	
			}
		}
		public string ToReadableAlphabet ()
		{
			if (isZero) return "0";

			double valueInDouble = _main * System.Math.Pow(10,_power);
			if (SupportLetterFormat(valueInDouble.ToString("0")))
			{
				string money = GetReadableAsLetterFormat(valueInDouble.ToString("0.0"));
				return money;
			}
			else
			{

				double power = this.Power;
				string final ;
				//System.Math.Pow(10,Power) * _main;

				double myMain = 1; //because we will convert 2 to power of 10 => log10(2)
				double myPower = power + Math.Log10(_main);
				int result = (int)Math.Floor(myPower / 3);
				double remaining = myPower % 3;
				double remainingInRealValue = Math.Pow(10, remaining);
				if (remainingInRealValue > 0)
				{
					myMain = myMain * remainingInRealValue;
				}
				int indexOfAlphabet = result - 5;

				string alphabet = "";
				if (indexOfAlphabet < AlphabetTypeOfMoney.Count)
				{
					alphabet = AlphabetTypeOfMoney[indexOfAlphabet];
					final = myMain.ToString("0.00") + alphabet + alphabet; // 2 of A => AA
				}
				else
				{
					int howManyTimeBigger = indexOfAlphabet / AlphabetTypeOfMoney.Count;
					indexOfAlphabet = indexOfAlphabet % AlphabetTypeOfMoney.Count;
				
					alphabet = AlphabetTypeOfMoney[indexOfAlphabet];
					final = myMain.ToString("0.00") + alphabet + (howManyTimeBigger + 2); //because default is 2 => AA
				}
				
				return final;	
			}
		}
		public string ToReadableAlphabetV2 (string format = null)
		{
			if (isZero) return "0";
			// double res = _main * System.Math.Pow(10, Power);
			// return res.ToString("0.0000");

			double valueInDouble = _main * System.Math.Pow(10,Power);
			if (!double.IsInfinity(valueInDouble) && valueInDouble < 1000)
			{
				if (format != null)
				{
					return valueInDouble.ToString(format);
				}

				double floorValue = Mathf.Floor((float)valueInDouble);
				double howMany = valueInDouble - floorValue;
				if (howMany >= 0.01)
				{
					return valueInDouble.ToString("0.00");
				}
				//else if (howMany >= 0.001)
				//{
				//	return valueInDouble.ToString("0.000");
				//}
				else
				{
					return valueInDouble.ToString("0");
				}
			}

			double power = this.Power;
			string final ;
			//System.Math.Pow(10,Power) * _main;

			double myMain = 1; //because we will convert 2 to power of 10 => log10(2)
			double myPower = power + Math.Log10(_main);
			int result = (int)Math.Floor(myPower / 3);
			double remaining = myPower % 3;
			double remainingInRealValue = Math.Pow(10, remaining);
			if (remainingInRealValue > 0)
			{
				myMain = myMain * remainingInRealValue;
			}

			if (result < 5)
			{
				int indexOfAlphabet = result ;
				string alphabet = "";
				//Debug.Log("indexOfAlphabet : " + indexOfAlphabet);
				alphabet = DefaultTypeOfMoney[indexOfAlphabet];
				final = myMain.ToString("0.00") + alphabet;
			}
			else
			{
				int indexOfAlphabet = result - 5;

				string alphabet = "";
				if (indexOfAlphabet < AlphabetTypeOfMoney.Count)
				{
					alphabet = AlphabetTypeOfMoney[indexOfAlphabet];
					final = myMain.ToString("0.00") + alphabet + alphabet; // 2 of A => AA
				}
				else
				{
					int howManyTimeBigger = indexOfAlphabet / AlphabetTypeOfMoney.Count;
					indexOfAlphabet = indexOfAlphabet % AlphabetTypeOfMoney.Count;
				
					alphabet = AlphabetTypeOfMoney[indexOfAlphabet];
					final = myMain.ToString("0.00") + alphabet + (howManyTimeBigger + 2); //because default is 2 => AA
				}
			}

			
			return final;	
		}

		
		public static SMPNum ParseThatCanLoseSmallValue (string strNum)
		{
			/*
			SMPNum num ;
			//Debug.Log("STIRNG : " + strNum);
			if (strNum.Contains("E+"))
			{
				//STIRNG : 1E+192
				num = new SMPNum(SMPMoney.DoubleSIParse(strNum));
			}
			else
			if (strNum.Contains("+"))
			{
				//STIRNG : 2E383+698.97B
				string[] strArr = strNum.Split('+');
				string strMain = strArr[0].Substring(0, strArr[0].IndexOf('E'));
				// Debug.Log("strMain : " + strMain);
				double newMain = double.Parse(strMain);

				string strPower = strArr[0].Substring(strArr[0].IndexOf('E')+1);
				// Debug.Log("strPower : " + strPower);
				double newPower = SMPMoney.DoubleSIParse(strPower);

				double remaining = SMPMoney.DoubleSIParse(strArr[1]);
				remaining = remaining / System.Math.Pow(10,12);

				double realNewPower = newPower + remaining;
				double power = realNewPower - Math.Log10(2) + Math.Log10(newMain);
				double main = newMain - System.Math.Floor(power / 1000);

				//Debug.Log("Main : " + main);
				//Debug.Log("Power : " + power);

				num = SMPNum.FromPower(power);
				

			}else
			{
				//STIRNG : 1.00dd
				num = new SMPNum(SMPMoney.DoubleSIParse(strNum));
			}

			//num.DisplayDetails();

			*/

			SMPNum num ;
			if (strNum.ToUpper().Contains("E"))
			{
				//Debug.LogError("Full : " + strNum);
				//STIRNG : 1.23E192
				string[] strArr = strNum.ToUpper().Split('E');
				var strMain = strArr[0];
				var strPower = strArr[1];
				//Debug.LogError("strPower : " + strPower);
				var doublePower = double.Parse(strPower);
				var doubleMain = double.Parse(strMain);

				var powerIfMainIs2 = System.Math.Log10(doubleMain/_main);

				var finalPower = doublePower + powerIfMainIs2;
				num = SMPNum.FromPower(finalPower);
			}
			else
			{
				num = new SMPNum(SMPMoney.DoubleSIParse(strNum));
			}
			return num;
		}

		
		public bool IsIntInifinity ()
		{
			if (isZero)
			{
				return false;
			}
			double result = System.Math.Pow(10,Power) * _main;
			if (double.IsInfinity(result))
			{
				return true;
			}
			else {
				if (result > int.MaxValue)
				{
					return true;
				}
			}

			return false;
		}
		public int ToIntIfPossible ()
		{
			if (IsIntInifinity())
			{
				throw new OverflowException("Cannot convert to Integer it's become INFINITY");
			}
			else
			{
				double result = System.Math.Pow(10,Power) * _main;
				return (int)result;
			}
		}
		public bool IsFloatInifinity ()
		{
			if (isZero)
			{
				return false;
			}
			double result = System.Math.Pow(10,Power) * _main;
			if (double.IsInfinity(result))
			{
				return true;
			}
			else {
				if (result > float.MaxValue)
				{
					return true;
				}
			}

			return false;
		}
		public bool IsDoubleInifinity ()
		{
			if (isZero)
			{
				return false;
			}
			double result = System.Math.Pow(10,Power) * _main;
			if (double.IsInfinity(result))
			{
				return true;
			}

			return false;
		}
		public double ToDoubleIfPossible ()
		{
			if (isZero)
			{
				return 0;
			}
			
			double result = System.Math.Pow(10,Power) * _main;
			//double res = _main * System.Math.Pow(10, Power);
			if (double.IsInfinity(result))
			{
				throw new OverflowException("Cannot convert to double it's become INFINITY1");
			}
			return result;
		}

		public float ToFloatIfPossible (bool returnMaxFloatIfError = false)
		{
			if (isZero)
			{
				return 0;
			}
			
			double result = System.Math.Pow(10,Power) * _main;
			if (double.IsInfinity(result) || float.IsInfinity((float)result))
			{
				if (returnMaxFloatIfError) 
				{
					return float.MaxValue;
				}

				throw new OverflowException("Cannot convert to float it's become INFINITY1");
			}
			return (float)result;
		}


		private bool SupportLetterFormat (string _CurrentMoney)
		{
			if (_CurrentMoney == null)
			{
				return false;
			}
			// STEP 1 :Check if the string contain a money
			_CurrentMoney = GetRealValue (_CurrentMoney);

			if (_CurrentMoney == "Infinity")
			{
				return false;
			}

			if (_CurrentMoney == null)
			{
				Debug.LogError ("_CurrentMoney is null");
				return false;
			}
			if (_CurrentMoney.Count () > 3)
			{
				//Try to chatch the right type of money
				int _iTypeOfMoney = _CurrentMoney.Count () / 3;

				if (_CurrentMoney.Count () % 3 == 0) {
					if (_iTypeOfMoney-1 >= DefaultTypeOfMoney.Count)
					{
						return false;
					}
				}
				else {
					if (_iTypeOfMoney >= DefaultTypeOfMoney.Count)
					{
						return false;

					}
				}
			}

			return true;
		}
		public static string GetReadableAsLetterFormat (string _CurrentMoney)
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
					if (_iTypeOfMoney-1 >= DefaultTypeOfMoney.Count)
					{
						double result;
						if (double.TryParse (_CurrentMoney, out result)) {
							return result.ToString ("0.##E+0");	
						} else {
							return "MAX";
						}

					}
					_sTypeOfMoney = DefaultTypeOfMoney [_iTypeOfMoney - 1];
				}
				else {
					if (_iTypeOfMoney >= DefaultTypeOfMoney.Count)
					{
						double result;
						if (double.TryParse (_CurrentMoney, out result)) {
							return result.ToString ("0.##E+0");	
						} else {
							return "MAX";
						}

					}
					_sTypeOfMoney = DefaultTypeOfMoney [_iTypeOfMoney];
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
			//Get the Money without letter (ex get 85840 for 85,84K with the GetMoney function)
		public static string GetRealValue (string _CurrentMoney)
		{
			if (_CurrentMoney == null)
			{
				Debug.LogError ("_CurrentMoney is null");
				return null;
			}

			//Check if the string contain a money
			for (int i = 1; i < DefaultTypeOfMoney.Count; i++)
			{
				string _CurrentMoneyUpper = _CurrentMoney;//.ToUpper ();
				if (_CurrentMoney.Contains(DefaultTypeOfMoney[i]) || _CurrentMoneyUpper.Contains(DefaultTypeOfMoney[i]))
				{
					//Check the right letter and remove it
					//_CurrentMoney = _CurrentMoney.Replace(TypeOfMoney[i], "\0");
					_CurrentMoney = _CurrentMoney.Remove(_CurrentMoney.Length - DefaultTypeOfMoney[i].Length);

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
				double floorValue = Math.Floor(result);
				if (result - floorValue >= 0.01)
				{
					return result.ToString("0.00");
				}
				else if (result - floorValue >= 0.001)
				{
					return result.ToString("0.000");
				}
				else
				{
					return result.ToString ("0");
				}

			} else {
				return double.PositiveInfinity.ToString ();
			}
		}

		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

    public int CompareTo(object obj)
    {
		if (object.ReferenceEquals(obj, null))
        {
			return 1;
        }

		SMPNum otherNum = obj as SMPNum;
		if (!object.ReferenceEquals(otherNum, null))
        {
			if (otherNum.isZero)
            {
				return 1;
            }
			else
            {
				return this.Power.CompareTo(otherNum.Power);
            }
        }
		else
        {
			throw new ArgumentException("Object is not a SMPNum");
		}
    }
}