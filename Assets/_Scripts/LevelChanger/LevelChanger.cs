using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public static LevelChanger Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        EventManager.Instance.EventWordSelected += LoadGameLevel;
    }
    public void LoadGameLevel()
    {
        LoadThisScene("WordLevel");
    }

    public void LoadStartMenu()
    {
        Debug.Log("startmenuac");
        LoadThisScene("StartMenu");
    }

    private void LoadThisScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
