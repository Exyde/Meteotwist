using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBuffer : MonoBehaviour
{
    [Header ("Game Mapping")]
    public List<KeyCode> mapping;

    [HideInInspector]
    public List<KeyCode> inputs;

    public float timeBtwBuffer = .1f;
    public float timeBuffer = 0;


    void Update(){

        if (Input.anyKey){
            timeBuffer = 0;

        }

        foreach (KeyCode k in mapping){
            HandleInput (k);
        }

        if (timeBuffer < timeBtwBuffer){
            timeBuffer += Time.deltaTime;
        }

        if (timeBuffer > timeBtwBuffer){
            timeBuffer = 0;
            inputs.Clear();
        }

    }

    void HandleInput (KeyCode key){
        // if (Input.GetKeyUp(key)){
        //     if (inputs.Contains(key)){
        //         inputs.Remove(key);
        //     };
        // }
        if (Input.GetKeyDown(key)){
            if (inputs.Contains(key)) return;
            inputs.Add(key);
        }
    }

    public void Clear(){
            inputs.Clear();
    }

    // private void OnGUI()
    // {
    //     Event e = Event.current;

    //     if (e == null) return;

    //     if (e.isKey){            
    //         if (e.type == EventType.KeyDown){
    //             if (inputs.Contains(e.keyCode)) return;
    //             inputs.Add(e.keyCode);
    //         }

    //         if (e.type == EventType.KeyUp){
    //             if (inputs.Contains(e.keyCode)){
    //                 inputs.Remove(e.keyCode);
    //             }    
    //         }
    //     }
    // }
}
