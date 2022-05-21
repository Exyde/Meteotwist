using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoChooser : MonoBehaviour
{
    public SymboleToDo[] symboleToShow;
    public Material show;
    public int score;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        LoopGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && (Input.GetKeyDown(KeyCode.Z) && (symboleToShow[0].active == true)))
        {
            symboleToShow[0].active = false;
            score = score++;
            LoopGame();
        }

        if (Input.GetKeyDown(KeyCode.E) && (Input.GetKeyDown(KeyCode.R) && symboleToShow[1].active == true))
        {
            symboleToShow[1].active = false;
            score = score++;
            LoopGame();
        }
    }

    void LoopGame()
    {
        index = Random.Range(0, 18);
        show = symboleToShow[index].toShow;
    }
}
