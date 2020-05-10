using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterMindHide : MonoBehaviour
{
    public void OnClick(GameObject cc) {
        cc.SetActive(false);
        PlayerPrefs.SetInt("mastermind", 1);
    }
}
