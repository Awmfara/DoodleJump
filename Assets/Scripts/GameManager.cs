
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    

    #region Objects and Components
    Player player;
    MenuManager menuManager;
    public SaveData[] highscores = new SaveData[6];
    #endregion
    #region Variables
    [SerializeField]
    private string scene = "EndScene";
   

    int playerStart;
    int height;
    int maxHeight;

    [SerializeField]
    public InputField mainInputField;
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
    /// <summary>
    /// Assigns Objects and/or Components
    /// </summary>
    private void FindObjectsandComponents()
    {
        player = FindObjectOfType<Player>();
        menuManager = FindObjectOfType<MenuManager>();

    }
    /// <summary>
    /// Sets player start and sets intial maxheight to player start
    /// </summary>
    private void InitialiseVariables()
    {
        if (player!=null)
        {
            playerName = ("Phil");
            playerStart = (int)player.transform.position.y;
            maxHeight = playerStart;
        }
 
    }
    /// <summary>
    /// If player exists
    /// </summary>
    private void Update()
    {
        if (player!=null)
        {
            Inputs();
            HeightCheck();
        }
        
    }
    /// <summary>
    /// Pressing Escape Quits the Game
    /// </summary>
    private void Inputs()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuManager.QuitGame();
        }
    }
    /// <summary>
    /// Checks player transform against previous max height
    /// if Player reaches higher than maxheight becomes players height
    /// </summary>
    private void HeightCheck()
    {
        height = (int)player.transform.position.y - playerStart;
        if (height > maxHeight)
        {
            maxHeight = height;
        }
    }
    /// <summary>
    /// On death freezes time scale
    /// If player bgets on the score board game asks for input, otherwise score saver;
    /// If not loads high score table
    /// </summary>
    public void PlayerDeath()
    {
        Time.timeScale = 0;
        if (maxHeight>highscores[0].height)
        {
            mainInputField.gameObject.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(scene);
        }
        
        
    }
    /// <summary>
    /// Assigns player name based on input
    /// Assignes player to last score slot
    /// Checks score reorders table then loads end scene
    /// </summary>
    public void ScoreSaver()
    {
        playerName = mainInputField.text;
        highscores[5].height = maxHeight;
        highscores[5].name = playerName;
        HighScoreSort();
        SaveGame();
        LoadData();
        SceneManager.LoadScene(scene);
    }
    /// <summary>
    /// Creates save file with highscore names and heights Top5;
    /// </summary>
    /// <returns></returns>
    private Save SaveGameStats()
    {
        Save save = new Save();
        save.name1 = highscores[0].name;
        save.name2 = highscores[1].name;
        save.name3 = highscores[2].name;
        save.name4 = highscores[3].name;
        save.name5 = highscores[4].name;

        save.score1 = highscores[0].height;
        save.score2 = highscores[1].height;
        save.score3 = highscores[2].height;
        save.score4 = highscores[3].height;
        save.score5 = highscores[4].height;

        return save;
    }
    /// <summary>
    /// Saves Game to Binary File
    /// </summary>
    public void SaveGame()
    {
        Save save = SaveGameStats();
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/space1.sav");
        bf.Serialize(file, save);
        file.Close();
        Debug.Log("Game Saved");
    }
    /// <summary>
    /// LoadsBinary File
    /// Assignes scores to save file
    /// Assgins save files to save data
    /// </summary>
    public void LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/space1.sav"))

        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/space1.sav",
                                      FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();
            highscores[0].name = save.name1;
            highscores[1].name = save.name2;
            highscores[2].name = save.name3;
            highscores[3].name = save.name4;
            highscores[4].name = save.name5;

            highscores[0].height = save.score1;
            highscores[1].height = save.score2;
            highscores[2].height = save.score3;
            highscores[3].height = save.score4;
            highscores[4].height = save.score5;


            Debug.Log("GameIsLoaded");

        }

        else
        {
            Debug.Log("No Save File Exists");
        }
    }
    /// <summary>
    /// Checks new score among other scores; 
    /// Moves all scores beneath score down and slots in new score
    /// </summary>
    void HighScoreSort()
    {
        int l = highscores.Length;
        if (maxHeight > highscores[0].height)
        {
            highscores[0] = highscores[5];
            for (int i = 1; i < l; i++)
            {
                if (maxHeight > highscores[i].height)
                {
                    highscores[i - 1] = highscores[i];
                    highscores[i] = highscores[5];
                }
            }
        }

    }
    /// <summary>
    /// Destroys Game Managager on Reload
    /// </summary>
    public void SelfDestruct()
    {
        Destroy(this);
    }
}
