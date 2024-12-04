using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    private PlayerInputHandler PlayerInputHandler;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int damage;
    //public float primaryAttack;
    int i = 0;
    public SpriteRenderer[] spriteRenderer;
    private float hitTime = 0;

    // Start is called before the first frame update
    void Start()
    {
       
        //PlayerInputHandler = GetComponent<PlayerInputHandler>();
        //primaryAttack = Input.GetAxis("Fire1");
        hitTime += Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        //float axis = Input.GetAxisRaw("Fire1")
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            //attack();
        }

        if(Input.GetButton("Fire1"))
        {
            //attack();
        }

        if(Input.GetButtonDown("Fire1"))
        {
            attack();
            
        }
        //Debug.Log(primaryAttack);

        if(Input.GetAxis("Fire1") == 1)
        {
            //attack();
            //if (hitTime >= 1f)
            //{
            //    attack();
            //    hitTime = 0;
            //}
            //else
            //{
            //    hitTime += Time.deltaTime;
            //}
        }

        if (hitTime >= 1f)
        {
            if(Input.GetAxisRaw("Fire1") == 1)
            {  
                attack();
                hitTime = 0;
            }
            
        }
        else
        {
            hitTime += Time.deltaTime;
        }

    }

    private void FixedUpdate()
    {
        if(Input.GetButton("Fire1"))
        {
            //attack();
        }
    }

    public void attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            //Debug.Log("We hit");
            LVL1_ZombieController zombie = enemy.GetComponent<LVL1_ZombieController>();
            if(zombie != null)
            {
                if (Random.Range(0, 100) < 25)
                {
                    //zombie.GetComponent<LVL1_ZombieController>().takeDamage(damage);
                }
                zombie.GetComponent<LVL1_ZombieController>().takeDamage(damage);
            }
            LVL2_ZombieController zombie2 = enemy.GetComponent<LVL2_ZombieController>();
            if (zombie2 != null)
            {
                if (Random.Range(0, 100) < 25)
                {
                    //zombie2.GetComponent<LVL2_ZombieController>().takeDamage(damage);
                }
                zombie2.GetComponent<LVL2_ZombieController>().takeDamage(damage);
            }
            LVL3_ZombieController zombie3 = enemy.GetComponent<LVL3_ZombieController>();
            if (zombie3 != null)
            {
                if (Random.Range(0, 100) < 25)
                {
                    //zombie3.GetComponent<LVL3_ZombieController>().takeDamage(damage);
                    i++;
                }

                zombie3.GetComponent<LVL3_ZombieController>().takeDamage(damage);
                //i++;




            }

          //Debug.Log("HIT + " + i);


        }
    }

    private void OnCollisonEnter2D(Collider2D collision)
    {
        //if(collision.gameObject.CompareTag("Zombielvl1"))
        //{
            
        //    if(Input.GetButton("Fire1"))
        //    {
        //        LVL1_ZombieController zombie = collision.GetComponent<LVL1_ZombieController>();
        //        if (zombie != null)
        //        {
        //            collision.GetComponent<LVL1_ZombieController>().takeDamage(damage);
        //        }
        //    }
        //}
        //else if (collision.gameObject.CompareTag("Zombielvl2"))
        //{

        //    if (Input.GetButton("Fire1"))
        //    {
        //        LVL2_ZombieController zombie = collision.GetComponent<LVL2_ZombieController>();
        //        if (zombie != null)
        //        {
        //            collision.GetComponent<LVL2_ZombieController>().takeDamage(damage);
        //        }
        //    }
        //}
        //else if (collision.gameObject.CompareTag("Zombielvl3"))
        //{

        //    if (Input.GetButton("Fire1"))
        //    {
        //        LVL3_ZombieController zombie = collision.GetComponent<LVL3_ZombieController>();
        //        if (zombie != null)
        //        {
        //            zombie.GetComponent<LVL3_ZombieController>().takeDamage(damage);
        //        }
        //    }
        //}
    }

    public void attack2(GameObject zomebieType)
    {

    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
            { return; }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void batLevel2()
    {

    }

    public void batLevel3()
    {

    }

}
