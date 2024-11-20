using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void handleMovement()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LoadPath01"))
        {
            //gameObject.transform.SetParent(noDestroy.transform);
            //DontDestroyOnLoad(noDestroy);
            SceneManager.LoadScene("Path01");

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
