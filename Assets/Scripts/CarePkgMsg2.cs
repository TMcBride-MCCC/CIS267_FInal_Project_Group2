using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private GameObject objectiveMessage;
    private Image objectiveMessageImage;
    public Sprite nextObjective;
    public Bat bat;

    void Start()
    {
        //get the objectiveMessage
        objectiveMessage = GameObject.FindWithTag("Objective");
        //get the objective message image component
        objectiveMessageImage = objectiveMessage.GetComponent<Image>();

        //get the display message sprite renderer
        displayMessageSpriteRenderer = displayMessage.GetComponent<SpriteRenderer>();

        //get next level load box colldier
        nextLevelLoadBoxCollider = nextLevelLoadBox.GetComponent<Collider2D>();

        //get the Collider2D of this GameObject
        triggerCollider = GetComponent<Collider2D>();

        //the start of this is also the start of the scene, so we can use this to disable the "save friend" message when they load in
        objectiveMessageImage.enabled = false;

        bat = GameObject.FindObjectOfType<Bat>();
    }

    void Update()
    {
        if (isPlayerInTrigger && Input.GetButtonDown("Fire2"))
        {
            //enable the message popup
            displayMessageSpriteRenderer.enabled = true;

            //disable collider on box so script still runs
            triggerCollider.enabled = false;

            //enable transition to next level
            nextLevelLoadBoxCollider.enabled = true;

            isTimerRunning = true;

            //enable the message popup
            objectiveMessageImage.sprite = nextObjective;
            objectiveMessageImage.enabled = true;

            bat.batLevel3();

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
