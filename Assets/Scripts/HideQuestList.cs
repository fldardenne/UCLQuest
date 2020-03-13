using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideQuestList : MonoBehaviour
{
    public void OnClick(GameObject cc) {
        cc.SetActive(false);
    }
}
