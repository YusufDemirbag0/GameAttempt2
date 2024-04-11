using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    [SerializeField] public int maxHealth = 100;
    [SerializeField] private int attackCooldown;
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    private float cooldownTimer = Mathf.Infinity;
    int currentHealth;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;

        if(PlayerInSight())
        {
            if(cooldownTimer >= attackCooldown)
            {
                animator.SetTrigger("Enemy1Attack");
            }
        }
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider2D.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider2D.bounds.size.x * range, boxCollider2D.bounds.size.y, boxCollider2D.bounds.size.z), 0, Vector2.left, 0, playerLayer);
        return hit.collider != null;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider2D.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, new Vector3(boxCollider2D.bounds.size.x * range, boxCollider2D.bounds.size.y, boxCollider2D.bounds.size.z));
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Enemy1Hurt");

        if(currentHealth <= 0)
        {
            Die();
            animator.SetBool("Enemy1Death", true);
        }
    }

    void Die()
    {
        Debug.Log("Enemy Died!");
    }
}
