using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    public float timeBetweenAttacks;

    [HideInInspector]
    public Transform player;

    
    public int damage;

    public int pickupChance;
    public GameObject[] pickups;

    public virtual void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if(health <= 0)
        {
            int randonNumber = Random.Range(0, 101);
            if(randonNumber < pickupChance)
            {
                GameObject randomPickup = pickups[Random.Range(0, pickups.Length)];
                Instantiate (randomPickup, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
