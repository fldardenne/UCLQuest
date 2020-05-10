using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleHide : MonoBehaviour
{
    public void OnClick(GameObject cc) {
        cc.SetActive(false);
        PlayerPrefs.SetInt("puzzle", 1);
    }
}
