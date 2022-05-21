using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string _gameSceneName = "_Game";

    void Update()
    {
        if (Input.anyKey){
            LoadGame();
        }
    }

    void LoadGame(){
        SceneManager.LoadScene(_gameSceneName);
    }
}
