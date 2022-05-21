using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndGameLoader : MonoBehaviour
{
    public GameManager gm;
    public string _menuScene = "_Menu";
    public float _inputTimeBeforeLoadingMenu = 5f;
    private float timer;

    private void OnEnable()
    {
        timer = _inputTimeBeforeLoadingMenu;
    }

    private void OnDisable(){
    }

    private void Update(){

        if (timer > 0){
            timer -= Time.deltaTime;
        }

        if (Input.anyKey){
            gm.RestartGame();
        }


        if (timer <= 0){
            timer = 0;
            LoadMenu();
        }
    }

    void LoadMenu(){
        SceneManager.LoadScene(_menuScene);
    }
}
