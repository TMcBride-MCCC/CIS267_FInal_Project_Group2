using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL2_ZombieController : MonoBehaviour
{
    private GameObject player;
    private Vector2 playerLocation;
    public float speed;
    public float health;
    public int points;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        playerLocation = player.transform.position;
        FlipZombieSprite();
        transform.position = Vector2.MoveTowards(transform.position, playerLocation, speed * Time.deltaTime);
    }

    private void isDead()
    {
        if (health <= 0)
        {
            //***play death animation***

            Destroy(this.gameObject);
        }
    }

    private void FlipZombieSprite()
    {
        // Flip sprite based on the direction to the player
        if (playerLocation.x < transform.position.x)
        {
            // Face left
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            // Face right
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
    }
}