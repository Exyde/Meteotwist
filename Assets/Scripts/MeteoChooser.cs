using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoChooser : MonoBehaviour
{
    public GameObject[] allSymbole;
    public List<KeyCode> chainCombination = new List<KeyCode>();
    public GameObject show;
    public int score = 0;
    public int index = 0;

    // Start is called before the first frame update
    private void Awake()
    {
        
    }


    void Start()
    {
       

        LoopGame();

    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(score);
        if (allSymbole[index].transform.childCount == 2)
        {
            if (Input.GetKey(chainCombination[0]) && (Input.GetKey(chainCombination[1])))
            {
                score = score + 1;
                chainCombination.Clear();
                LoopGame();
                
            }
        }

        if (allSymbole[index].transform.childCount == 3)
        {
            if (Input.GetKey(chainCombination[0]) && (Input.GetKey(chainCombination[1])) && (Input.GetKey(chainCombination[2])))
            {
                score = score + 1;
                Debug.Log("marche");
                chainCombination.Clear();
                LoopGame();
            }
        }

        //Debug.Log(score);


    }

    void LoopGame()
    {
        index = Random.Range(0, 18);
        //Random.Range(0, 11)
        for (int i = 0; i < allSymbole[index].transform.childCount; i++)
        {
            chainCombination.Add(allSymbole[index].transform.GetChild(i).GetComponent<ElementsData>().inputToPress);

        }
        
        show.GetComponentInChildren<SpriteRenderer>().sprite = allSymbole[index].GetComponent<ElementsCompletData>().imageComplete;
    }
}
