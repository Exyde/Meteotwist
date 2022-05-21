using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header ("Components")]
    public MeteoChooser _meteoChooser;
    private AudioSource _musicPlayer;

    [Header ("Player Data")]
    public float _score;
    public float _gameDuration = 60;
    float _currentGameTimer;



    #region Unity Callbacks

    private void Awake()
    {
        if (_meteoChooser == null) Debug.Log("No Meteo Chooser linked");
        _musicPlayer = GetComponent<AudioSource>();

    }
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
        _musicPlayer.Play();
    }

    public void RestartGame(){
        _currentGameTimer = _gameDuration;
    }

    public void EndGame(){
        Debug.Log("Game Ended");
    }

    #endregion

    void UpdateGameTimer(){
        _currentGameTimer -= Time.deltaTime;

        if (_gameDuration <= 0){
            _gameDuration = 0;
            this.EndGame();
        }
    } 
}
