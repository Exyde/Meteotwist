using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBuffer : MonoBehaviour
{

    public List<KeyCode> inputs;



    void Update()
    {
        if (Input.inputString){
            Debug.Debug.Log((Input.inputString));
        }
    }
}
