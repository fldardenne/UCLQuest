using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject Inventory;
    public GameObject ButtonInventory;

    public void Show()
    {
        if (Inventory != null)
        {
            Inventory.SetActive(true);
            ButtonInventory.SetActive(false);

        }
    }

    public void Hide()
    {
        if (Inventory != null)
        {
            Inventory.SetActive(false);
            ButtonInventory.SetActive(true);
        }
    }
}
