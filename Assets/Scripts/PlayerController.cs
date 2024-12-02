using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRB;
    private Vector2 movement;
    public float movementSpeed;                                                                                          //Can be private later. Public for now for testing
    public GameObject noDestroy;
    public int currHealth;
    public int maxHealth;
    private bool playerDead = false;
    private Animator playerAnimator;


    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();

        currHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            AddHealth(10);
        }
    }

    //FixedUpdate is frame rate independent and should be used for physics objects
    private void FixedUpdate()
    {
        //Moving the player in fixed update stops jumping during movement
        movePlayer();
        changeAnimation();
    }

    private void OnMovement(InputValue value)
    {
        //Grabs the direction of the input
        movement = value.Get<Vector2>();
        //Debug.Log("Movement captured as: " +  movement);
    }

    private void movePlayer()
    {
        //Uses the direction of the input to move the player
        playerRB.MovePosition(playerRB.position + movement * movementSpeed * Time.deltaTime);

        //flip sprite to face the correct way.
        FlipPlayerSprite();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LoadPath01"))
        {
            DontDestroyOnLoad(noDestroy);
            SceneManager.LoadScene("Path01");
            gameObject.transform.position = new Vector3(transform.position.x - 20f, transform.position.y + 1, transform.position.z);
        }
        else if (collision.gameObject.CompareTag("LoadFriendHouse"))
        {
            DontDestroyOnLoad(noDestroy);
            SceneManager.LoadScene("FriendsHouse");
            gameObject.transform.position = new Vector3(transform.position.x - 50f, transform.position.y - 2.5f, transform.position.z);
        }
        else if (collision.gameObject.CompareTag("LoadPath02"))
        {
            DontDestroyOnLoad(noDestroy);
            SceneManager.LoadScene("Path02");
            gameObject.transform.position = new Vector3(transform.position.x - 1f, transform.position.y + 9f, transform.position.z);
        }
        else if (collision.gameObject.CompareTag("LoadCarePackageField"))
        {
            DontDestroyOnLoad(noDestroy);
            SceneManager.LoadScene("CarePackageField");
            gameObject.transform.position = new Vector3(transform.position.x + 1f, transform.position.y + 43f, transform.position.z);
        }
        else if (collision.gameObject.CompareTag("LoadPath03"))
        {
            DontDestroyOnLoad(noDestroy);
            SceneManager.LoadScene("Path03");
            gameObject.transform.position = new Vector3(transform.position.x - 25f, transform.position.y + 2f, transform.position.z);
        }
        else if (collision.gameObject.CompareTag("LoadFriendHouse2"))
        {
            DontDestroyOnLoad(noDestroy);
            SceneManager.LoadScene("FriendsHouse2");
            //Will need to change the position below
            gameObject.transform.position = new Vector3(transform.position.x - 50f, transform.position.y - 2.5f, transform.position.z);
        }
        else if (collision.gameObject.CompareTag("ZombieSpawner"))
        {
            collision.gameObject.GetComponent<ZombieSpawner>().spawnZombies();
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Zombielvl1"))
        {
            LVL1_ZombieController level1Z = collision.gameObject.gameObject.GetComponent<LVL1_ZombieController>();
            currHealth -= level1Z.returnDamage();
            //Debug.Log(currHealth);
            isDead();
        }
        else if (collision.gameObject.CompareTag("Zombielvl2"))
        {
            LVL2_ZombieController level2Z = collision.gameObject.gameObject.GetComponent<LVL2_ZombieController>();
            currHealth -= level2Z.returnDamage();
            //Debug.Log(currHealth);
            isDead();
        }
        else if (collision.gameObject.CompareTag("Zombielvl3"))
        {
            LVL3_ZombieController level3Z = collision.gameObject.gameObject.GetComponent<LVL3_ZombieController>();
            currHealth -= level3Z.returnDamage();
            //Debug.Log(currHealth);
            isDead();
        }
        else if(collision.gameObject.CompareTag("Apple"))
        {
            AppleController apple = collision.gameObject.GetComponent<AppleController>();
            currHealth += apple.getHealing();
            if (currHealth > maxHealth)
            {
                currHealth = maxHealth;
            }
            //Debug.Log(currHealth);
            Destroy(collision.gameObject);
        }
    }

    private void FlipPlayerSprite()
    {
        float inputHorizontal = Input.GetAxisRaw("Horizontal");

        if (inputHorizontal > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (inputHorizontal < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }

    private void changeAnimation()
    {
        //Will need to change this to KeyCodeDown & KeyCodeUp pairs
        //to switch from moving animations to idle animations

        //Running down
        if (Input.GetKey(KeyCode.S))
        {
            //The animation we want
            playerAnimator.SetBool("isRunningDown", true);
            //Set all other animations to false
            playerAnimator.SetBool("isRunningUp", false);
            playerAnimator.SetBool("isRunningRight", false);
            playerAnimator.SetBool("isIdleUp", false);
            playerAnimator.SetBool("isIdleRight", false);
        }
        //Running up
        if (Input.GetKeyDown(KeyCode.W))
        {
            //The animation we want
            playerAnimator.SetBool("isRunningUp", true);
            //Set all other animations to false
            playerAnimator.SetBool("isRunningDown", false);
            playerAnimator.SetBool("isRunningRight", false);
            playerAnimator.SetBool("isIdleUp", false);
            playerAnimator.SetBool("isIdleRight", false);
        }
        //Idle up
        if (Input.GetKeyUp(KeyCode.W))
        {
            //Idle animation set to true
            playerAnimator.SetBool("isIdleUp", true);
            //Walking animation set to false
            playerAnimator.SetBool("isRunningUp", false);
        }
        //Running right
        if (Input.GetKey(KeyCode.D))
        {
            //The animation we want
            playerAnimator.SetBool("isRunningRight", true);
            //Set all other animations to false
            playerAnimator.SetBool("isRunningUp", false);
            playerAnimator.SetBool("isRunningDown", false);
            playerAnimator.SetBool("isIdleUp", false);
            playerAnimator.SetBool("isIdleRight", false);
        }
    }

    private void isDead()
    {
        if (currHealth <= 0)
        {
            playerDead = true;
            //Destroy(this.gameObject);
        }
    }

    private void AddHealth(int h)
    {
        currHealth += h;

        if (currHealth > maxHealth)
        {
            currHealth = maxHealth;
        }

        Debug.Log("You have manually added " + h + " health");
    }
}
