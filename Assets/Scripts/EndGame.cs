using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    #region Objects and Components
    GameManager gameManager;
    MenuManager menuManager;
    #endregion
    #region Variables
    [SerializeField]
    private Text[] names=default;
    [SerializeField]
    private Text[] scores=default;
    #endregion

    private void Awake()
    {
        SetObjectsandComponents();
    }
    /// <summary>
    /// Assigns Objects and/or components
    /// </summary>
    private void SetObjectsandComponents()
    {
        gameManager = FindObjectOfType<GameManager>();
        menuManager = FindObjectOfType<MenuManager>();
    }

    void Start()

    {
        DisplayScores();
    }
    /// <summary>
    /// takes the scores from gamemanager.HighScores and displays them on UI. 
    /// If there is not a lowest score displays nothing for number
    /// </summary>
    private void DisplayScores()
    {
        for (int i = 0; i < names.Length; i++)
        {
            names[i].text = gameManager.highscores[i].name;
            if (gameManager.highscores[i].height > 0)
            {
                scores[i].text = ("" + gameManager.highscores[i].height);
            }
            else
            {
                scores[i].text = ("");
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        ContinueOptions();
    }
    /// <summary>
    /// Chooses whether to continue or quit game.  
    /// Quit Game Exits Application
    /// Continuing starts the time scale destroys currrent game manager and starts a new game;
    /// </summary>
    private void ContinueOptions()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            Time.timeScale = 1;
            gameManager.SelfDestruct();
            menuManager.NewGame();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            menuManager.QuitGame();
        }
    }
}
