using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public GameObject apple;
    public GameObject spawner;
    // Start is called before the first frame update
    void Awake()
    {
        spawnApple();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnApple()
    {
        if (Random.Range(0, 100) < 80)
        {
            Instantiate(apple, transform.position, Quaternion.identity);
        }
    }


}
