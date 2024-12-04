using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XmarkScript : MonoBehaviour
{
    private bool isPlayerInTrigger = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.F))
        {
            //if the player is in the X and presses F, do this
            Debug.Log("The player has dropped the flare");
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            isPlayerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            isPlayerInTrigger = false;
        }
    }
}
