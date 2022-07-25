using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private Animator animator;

    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange = 0.5f;
    public int attackDamage = 25;

    [SerializeField] LayerMask enemyLayers;

    [SerializeField] PlayerController pc;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            pc.enabled = false;

            //Play Animation
            animator.SetTrigger("Attack");

            //Detect enemies in range
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

            //Damage
            foreach(Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
            }
        }
        if(Input.GetKeyUp(KeyCode.E))
        {
            pc.enabled = true;
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
