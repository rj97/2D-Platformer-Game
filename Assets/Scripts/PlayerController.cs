using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalSpeed = Input.GetAxisRaw("Horizontal");
        float jumpSpeed = Input.GetAxisRaw("Jump");
        // Input.GetKeyDown(KeyCode.Space);

        PlayRunAnimation(horizontalSpeed);
        PlayJumpAnimation(jumpSpeed);
        PlayCouchAnimation();
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
}
