﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    int enemyDirection = 1;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("EnemyBounds"))
        {
            enemyDirection *= -1;

            changeDirection();
        }
        
        if (collision.gameObject.GetComponent<PlayerController>() != null)
        {
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            Transform playerTransform = playerController.gameObject.transform;

            // face towards the player, if not already facing
            if (enemyDirection == 1 && (playerTransform.position.x < transform.position.x))
            {
                enemyDirection = -1;
                changeDirection();
            }
            else if (enemyDirection == -1 && (playerTransform.position.x > transform.position.x))
            {
                enemyDirection = 1;
                changeDirection();
            }

            // attack the player
            attack(true);
            bool isGameOver = playerController.EnemyKilledPlayer();
            if (!isGameOver)
            {
                attack(false);
            }
        }
    }

    public void attack(bool mode)
    {
        animator.SetBool("isAttacking", mode);
    }

    private void Update()
    {
        MoveCharacter();
    }

    private void changeDirection()
    {
        Vector3 scale = transform.localScale;

        if (enemyDirection < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
    }

    private void MoveCharacter()
    {
        Vector3 position = transform.position;
        position.x += enemyDirection * speed * Time.deltaTime;
        transform.position = position;
    }
}
