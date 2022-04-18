using SimpleJSON;

public enum SkillShopButtonType
{
	SPECIAL_MOVE = 0,
	FREE,
	DIAMON_PURCHASE,
	REMOVE_ADS_PURCHASE
}

[System.Serializable]
public class ShopSkillData
{
	public int ID { get; set; }
	public string m_descrition1 { get; set; }
	public string m_iconId { get; set; }

	public SkillShopButtonType m_type_item { get; set; }
	public string m_packName { get; set; }
	public string m_Gems_Count { get; set; }
	public string m_Currency { get; set; }

	public string m_ClassSkillName { get; set; }

	public ShopSkillData() { }
	public ShopSkillData(string fromJsonString)
	{
		if (!string.IsNullOrEmpty(fromJsonString))
		{
			var node = JSON.Parse(fromJsonString);
			ID = node["ID"].AsInt;
			m_descrition1 = node["m_descrition1"];
			m_iconId = node["m_iconId"];
			m_type_item = (SkillShopButtonType)node["m_type_item"].AsInt;
			m_packName = node["m_packName"];
			m_Gems_Count = node["m_Gems_Count"];
			m_ClassSkillName = node["m_ClassSkillName"];
		}
	}
}
