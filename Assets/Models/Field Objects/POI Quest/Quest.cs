using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    private void OnMouseDown()
    {
        GameManager.Instance.CurrentPlayer.AddQuest();
        Destroy(gameObject);
    }
}
