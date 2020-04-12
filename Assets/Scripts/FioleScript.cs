using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FioleScript : MonoBehaviour
{
    [SerializeField] private GameObject retour;
    public void OnClick() {
        retour.SetActive(true);
    }
}
