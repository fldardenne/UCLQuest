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

    private GameObject currentInstance;


    void Start ()
    {
        SpawnQuestsFromCoordinates(GameManager.Instance.CurrentPlayer.Quest-1);
    }

    private void SpawnQuestsFromCoordinates(int i)
    {
        Vector2d[] locations = new Vector2d[quests.Length];

        locations[i] = Conversions.StringToLatLon(quests[i].locationString);

        currentInstance = Instantiate(POIQuest);
        currentInstance.transform.localPosition = map.GeoToWorldPosition(locations[i], true);


        currentInstance.transform.localPosition = new Vector3(currentInstance.transform.localPosition.x, currentInstance.transform.localPosition.y + height, currentInstance.transform.localPosition.z);
    }

     private void Update()
    {   
        
            Vector2d[] locations = new Vector2d[quests.Length];


            if (GameManager.Instance.CurrentPlayer.Quest-1 < quests.Length){
                locations[GameManager.Instance.CurrentPlayer.Quest-1] = Conversions.StringToLatLon(quests[GameManager.Instance.CurrentPlayer.Quest-1].locationString);
                // If the objects is not destroyed
                if(currentInstance != null){
                    var location = locations[GameManager.Instance.CurrentPlayer.Quest-1];
                    currentInstance.transform.localPosition = map.GeoToWorldPosition(location, true);
                    currentInstance.transform.localPosition = new Vector3(currentInstance.transform.localPosition.x, currentInstance.transform.localPosition.y + height, currentInstance.transform.localPosition.z);
                }else{ // If the previous object is destroyed, spawn the new one
                    
                    SpawnQuestsFromCoordinates(GameManager.Instance.CurrentPlayer.Quest-1);
                }

            }
            

            
            
    }
    
}
