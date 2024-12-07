using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveFriendScript : MonoBehaviour
{
    private Collider2D triggerCollider;
    private GameObject objectiveMessage;
    private Image objectiveMessageImage;
    private bool isPlayerInTrigger = false;
    public GameObject nextLevelLoadBox;
    private Collider2D nextLevelLoadBoxCollider;
    public Sprite nextObjective;

    public Bat bat;
    // Start is called before the first frame update
    void Start()
    {
        //get the objectiveMessage
        objectiveMessage = GameObject.FindWithTag("Objective");
        //get the objective message image component
        objectiveMessageImage = objectiveMessage.GetComponent<Image>();

        //get next level load box colldier
        nextLevelLoadBoxCollider = nextLevelLoadBox.GetComponent<Collider2D>();

        //get the Collider2D of this GameObject
        triggerCollider = GetComponent<Collider2D>();

        //the start of this is also the start of the scene, so we can use this to disable the "save friend" message when they load in
        objectiveMessageImage.enabled = false;

        bat = GameObject.FindAnyObjectByType<Bat>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInTrigger && Input.GetButtonDown("Fire2"))
        {
            //enable the message popup
            objectiveMessageImage.sprite = nextObjective;
            objectiveMessageImage.enabled = true;

            //disable collider on box so script still runs
            triggerCollider.enabled = false;

            //enable transition to next level
            nextLevelLoadBoxCollider.enabled = true;

            bat.batLevel2();
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
