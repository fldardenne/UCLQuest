using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int quest = 1;
    public bool load_from_save = false;

    void Start(){
        int level = PlayerPrefs.GetInt("level"); // Get the saved level 
        print("Loading level from the save: " + level);
        if(level > 0){
            this.quest = level;
            this.load_from_save = true;
        }
    }

    public int Quest
    {
        get { return quest; }
    }

    public void AddQuest()
    {
        this.quest = this.quest + 1;
        PlayerPrefs.SetInt("level", this.quest);
        PlayerPrefs.Save();
    }
}
