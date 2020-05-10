using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Location;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;
using System;


public class Quest: MonoBehaviour {

    private void OnMouseDown()
    {
        Transform playerLoc = (Transform) GameManager.Instance.CurrentPlayer.GetComponent<Transform>();
        Transform objectLoc = (Transform) GetComponent<Transform>();

        if(!(Euclidean(playerLoc, objectLoc) > 7)){
            Destroy(gameObject);
            GameManager.Instance.CurrentPlayer.AddQuest();
        }
    }

     public static double Euclidean(Transform p1, Transform p2){
        return Math.Sqrt(Math.Pow(p1.localPosition.x - p2.localPosition.x, 2) + Math.Pow(p1.localPosition.z - p2.localPosition.z, 2));
    }

   
}
