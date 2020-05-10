using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenHide : MonoBehaviour
{
    public void OnClick(GameObject cc) {
        cc.SetActive(false);
    }
}
