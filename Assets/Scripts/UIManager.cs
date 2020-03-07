using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text questText;

    private void Awake ()
    {
        Assert.IsNotNull(questText);
    }

    private void Update()
    {
        updateQuest();
    }

    public void updateQuest()
    {
        questText.text = "Quete #" + GameManager.Instance.CurrentPlayer.Quest.ToString();
    }
}
