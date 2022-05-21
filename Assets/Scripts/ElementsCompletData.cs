using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementsCompletData : MonoBehaviour
{

    public Sprite imageComplete;
    public int scoreForSuccess;
    public KeyCode[] chainCombination;
    // Start is called before the first frame update
    private void Awake()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            chainCombination[i] = gameObject.transform.GetChild(i).GetComponent<ElementsData>().inputToPress;
        }
    }

}
