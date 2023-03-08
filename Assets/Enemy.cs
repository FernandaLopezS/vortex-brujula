using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
            Destroy(gameObject);
        }
        //parte de animcaion del enemigo

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="arma")
        {
            TakeDamage(currentHealth);
        }
    }

    void Die()
    {
        UnityEngine.Debug.Log("Enemy died");
    }
    //Animcion de muerte del enemigo

}