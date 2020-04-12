using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotate : MonoBehaviour
{
    public void OnClick(GameObject p)
    {
        if(!GameControlPuzzle.win)
        {
            p.transform.Rotate(0f, 0f, 90f);
        }
    }
}
