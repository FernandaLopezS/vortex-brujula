using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{


    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public LayerMask manaLayers;
    public int attackDamage = 40;

    // Update is called once per frame
    void Update()
    {
 

        //Seleccionar la tecla de ataque
        if (Input.GetKeyDown(KeyCode.C))
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            getMana();
        }



    }
 


    //Funcion de ataque
    void Attack()
    {
        //Animacion del ataque
        // ------------
        //Detect enemy

        //OverlapArea - Genera un rea para delimitar arma
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D Enemy in hitEnemies)
        {
            Enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            UnityEngine.Debug.Log("We hit" + Enemy.name);
        }

    }
    void getMana()
    {

        Collider2D[] manaOrbs = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, manaLayers);
        foreach (Collider2D Enemy in manaOrbs)
        {
            UnityEngine.Debug.Log("We got mana");
        }

    }

    //visualizar area de ataque
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }
}
