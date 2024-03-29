﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    [SerializeField] GameObject weaponHolder;
    private Rigidbody2D myRb;
    private Vector2 moveAmount;
    private Animator animator;
    public int health;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public Animator hurtPanel;

    private void Start() 
    {
        myRb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update() 
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveAmount = moveInput.normalized * playerSpeed;

        if(moveInput != Vector2.zero)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }

    private void FixedUpdate() 
    {
        myRb.MovePosition(myRb.position + moveAmount * Time.fixedDeltaTime);
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        UpdateHealthUI(health);
        hurtPanel.SetTrigger("hurt");
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void ChangeWeapon(Weapon weaponToEquip)
    {
        Destroy(GameObject.FindGameObjectWithTag("Weapon"));
        Instantiate(weaponToEquip, weaponHolder.transform.position, weaponHolder.transform.rotation, transform);
    }

    void UpdateHealthUI(int currentHealth)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    public void Heal(int healAmount)
    {
        if(health + healAmount >= 5)
        {
            health = 5;
        } else
        {
            health += healAmount;
        }
        UpdateHealthUI(health);
    }
}
