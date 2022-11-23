using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyCanvas : MonoBehaviour
{
    void Awake()
    {
        instance = this;
    }

    public void LoadPlayScene()
    {
        SceneManager.LoadScene(SceneName.PLAY);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public static LobbyCanvas instance = null;
    public Image dodgeImage;
    public Button startButton;
    public Button quitButton;
    public Setting setting;
}