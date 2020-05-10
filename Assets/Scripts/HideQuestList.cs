using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class HideQuestList : MonoBehaviour
{
    public void OnClick(GameObject cc) {
        cc.SetActive(false);
    }

    public void ExitGame() {
        Application.Quit();
    }

    public void ResetGame(GameObject canvas) {
        PlayerPrefs.DeleteAll();
        Application.Quit();
        canvas.SetActive(false);
    }
}
