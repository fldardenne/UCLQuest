using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowQuestList : MonoBehaviour
{

    [SerializeField]
    //private GameObject listQuestCanvas;
    // Start is called before the first frame update
    public void OnClick(GameObject cc) {
        cc.SetActive(true);
    }
}
