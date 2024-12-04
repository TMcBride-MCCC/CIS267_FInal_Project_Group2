using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public GameObject player;

    public GameObject loadPath01;
    public GameObject loadPath02;
    public GameObject loadPath03;
    public GameObject loadFriendshouse;
    public GameObject loadCarePackage;

    public GameObject pauseMenu;
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
        }
        else if(Input.GetButtonDown("Cancel"))
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void restartGame()
    {
        SceneManager.LoadScene("StartScene");
        Time.timeScale = 1f;
    }

    public void exitGame()
    {
        Application.Quit();
    }


   

}
