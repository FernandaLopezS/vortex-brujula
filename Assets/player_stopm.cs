using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_stopm : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] private float stopmForce;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 40;

    void Update()
    {
        rb = GetComponent<Rigidbody2D>();
       
        if (Input.GetKeyDown(KeyCode.X))
        {
            {
             rb.velocity = new Vector2(rb.velocity.x, stopmForce);
            }
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackDamage, enemyLayers);
        foreach (Collider2D Enemy in hitEnemies)
           {
            Enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            UnityEngine.Debug.Log("We hit" + Enemy.name);
            }

        }
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }
}
 
