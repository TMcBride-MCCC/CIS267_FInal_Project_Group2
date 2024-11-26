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


    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //FixedUpdate is frame rate independent and should be used for physics objects
    private void FixedUpdate()
    {
        //Moving the player in fixed update stops jumping during movement
        movePlayer();
    }

    private void OnMovement(InputValue value)
    {
        //Grabs the direction of the input
        movement = value.Get<Vector2>();
        Debug.Log("Movement captured as: " +  movement);
    }

    private void movePlayer()
    {
        //Uses the direction of the input to move the player
        playerRB.MovePosition(playerRB.position + movement * movementSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LoadPath01"))
        {
            //gameObject.transform.SetParent(noDestroy.transform);
            DontDestroyOnLoad(noDestroy);
            SceneManager.LoadScene("Path01");
            gameObject.transform.position = new Vector3(transform.position.x - 20, transform.position.y, transform.position.z);
        }
        else if (collision.gameObject.CompareTag("LoadFriendHouse"))
        {
            SceneManager.LoadScene("FriendsHouse");
        }
        else if (collision.gameObject.CompareTag("LoadPath02"))
        {
            SceneManager.LoadScene("Path02");
        }
        else if (collision.gameObject.CompareTag("LoadCarePackage"))
        {
            SceneManager.LoadScene("CarePackage");
        }
        else if (collision.gameObject.CompareTag("LoadPath03"))
        {
            SceneManager.LoadScene("Path03");
        }
    }
}
