using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class Gamemanager : MonoBehaviour
{
    public GameObject player;

    public GameObject loadPath01;
    public GameObject loadPath02;
    public GameObject loadPath03;
    public GameObject loadFriendshouse;
    public GameObject loadCarePackage;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;

    public bool pauseMenuActive = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pauseButtonPress();
    }

    public void pauseButtonPress()
    {
        if(Input.GetButtonDown("Submit"))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            pauseMenuActive = true;


            EventSystem.current.SetSelectedGameObject(null);

            EventSystem.current.SetSelectedGameObject(pauseMenu);

        }
        else if(Input.GetButtonDown("Cancel"))
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            pauseMenuActive = false;
        }
    }

    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        pauseMenuActive = false;
    }

    public void restartGame()
    {
        
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1f;
        pauseMenuActive=false;
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
    }

    public void exitGame()
    {
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        Application.Quit();
    }

    public void menu()
    {
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

    public void gameOver()
    {
        gameOverMenu.SetActive(true);
    }
   

}
