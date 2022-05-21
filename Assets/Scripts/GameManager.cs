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
		ResetTimer();
		ResetScore();
		_musicPlayer.Play();
	}

	public void RestartGame(){
		ResetTimer();
		ResetScore();
	}

	public void EndGame(){
		Debug.Log("Game Ended");
	}

	#endregion

	#region Timer Methods
	void UpdateGameTimer(){
		_currentGameTimer -= Time.deltaTime;

		if (_gameDuration <= 0){
			_gameDuration = 0;
			this.EndGame();
		}
	}

	void ResetTimer() => _currentGameTimer = _gameDuration;
	#endregion

	#region Score Methods
	public void AddScore (int amout) => _score += amout;
	public void ResetScore() => _score = 0;
	#endregion
}
