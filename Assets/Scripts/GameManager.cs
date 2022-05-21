using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float _gameDuration = 60;
    float _currentGameTimer;

    #region Unity Callbacks
    void Start()
    {
        SetupGame();
    }

    void Update()
    {
        UpdateGameTimer();
    }

    #endregion

    #region Main Game Events
    public void SetupGame(){
        _currentGameTimer = _gameDuration;
    }

    public void RestartGame(){
        _currentGameTimer = gameDuration;
    }

    public void EndGame(){
        Debug.Log("Game Ended");
    }

    #endregion

    void UpdateGameTimer(){
        _currentGameTimer -= Time.deltaTime;

        if (gameDuration <= 0){
            gameDuration = 0;
            this.EndGame();
        }
    } 
}
