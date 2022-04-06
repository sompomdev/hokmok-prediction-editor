using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGrid : MonoBehaviour
{
	public List<QuestData> questDatas;

	[SerializeField]
	private GameObject prefab;
	[SerializeField]
	private RectTransform content;

	private List<QuestItem> questItems = new List<QuestItem>();

	private void Start()
	{
		DoRefreshRatio();
	}

	public void DoRefreshRatio()
	{
		var questWithRatio = gameObject.GetComponent<QuestScoreDefineService>().QuestRatioDefine(questDatas);
		ShowQuest(questWithRatio);
	}

	public void ShowQuest(List<QuestData> qds)
	{
		CheckAndClear();
		foreach(var q in qds)
		{
			Clone(q);
		}
		ResizeContent(qds.Count);
	}

	private void CheckAndClear()
	{
		if(questItems.Count > 0)
		{
			foreach(var q in questItems)
			{
				Destroy(q.gameObject);
			}
			questItems.Clear();
		}
	}

	private void Clone(QuestData q)
	{
		GameObject p = Instantiate(prefab);
		p.transform.SetParent(content);
		p.transform.localPosition = Vector3.zero;
		p.transform.localScale = Vector3.one;
		p.SetActive(true);

		var item = p.GetComponent<QuestItem>();
		item.tmpId.text = q.questId.ToString();
		item.tmpName.text = q.questName;
		item.tmpValue.text = q.score.ToString();
		questItems.Add(item);
	}

	private void ResizeContent(int count)
	{
		GridLayoutGroup gridLayout = content.GetComponent<GridLayoutGroup>();
		float heightPerItem = gridLayout.cellSize.y + gridLayout.spacing.y;
		int cell_number = gridLayout.constraintCount;
		float height = heightPerItem * Mathf.FloorToInt((float)count / (float)cell_number);
		gridLayout.GetComponent<RectTransform>().sizeDelta = new Vector2(0, height);
	}
}
