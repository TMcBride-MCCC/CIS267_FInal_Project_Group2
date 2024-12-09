using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class WinScreenScript : MonoBehaviour
{
    public GameObject firstButton;
    public Gamemanager gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager = GameObject.FindObjectOfType<Gamemanager>();
        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(firstButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToMenu()
    {
        gamemanager.destroyPlayer();
        SceneManager.LoadScene("MainMenu");
    }
}
