using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameManager : MonoBehaviour
{
    #region Objects and Components
    Player player;
    MenuManager menuManager;
    SaveData.Score[] highscores=new SaveData.Score[5];
    #endregion
    #region Variables
    int playerStart;
    [SerializeField]
    int height;
    [SerializeField]
    int maxHeight;

    [SerializeField]
    string playerName;
    #endregion
    #region Public Properties
    public int CurrentHeight => height;
    public int MaxHeight => maxHeight;
    #endregion
    
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        FindObjectsandComponents();
    }
    private void Start()
    {
        InitialiseVariables();
        LoadData();
    }
    private void FindObjectsandComponents()
    {
        player = FindObjectOfType<Player>();
        menuManager = FindObjectOfType<MenuManager>();
    }
    private void InitialiseVariables()
    {
        playerStart = (int)player.transform.position.y;
        maxHeight = playerStart;
    }

    private void Update()
    {
        Inputs();
        HeightCheck();
    }

    private void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuManager.QuitGame();
        }
    }

    private void HeightCheck()
    {
        height = (int)player.transform.position.y - playerStart;
        if (height > maxHeight)
        {
            maxHeight = height;
        }
    }
    public void PlayerDeath()
    {
 
            highscores[5].height = maxHeight;
            highscores[5].name = playerName;
            HighScoreSort();
    }
    public void SaveGame()
    {
   
    }
   public void LoadData()
    {

    }
    void HighScoreSort()
    {
        int l = highscores.Length;
        if (maxHeight>highscores[0].height)
        {
            highscores[0] = highscores[5];
            for (int i = 1; i < l; i++)
            {
                if (maxHeight>highscores[i].height)
                {
                    highscores[i - 1] = highscores[i];
                    highscores[i] = highscores[5];
                }
            }
        }
       
    }
}
