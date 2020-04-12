using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Mapbox.Utils;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;

public class QuestFactory : MonoBehaviour
{

    [System.Serializable]
    class Quest
    {
        public string title;
		public string locationString;
        public string[] dialogs;
        public string path;
        
    }

    [SerializeField] private Quest[] quests;

    
    [SerializeField] private GameObject POIQuest;
    [SerializeField] AbstractMap map;
    [SerializeField] float height;
    [SerializeField] private GameObject mastermind;
    [SerializeField] private GameObject hiddenobject;
    [SerializeField] private GameObject[] buttons;

    [SerializeField] private GameObject PuzzleCanvas;

    private GameObject currentInstance;

    private bool finish = false;

    void Start ()
    {
        SpawnQuestsFromCoordinates(GameManager.Instance.CurrentPlayer.Quest-1);
    }

    private void SpawnQuestsFromCoordinates(int i)
    {
        //Show the quest on the list of quest 
        ButtonScript.Show(buttons[i]);
        if(i == 0) {
            PuzzleCanvas.SetActive(true);
        }
        if (i == 9) { //si on arrive à la quete du pc on lance le jeu correspondant (mastermind) à mettre à 9 normalement !!!
            mastermind.SetActive(true);
            
        }
        if (i == 1) {//si on arrive à la quete du pc on lance le jeu correspondant (hiddenobject) à mettre à 7 normalement !!!
            hiddenobject.SetActive(true);
        }

        //Set the next POI
        if (i+1 < quests.Length){
            Vector2d locations = Conversions.StringToLatLon(quests[i+1].locationString);
            currentInstance = Instantiate(POIQuest);
            currentInstance.transform.localPosition = map.GeoToWorldPosition(locations, true);
            currentInstance.transform.localPosition = new Vector3(currentInstance.transform.localPosition.x, currentInstance.transform.localPosition.y + height, currentInstance.transform.localPosition.z); 
        }

        // Set up the dialog and show it
        DialogManager dialogManager = GameManager.Instance.cameraWithDialogManager.GetComponent<DialogManager>();
        dialogManager.setDialogs(quests[i].dialogs);
        
        dialogManager.show();
        dialogManager.setImage(quests[i].path);

        
    }

     private void Update()
    {   
        
            Vector2d[] locations = new Vector2d[quests.Length];

            if (!finish){

                if(GameManager.Instance.CurrentPlayer.Quest < quests.Length){ // Update the position
                    locations[GameManager.Instance.CurrentPlayer.Quest-1] = Conversions.StringToLatLon(quests[GameManager.Instance.CurrentPlayer.Quest].locationString);
                }
                if(currentInstance != null){ // If the objects is not destroyed
                    var location = locations[GameManager.Instance.CurrentPlayer.Quest-1];
                    currentInstance.transform.localPosition = map.GeoToWorldPosition(location, true);
                    currentInstance.transform.localPosition = new Vector3(currentInstance.transform.localPosition.x, currentInstance.transform.localPosition.y + height, currentInstance.transform.localPosition.z);
                }else{ // If the previous quest is destroyed, spawn the new one
                    SpawnQuestsFromCoordinates(GameManager.Instance.CurrentPlayer.Quest-1);
                    if(GameManager.Instance.CurrentPlayer.Quest == quests.Length) finish = true; // For the last dialog
                }
            }   
    }
    
}
