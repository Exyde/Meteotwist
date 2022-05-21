using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoChooser : MonoBehaviour
{
    public SymboleToDo[] symboleToShow;
    public Material show;
    public int score = 0;
    public int index;
    public GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        LoopGame();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(score);
        if (symboleToShow[index].numberOfButtonToPress == 2)
        {
            if (Input.GetKey(symboleToShow[index].input[0]) && (Input.GetKey(symboleToShow[index].input[1])))
            {
                score = score ++;
                
                LoopGame();
            }
        }

        if (symboleToShow[index].numberOfButtonToPress == 3)
        {
            if (Input.GetKey(symboleToShow[index].input[0]) && (Input.GetKey(symboleToShow[index].input[1])) && (Input.GetKey(symboleToShow[index].input[2])))
            {
                score = score ++;
                LoopGame();
            }
        }

        //Debug.Log(score);


    }

    void LoopGame()
    {
        index = 1;
        //Random.Range(0, 11)
        show = symboleToShow[index].toShow;
        cube.GetComponent<Renderer>().material = show;
    }
}
