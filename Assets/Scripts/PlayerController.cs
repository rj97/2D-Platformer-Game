using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ScoreController scoreController;
    private Animator animator;
    private Rigidbody2D rb2d;

    public float speed;
    public float jump;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalSpeed = Input.GetAxisRaw("Horizontal");
        float jumpSpeed = Input.GetAxisRaw("Jump");
        // Input.GetKeyDown(KeyCode.Space);

        PlayRunAnimation(horizontalSpeed);
        PlayJumpAnimation(jumpSpeed);
        PlayCouchAnimation();

        MoveCharacter(horizontalSpeed, jumpSpeed);
    }

    public void PickUpKey()
    {
        Debug.Log("Player picked up the key!");
        scoreController.IncreaseScore(15);
    }

    private void PlayRunAnimation(float horizontalSpeed)
    {
        if (Mathf.Abs(horizontalSpeed) > 0)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        Vector3 scale = transform.localScale;

        if (horizontalSpeed < 0)
        {
            scale.x = -1 * Mathf.Abs(scale.x);
        }
        else if (horizontalSpeed > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        transform.localScale = scale;
    }

    private void PlayJumpAnimation(float jumpSpeed)
    {
        if (jumpSpeed > 0)
        {
            animator.SetBool("isJump", true);
        }
        else
        {
            animator.SetBool("isJump", false);
        }
    }

    private void PlayCouchAnimation()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetBool("isCrouch", true);
        }
        else
        {
            animator.SetBool("isCrouch", false);
        }
    }

    private void MoveCharacter(float horizontalSpeed, float jumpSpeed)
    {
        // move character horizontally
        if (horizontalSpeed != 0)
        {
            Vector3 position = transform.position;
            float direction = horizontalSpeed / Mathf.Abs(horizontalSpeed);
            position.x += direction * speed * Time.deltaTime;
            transform.position = position;
        }

        // move character vertically
        if (jumpSpeed > 0)
        {
            rb2d.AddForce(new Vector2(0f, jump), ForceMode2D.Force);
        }
    }
}
