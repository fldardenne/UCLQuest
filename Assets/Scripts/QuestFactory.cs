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
        int currentQuest = 1;
        for(int i=0; i<currentQuest; i++) ButtonScript.Show(buttons[i]); // If the level is loaded by the save, need to put old quest in history
        SpawnQuestsFromCoordinates(GameManager.Instance.CurrentPlayer.Quest-1);
    }

    private void SpawnQuestsFromCoordinates(int i)
    {
        print("HEY2");
        print(PlayerPrefs.GetInt("puzzle"));
        print("HEY3");
        //Show the quest on the list of quest 
        ButtonScript.Show(buttons[i]);
        if(i == 6 && PlayerPrefs.GetInt("puzzle") == 0) { //6
            print("HEY");
            PuzzleCanvas.SetActive(true);
        }
        if (i == 9 && PlayerPrefs.GetInt("mastermind") == 0) { //si on arrive à la quete du pc on lance le jeu correspondant (mastermind) à mettre à 11 normalement !!!
            mastermind.SetActive(true);
            
        }
        if (i == 7 && PlayerPrefs.GetInt("hiddenobject") == 0) {//si on arrive à la quete du pc on lance le jeu correspondant (hiddenobject) à mettre à 8 normalement !!!
            hiddenobject.SetActive(true);
        }

        //Set the next POI
        if (i+1 < quests.Length){
            Vector2d locations = Conversions.StringToLatLon(quests[i+1].locationString);
            currentInstance = Instantiate(POIQuest);
            currentInstance.transform.localPosition = map.GeoToWorldPosition(locations, true);
            currentInstance.transform.localPosition = new Vector3(currentInstance.transform.localPosition.x, currentInstance.transform.localPosition.y + height, currentInstance.transform.localPosition.z); 
        }
        DialogManager dialogManager = GameManager.Instance.cameraWithDialogManager.GetComponent<DialogManager>();
        if (!GameManager.Instance.CurrentPlayer.load_from_save && i!=6 && i!=9 && i != 7){ // If we load the game from the save then don't display the dialog
             // Set up the dialog and show it
            dialogManager.setDialogs(quests[i].dialogs);
            
            dialogManager.show();
            dialogManager.setImage(quests[i].path);
        }else{
            GameManager.Instance.CurrentPlayer.load_from_save = false;
            dialogManager.hide();
        }
        
       

        
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
