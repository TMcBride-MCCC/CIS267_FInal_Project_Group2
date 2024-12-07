using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using TMPro;

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
    public GameObject firstButtonPushed;
    public GameObject restartSelect;

    public GameObject doNotDestroy;

    private PlayerController playerController;

    public TMP_Text scoreText;


    public bool pauseMenuActive = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag ("Player");
        //doNotDestroy = GameObject.FindGameObjectWithTag("DoNotDestroyOnLoad");
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        pauseButtonPress();
    }

    public void pauseButtonPress()
    {
        if(Input.GetButtonDown("Fire3"))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            pauseMenuActive = true;


            EventSystem.current.SetSelectedGameObject(null);

            EventSystem.current.SetSelectedGameObject(firstButtonPushed);

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
        Destroy(doNotDestroy);
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1f;

        pauseMenuActive=false;
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
    }

    public void exitGame()
    {
        
        Application.Quit();
    }

    public void menu()
    {
        Destroy (doNotDestroy);
        SceneManager.LoadScene("MainMenu");
        gameOverMenu.SetActive(false);
        pauseMenu.SetActive(false);
    }

    public void gameOver()
    {

        int finalScore = playerController.getScore();

        gameOverMenu.SetActive(true);

        scoreText.SetText("Score " +  finalScore);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(restartSelect);
    }
   

}
