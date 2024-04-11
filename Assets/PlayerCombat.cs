using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    [SerializeField] public float attackRange;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    [SerializeField] public int attackDamage;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack1();
        }

        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            Attack2();
        }
    }

    void Attack1()
    {
        animator.SetTrigger("Attack1");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("Player hit the enemy.");
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    void Attack2()
    {
        animator.SetTrigger("Attack2");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("Player hit the enemy.");
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
