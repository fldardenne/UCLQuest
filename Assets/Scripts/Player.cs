using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private int quest = 1;

    public int Quest
    {
        get { return quest; }
    }

    public void AddQuest()
    {
        this.quest = this.quest + 1;
    }
}
