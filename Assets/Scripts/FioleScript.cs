using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FioleScript : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] private GameObject retour;
    public void OnClick() {
        this.panel.transform.Find("item_3").gameObject.SetActive(true);
        retour.SetActive(true);
        PlayerPrefs.SetInt("hiddenobject", 1);
    }
}
