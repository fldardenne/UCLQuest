using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private Player currentPlayer;
    [SerializeField] public Camera cameraWithDialogManager;


    public Player CurrentPlayer
    {
        get { return currentPlayer; }
    }

    private void Awake()
    {
        Assert.IsNotNull(currentPlayer);
    }
}
