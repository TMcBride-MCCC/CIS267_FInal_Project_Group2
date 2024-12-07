using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LVL3_ZombieController : MonoBehaviour
{
    [SerializeField] EnemyHealthBar healthBar;

    private GameObject player;
    private Vector2 playerLocation;
    public float speed;
    public float currHealth;
    public int points;
    public int damage;
    public int maxHealth;
    public float pushBack;
    private Rigidbody2D rb;
    int i = 0;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        healthBar = GetComponentInChildren<EnemyHealthBar>();
        playerController = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        playerLocation = player.transform.position;
        FlipZombieSprite();
        transform.position = Vector2.MoveTowards(transform.position, playerLocation, speed * Time.deltaTime);
    }

    private void isDead()
    {
        if (currHealth <= 0)
        {
            //***play death animation***

            playerController.addScore(points);

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

    public int returnDamage()
    {
        return damage;
    }

    public void takeDamage(int damage)
    {
        currHealth -= damage;
        healthBar.updateHealthBar(currHealth, maxHealth);
        rb.velocity = new Vector2(pushBack, rb.velocity.y);



            isDead();
        
    }
}
