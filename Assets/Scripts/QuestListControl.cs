using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestListControl : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonTemplate;

    [SerializeField]
    private List<GameObject> buttons;

    void Start()
    {
        buttons = new List<GameObject>();
        
        if (buttons.Count > 0) // supprimer les boutons quand on les fait réapparaitre pour éviter les doublons
        {
            foreach (GameObject button in buttons)
            {
                Destroy(button.gameObject);
            }
            buttons.Clear();
        }
        for (int i = 1; i<10 ; i++){
            GenerateButton("Quest "+i);
        }
    }
    
    void GenerateButton(string questName)
    {
        GameObject button = Instantiate(buttonTemplate) as GameObject;

        button.GetComponent<ButtonScript>().SetText(questName);

        button.transform.SetParent(buttonTemplate.transform.parent, false);
    }
}
