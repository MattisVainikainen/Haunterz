using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private Player playerScript;
    public GameObject explosionEffect;

    private Vector2 targetPosition;
    public float speed;
    public int damage;

    private void Start() {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        targetPosition = playerScript.transform.position;
    }


    private void Update() {
        if(Vector2.Distance(transform.position, targetPosition) > 0.1f)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
        else
        {
            GameObject A = Instantiate(explosionEffect, transform.position, transform.rotation) as GameObject;
            Destroy (A, 3f);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
        {
            playerScript.TakeDamage(damage);
            Destroy(gameObject); 
        }
    }
}
