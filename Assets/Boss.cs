﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int health;
    public Enemy[] enemies;
    public float offset;
    public int damage;

    private int halfHealth;
    private Animator anim;

    private void Start() {
        halfHealth = health / 2;
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if(health <= halfHealth)
        {
            anim.SetTrigger("stage2");
        }

        Enemy randomEnemy = enemies[Random.Range(0, enemies.Length)];
        Instantiate(randomEnemy, transform.position + new Vector3(offset, offset, 0), transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            other.GetComponent<Player>().TakeDamage(damage); 
        }
    }

}