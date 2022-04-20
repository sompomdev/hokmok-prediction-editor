using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SMPQuestItemList : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textGameLv;
    [SerializeField] private TextMeshProUGUI textTitle;

    private string questId;

    public void SetQuestId(string id)
    {
        questId = id;
    }
    public void SetTitle(string title)
    {
        textTitle.text = title;
    }

    public void SetGameLevel(string level)
    {
        textGameLv.text = level;
    }

    public bool Matching(string id)
    {
        return id == questId;
    }
    
}
