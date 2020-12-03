using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    #region Variables
    [SerializeField]
    string Scene = "Level1";
    #endregion
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void NewGame()
    {
        SceneManager.LoadScene(Scene);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR // if In Unity Editor
        EditorApplication.ExitPlaymode(); //Exits Playmode
#endif
        Application.Quit(); //Quits Application
    }
}
