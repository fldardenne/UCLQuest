using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using Mapbox.Utils;
using Mapbox.Unity.Map;
using Mapbox.Unity.Utilities;

public class QuestFactory : MonoBehaviour
{
    [SerializeField] private GameObject POIQuest;
    [SerializeField] AbstractMap map;
    [SerializeField] float height;

    private string[] availableQuestsCoordinates =  new string[] {
        "50.669966,4.6161605"
    };

    void Start ()
    {
        SpawnQuestsFromCoordinates(0);
    }

    private void SpawnQuestsFromCoordinates(int i)
    {
        Vector2d[] locations = new Vector2d[availableQuestsCoordinates.Length];

        locations[i] = Conversions.StringToLatLon(availableQuestsCoordinates[i]);

        var instance = Instantiate(POIQuest);
        instance.transform.localPosition = map.GeoToWorldPosition(locations[i], true);

        Debug.Log(map.GeoToWorldPosition(locations[i], true));

        instance.transform.localPosition = new Vector3(instance.transform.localPosition.x, instance.transform.localPosition.y + height, instance.transform.localPosition.z);
    }
}
