
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int maxHealth = 100;
    int currentHealth;
    public AudioSource attack;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage (int damage)
    {
        attack.Play();
        currentHealth -= damage;

        // Play hurt animation

        if(currentHealth < 0)
        {
            
            Die();
        }
    }

    void Die ()
    {
        // Die animation
        // Disable the enemy
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        Destroy(gameObject);
        
    }
}
