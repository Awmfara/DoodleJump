using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//Sets score to text box
public class Scorer : MonoBehaviour
{
    GameManager gameManager;

    private Text highScore = default;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        highScore = GetComponent<Text>();
    }
    private void Update()
    {
        highScore.text = "Max Height = "+gameManager.MaxHeight+"\n"+
                         "Current Height="+gameManager.CurrentHeight;
    }

}
