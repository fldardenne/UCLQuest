using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject Inventory;

    public void Show()
    {
        if (Inventory != null)
        {
            Inventory.SetActive(true);
        }
    }

    public void Hide()
    {
        if (Inventory != null)
        {
            Inventory.SetActive(false);
        }
    }
}
