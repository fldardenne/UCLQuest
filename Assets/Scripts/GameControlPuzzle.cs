using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlPuzzle : MonoBehaviour
{
    [SerializeField]
    private Transform[] image;

    [SerializeField]
    private GameObject ButtonPuzzle;

    public static bool win;
    // Start is called before the first frame update
    void Start()
    {
        ButtonPuzzle.SetActive(false);
        win = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(image[0].rotation.z == 0 &&
           image[1].rotation.z == 0 &&
           image[2].rotation.z == 0 &&
           image[3].rotation.z == 0 &&
           image[4].rotation.z == 0 &&
           image[5].rotation.z == 0 &&
           image[6].rotation.z == 0 &&
           image[7].rotation.z == 0 &&
           image[8].rotation.z == 0 &&
           image[9].rotation.z == 0 &&
           image[10].rotation.z == 0 &&
           image[11].rotation.z == 0 &&
           image[12].rotation.z == 0 &&
           image[13].rotation.z == 0 &&
           image[14].rotation.z == 0 &&
           image[15].rotation.z == 0 &&
           image[16].rotation.z == 0 &&
           image[17].rotation.z == 0 &&
           image[18].rotation.z == 0 &&
           image[19].rotation.z == 0)
           {
               win = true;
               ButtonPuzzle.SetActive(true);
           }

    }
}
