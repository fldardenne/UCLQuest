using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    
    //private GameObject mybutton;

    public static void Show(GameObject button)
    {
        button.SetActive (true);
    }
}
