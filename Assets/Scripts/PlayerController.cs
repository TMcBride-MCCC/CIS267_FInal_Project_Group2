using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRB;
    private Animator playerAnimator;
    private Inventory playerInventory;

    private Vector2 movement;
    public float movementSpeed;                                                                                          //Can be private later. Public for now for testing
    public GameObject noDestroy;
    public int currHealth;
    public int maxHealth;
    private bool playerDead = false;
    public Gamemanager gamemanager;

    public int playerScore = 0;

    public bool inTrigger1 = false;
    public bool loadCarePackage = false;
    public bool loadEndGame = false;

    public AudioSource deathSound;
    //public AudioClip clip;
    public AudioSource running;
    public AudioSource apple;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerInventory = GetComponentInChildren<Inventory>();
        

        currHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        cheatCodes();

        changeAnimation();

        if (Input.GetKeyDown(KeyCode.E))
        {
            eatApple();
        }

        if (Input.GetButtonDown("Jump"))
        {
            eatApple();
        }

        if(inTrigger1 && Input.GetButtonDown("Submit"))
        {
            DontDestroyOnLoad(noDestroy);
            SceneManager.LoadScene("FriendsHouse");
            gameObject.transform.position = new Vector3(-8f, -3f, transform.position.z);
        }

        if(loadCarePackage && Input.GetButtonDown("Submit"))
        {
            DontDestroyOnLoad(noDestroy);
            SceneManager.LoadScene("CarePackageField");
            gameObject.transform.position = new Vector3(1, 8, transform.position.z);
        }

        if (loadEndGame && Input.GetButtonDown("Submit"))
        {
            DontDestroyOnLoad(noDestroy);
            SceneManager.LoadScene("FinalLevel");
            //Will need to change the position below
            gameObject.transform.position = new Vector3(11, -1, transform.position.z);
        }
    }

    //FixedUpdate is frame rate independent and should be used for physics objects
    private void FixedUpdate()
    {
        //Moving the player in fixed update stops jumping during movement
        movePlayer();
        PlayerMoving();
    }

    private void PlayerMoving()
    {
        Vector3 playerVelo = playerRB.velocity;

        Vector3 zero = Vector3.zero;

        if(playerVelo != zero)
        {
            running.Play();
        }
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
        running.Play();

        //We no longer need this to flip the player
        //The animations flips the player
        //Can we use this to change the position of the bat?
        //flipPlayerSprite();
    }

    private void flipPlayerSprite()
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
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        playerAnimator.SetFloat("Horizontal", movement.x);
        playerAnimator.SetFloat("Vertical", movement.y);
        playerAnimator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void eatApple()
    {
        for (int i = 0; i < playerInventory.inventory.Count; i++)
        {
            if (playerInventory.inventory[i].ItemData.displayName == "Green Apple")
            {
                apple.Play();
                //Debug.Log("You eat a green apple");
                addHealth(10);
                playerInventory.Remove(playerInventory.inventory[i].ItemData);
            }
        }
    }

    private void cheatCodes()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            addHealth(10);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LoadPath01"))
        {
            DontDestroyOnLoad(noDestroy);
            SceneManager.LoadScene("Path01");
            gameObject.transform.position = new Vector3(-8f, -0.5f, transform.position.z);
        }
        else if (collision.gameObject.CompareTag("LoadFriendHouse"))
        {
            DontDestroyOnLoad(noDestroy);
            SceneManager.LoadScene("FriendsHouse");
            gameObject.transform.position = new Vector3(-8f, -3f, transform.position.z);
        }
        else if (collision.gameObject.CompareTag("LoadPath02"))
        {
            DontDestroyOnLoad(noDestroy);
            SceneManager.LoadScene("Path02");
            gameObject.transform.position = new Vector3(-0.5f, 2, transform.position.z);
        }
        else if (collision.gameObject.CompareTag("LoadCarePackageField"))
        {
            DontDestroyOnLoad(noDestroy);
            SceneManager.LoadScene("CarePackageField");
            gameObject.transform.position = new Vector3(1, 8, transform.position.z);
        }
        else if (collision.gameObject.CompareTag("LoadPath03"))
        {
            DontDestroyOnLoad(noDestroy);
            SceneManager.LoadScene("Path03");
            gameObject.transform.position = new Vector3(-7, -2, transform.position.z);
        }
        else if (collision.gameObject.CompareTag("LoadFriendHouse2"))
        {
            DontDestroyOnLoad(noDestroy);
            SceneManager.LoadScene("FinalLevel");
            //Will need to change the position below
            gameObject.transform.position = new Vector3(11, -1, transform.position.z);
        }
        else if (collision.gameObject.CompareTag("ZombieSpawner"))
        {
            collision.gameObject.GetComponent<ZombieSpawner>().spawnZombies();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("CheatCodeLoadFriendHouse"))
        {
            inTrigger1 = true;
            
        }
        else if (collision.gameObject.CompareTag("CheatCodeLoadCarePackage"))
        {
            loadCarePackage = true;
        }
        else if (collision.gameObject.CompareTag("CheatCodeLoadEndGame"))
        {
            loadEndGame = true;
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ZombieSpawner"))
        {
            //collision.gameObject.GetComponent<ZombieSpawner>().spawnZombies();
            //Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("CheatCodeLoadFriendHouse"))
        {
            inTrigger1 = false;
        }
        else if (collision.gameObject.CompareTag("CheatCodeLoadCarePackage"))
        {
            loadCarePackage = false;
        }
        else if (collision.gameObject.CompareTag("CheatCodeLoadEndGame"))
        {
            loadEndGame = false;
        }

    }
    private void isDead()
    {
        if (currHealth <= 0)
        {
            playerDead = true;
            ////Destroy(this.gameObject);
            Time.timeScale = 0f;
            deathSound.Play();
            gamemanager = FindObjectOfType<Gamemanager>();
            gamemanager.gameOver();

        }
    }

    private void addHealth(int h)
    {
        currHealth += h;

        if (currHealth > maxHealth)
        {
            currHealth = maxHealth;
        }

        Debug.Log("You have manually added " + h + " health");
    }


    public void addScore(int score)
    {
        playerScore += score;
    }

    public int getScore()
    {
        return playerScore;
    }
}
