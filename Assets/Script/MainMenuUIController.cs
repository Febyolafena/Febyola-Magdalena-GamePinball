using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIController : MonoBehaviour
{
    public Button playButton;
    public Button exitButton;
    public Button creaditButton;

    private void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(ExitGame);
        creaditButton.onClick.AddListener(CreaditGame);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Scene_GamePinball");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void CreaditGame()
    {
        SceneManager.LoadScene("Scene Credits");
    }
}
