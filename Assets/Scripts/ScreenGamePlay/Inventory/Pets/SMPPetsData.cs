/*//————————————————————————————————————————//
	Company Name : Sompom Game Studio 
	Developer Name 	: Mr.Puthear San
		Unity Developer
//————————————————————————————————————————//*/

using SimpleJSON;
using CodeStage.AntiCheat.ObscuredTypes;

namespace Sompom.Inventory
{
    public enum PetBonusSkillType
    {
        ALL_DAMAGE = 1,
        ALL_SUPPORTER_DAMAGE, //use for supports
        TAP_DAMAGE,
        ALL_GOLD
    }

    public class SMPPetsData
    {
        public int petID;
        public string petName;
        public ObscuredInt petCurrentLevel;
        public bool petIsUnlock;
		public bool petIsHire;

        public SMPPetRotation petRotation;

		public float petBaseDamage;
        //Pet Damage Increase Per Level between lv1-lv40
        public float petDamIncPerLvT1;
        //Pet Damage Increase Per Level between lv41-lv80
        public float petDamIncPerLvT2;
        //Pet Damage Increase Per Level more than lv80
        public float petDamIncPerLvT3;

        public PetBonusSkillType petBonusType;
        public float petBaseBonus;
        //Pet Bonus Increase Per Level
        public float petBoIncPerLv;

		public int petTotalCost;
		public SMPNum petTotalAttackDamage = new SMPNum(0);
		public float petTotalDamagePercent;
		public float petTotalBonusPercent;
		public float petTotalPassiveBonusPercent;
		public float petTotalPassiveDamagePercent;
		public SMPNum petAttackPassiveDamage = new SMPNum(0);
		public string petDescription;

        public SMPPetsData()
        {
            petRotation = new SMPPetRotation();
        }

        public SMPPetsData(string json)
        {
            var node = JSON.Parse(json);
            petID = node["petID"].AsInt;
            petName = node["petName"];
            petCurrentLevel = node["petCurrentLevel"].AsInt;
            petIsUnlock = node["petIsUnlock"].AsBool;
			petIsHire = node["petIsHire"].AsBool;
            petBaseDamage = node["petBaseDamage"].AsFloat;
            petDamIncPerLvT1 = node["petDamIncPerLvT1"].AsFloat;
            petDamIncPerLvT2 = node["petDamIncPerLvT2"].AsFloat;
            petDamIncPerLvT3 = node["petDamIncPerLvT3"].AsFloat;
            petBonusType = (PetBonusSkillType)node["petBonusType"].AsInt;
            petBaseBonus = node["petBaseBonus"].AsFloat;
            petBoIncPerLv = node["petBoIncPerLv"].AsFloat;
			petDescription = node["petDescription"];

            petRotation = new SMPPetRotation();

        }

        public void ValidatePetRotation ()
        {
			var periodRecover = SMPPetLevelConfiguration.GetPeriodFromStartRecover(this);

			if (periodRecover <= 0 
                && petRotation.state == SMPPetRotationState.RECOVERING
            )
            {
                petRotation.SetState(SMPPetRotationState.AVAILABLE);
                petRotation.ResetAttackCounter();
            }
        }

        JSONNode SaveToJSON()
        {
            JSONNode node = new JSONObject();
            node["petID"] = petID;
            node["petName"] = petName;
            node["petCurrentLevel"] = petCurrentLevel.ToInt();
            node["petIsUnlock"] = petIsUnlock;

            return node;
        }
    }
}