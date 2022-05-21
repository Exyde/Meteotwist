using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	[Header ("Components")]
	public MeteoChooser _meteoChooser;
	private AudioSource _musicPlayer;
	
	[Header ("Canvas Ref")]
	public GameObject _endGameCanvas;
	public Text _textScore;

	[Header ("Player Data")]
	public float _score;
	public float _gameDuration = 60;

	[Header ("Debug")]
	public float _currentGameTimer;
	public bool isPlaying = false;

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

		//_musicPlayer.Play();
		_endGameCanvas.SetActive(false);
		isPlaying = true;
	}

	public void RestartGame(){
		ResetTimer();
		ResetScore();

		_endGameCanvas.SetActive(false);
		isPlaying = true;
	}

	public void EndGame(){
		Debug.Log("Game Ended");
		UpdateScoreText();
		_endGameCanvas.SetActive(true);
		isPlaying = false;
	}

	#endregion

	#region Timer Methods
	void UpdateGameTimer(){

		if (_currentGameTimer > 0){
			_currentGameTimer -= Time.deltaTime;
		}

		if (_currentGameTimer <= 0 && isPlaying){
			_currentGameTimer = 0;
			EndGame();
		}
	}

	void ResetTimer() => _currentGameTimer = _gameDuration;
	#endregion

	#region Score Methods
	public void AddScore (int amout){
		_score += amout;
		UpdateScoreText();
	}

	public void UpdateScoreText() => _textScore.text = "Score : " + _score;
	public void ResetScore() => _score = 0;
	#endregion
}
