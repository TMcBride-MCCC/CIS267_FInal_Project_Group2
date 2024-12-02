using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarePkgMsg2 : MonoBehaviour
{
    public GameObject displayMessage;
    public GameObject nextLevelLoadBox;
    private SpriteRenderer displayMessageSpriteRenderer;
    private Collider2D triggerCollider;
    private Collider2D nextLevelLoadBoxCollider;
    private bool isPlayerInTrigger = false;
    private bool isTimerRunning = false;
    private float timer = 6f;

    void Start()
    {
        //get the display message sprite renderer
        displayMessageSpriteRenderer = displayMessage.GetComponent<SpriteRenderer>();

        //get next level load box colldier
        nextLevelLoadBoxCollider = nextLevelLoadBox.GetComponent<Collider2D>();

        //get the Collider2D of this GameObject
        triggerCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.F))
        {
            //enable the message popup
            displayMessageSpriteRenderer.enabled = true;

            //disable collider on box so script still runs
            triggerCollider.enabled = false;

            //enable transition to next level
            nextLevelLoadBoxCollider.enabled = true;

            isTimerRunning = true;
        }

        //count down timer
        if (isTimerRunning)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                //delete both the message and the box collider
                Destroy(displayMessage);
                Destroy(gameObject);
            }
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
