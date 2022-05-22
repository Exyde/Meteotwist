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

    //Time before player action.
    public float actionDelayTimer = 2f;
    bool canSkip = false;

    private void OnEnable()
    {
        timer = _inputTimeBeforeLoadingMenu;
        canSkip = false;
        actionDelayTimer = 2f;
    }

    private void OnDisable(){
    }

    private void Update(){


        if (actionDelayTimer > 0 && !canSkip){
            actionDelayTimer -= Time.deltaTime;
        }

        if (actionDelayTimer <= 0 && !canSkip){
            actionDelayTimer = 0;
            canSkip = true;
        }

        if (!canSkip) return;
        HandleRestartOrLoad();
    }

    void HandleRestartOrLoad(){
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
