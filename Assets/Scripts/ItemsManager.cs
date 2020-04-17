using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemsManager : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] InputField input;

    Dictionary<string, string> codes = new Dictionary<string, string>()
    {
        { "001", "item_1" },
        { "002", "item_2" },
        { "003", "item_3" },
        { "004", "item_4" },
        { "005", "item_5" },
        { "006", "item_6" }
    };

    void Start()
    {
        // Nothing
    }

    public void AddItem()
    {
       string code = input.text;

       this.ShowItem(codes[code]);
    }

    public void ShowItem(string item)
    {
        this.panel.transform.Find(item).gameObject.SetActive(true);
    }

    public void HideItem(string item)
    {
        this.panel.transform.Find(item).gameObject.SetActive(false);
    }
}
