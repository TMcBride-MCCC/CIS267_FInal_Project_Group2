using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject[] zombies;
    public GameObject[] zombieSpawnLocations;
    // Start is called before the first frame update
    void Start()
    {
        //spawnZombies();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnZombies()
    {
        GameObject[] locations = zombieSpawnLocations;
        GameObject[] types = zombies;

        foreach (GameObject spawnZombie in locations)
        {
            int i = Random.Range(0, zombies.Length);
            GameObject spawn = Instantiate(types[i], spawnZombie.transform.position, Quaternion.identity);
        }
    }
  
}
