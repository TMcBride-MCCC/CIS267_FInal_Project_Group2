using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    public GameObject firstButton;
    public GameObject creditsClose;
    public GameObject creditsOpen;

    public GameObject menu;
    public GameObject optionsMenu;
    public void PlayGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartScene");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Credits()
    {

    }

    public void ExitGame()
    {
        Application.Quit();
    }


    void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(firstButton);
    }


    public void creditsBtn()
    {
        optionsMenu.SetActive(true);
        //menu.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(creditsOpen);
    }

    public void creditsCloseBtn()
    {
        optionsMenu.SetActive(false);
        //menu.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(creditsClose);
    }
}
