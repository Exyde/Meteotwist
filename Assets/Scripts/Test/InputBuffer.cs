using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBuffer : MonoBehaviour
{
    //Element 0 is Always none, don't know why.
    [HideInInspector]
    public List<KeyCode> inputs;

    private void OnGUI()
    {
        Event e = Event.current;

        if (e == null) return;

        if (e.isKey){            
            if (e.type == EventType.KeyDown){
                if (inputs.Contains(e.keyCode)) return;
                inputs.Add(e.keyCode);
            }

            if (e.type == EventType.KeyUp){
                if (inputs.Contains(e.keyCode)){
                    inputs.Remove(e.keyCode);
                }    
            }
        }
    }
}
