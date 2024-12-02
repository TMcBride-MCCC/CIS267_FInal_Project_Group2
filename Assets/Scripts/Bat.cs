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


    // Start is called before the first frame update
    void Start()
    {
        PlayerInputHandler = GetComponent<PlayerInputHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            attack();
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
                enemy.GetComponent<LVL1_ZombieController>().takeDamage(damage);
            }
            LVL2_ZombieController zombie2 = enemy.GetComponent<LVL2_ZombieController>();
            if (zombie2 != null)
            {
                enemy.GetComponent<LVL2_ZombieController>().takeDamage(damage);
            }
            LVL3_ZombieController zombie3 = enemy.GetComponent<LVL3_ZombieController>();
            if (zombie3 != null)
            {
                enemy.GetComponent<LVL3_ZombieController>().takeDamage(damage);
            }

        }
    }

    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
            { return; }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
