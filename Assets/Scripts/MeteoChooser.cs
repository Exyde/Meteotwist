using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeteoChooser : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject[] allSymbole;
    public List<KeyCode> chainCombination = new List<KeyCode>();
    public GameObject show;
    public int score = 0;
    public int index = 0;
    
    [Range (1, 28)]
    public int randomDifficultySetting = 28;

    //Inputs
    private InputBuffer _inputBuffer;
    public List<KeyCode> playerInput;
    public Text DebugTextCombo;
    
    private void Awake()
    {
        _inputBuffer = GetComponent<InputBuffer>();
    }
    void Start()
    {
        LoopGame();
    }

    void Update()
    {
        CheckForCombo();
        // BruteForceCheckForCombo();
    }

    void CheckForCombo(){
        //List of all inputs : 
        playerInput = _inputBuffer.inputs;

        //How many symbole we need here.
        int currentComboRequiredSymbols = allSymbole[index].transform.childCount;

        if (DebugTextCombo != null){
            DebugTextCombo.text = "KEYS : ";

            foreach (KeyCode c in chainCombination){
                DebugTextCombo.text += c + " / ";
            }
        }
        
        if (currentComboRequiredSymbols != playerInput.Count) return;
        if (currentComboRequiredSymbols == playerInput.Count){

            //Compare both list
            foreach (KeyCode c in chainCombination){
                if (!playerInput.Contains(c)) return;
                Debug.Log ("Character " + c + " is inputs");
            }

            //Gm AddScore
            int scoreToAdd = currentComboRequiredSymbols * 10; 
            gameManager.AddScore(scoreToAdd);

            //Clear Chain
            chainCombination.Clear();

            //Loop Game
            LoopGame();
        }
    }

    void BruteForceCheckForCombo(){
        // Debug.Log(score);
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

        Debug.Log(score);
    }
    void LoopGame()
    {
        randomDifficultySetting = (int)gameManager._score / 10;
        randomDifficultySetting = Mathf.Clamp(randomDifficultySetting, 0, 28);
       // index = Random.Range(0, randomDifficultySetting);
        index = 36;
        //Random.Range(0, 11)
        for (int i = 0; i < allSymbole[index].transform.childCount; i++)
        {
            chainCombination.Add(allSymbole[index].transform.GetChild(i).GetComponent<ElementsData>().inputToPress);

        }
        
        show.GetComponentInChildren<SpriteRenderer>().sprite = allSymbole[index].GetComponent<ElementsCompletData>().imageComplete;
    }
}
