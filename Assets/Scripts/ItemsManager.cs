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
        { "143321", "item_1" },
        { "666777", "item_2" },
        { "65456", "item_3" },
        { "1124", "item_4" },
        { "9204", "item_5" },
        { "3243", "item_6" }
    };

    void Start()
    {
        foreach(var item in codes){
            print(item.Key);
            print(item.Value);
            int value = PlayerPrefs.GetInt(item.Key);
            if (value == 1) this.ShowItem(codes[item.Key]);
            

        }
    }

    public void AddItem()
    {
        string code = input.text;
        if(codes.ContainsKey(code)){
            this.ShowItem(codes[code]);
            PlayerPrefs.SetInt(code, 1); // Save it
            print("Saved " + code);
            PlayerPrefs.Save();
        }else if(code == "level01"){
            PlayerPrefs.SetInt("level", 1);
            PlayerPrefs.Save();
        }else if(code == "level02"){
            PlayerPrefs.SetInt("level", 2);
            PlayerPrefs.Save();
        }else if(code == "level03"){
            PlayerPrefs.SetInt("level", 3);
            PlayerPrefs.Save();
        }else if(code == "level04"){
            PlayerPrefs.SetInt("level", 4);
            PlayerPrefs.Save();
        }else if(code == "level05"){
            PlayerPrefs.SetInt("level", 5);
            PlayerPrefs.Save();
        }else if(code == "level06"){
            PlayerPrefs.SetInt("level", 6);
            PlayerPrefs.Save();
        }else if(code == "level07"){
            PlayerPrefs.SetInt("level", 7);
            PlayerPrefs.Save();
        }else if(code == "level08"){
            PlayerPrefs.SetInt("level", 8);
            PlayerPrefs.Save();
        }else if(code == "level09"){
            PlayerPrefs.SetInt("level", 9);
            PlayerPrefs.Save();
        }else if(code == "level10"){
            PlayerPrefs.SetInt("level", 10);
            PlayerPrefs.Save();
        }else if(code == "levelup"){
            GameManager.Instance.CurrentPlayer.AddQuest();
        }
        
        
        
        
        
        
        
        
        
        
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
