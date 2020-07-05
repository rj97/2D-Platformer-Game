using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float speed;

    void Update()
    {
        float horizontalSpeed = Input.GetAxisRaw("Horizontal");

        float jumpSpeed = Input.GetAxisRaw("Jump");
        // Input.GetKeyDown(KeyCode.Space);

        PlayMovementAnimation(horizontalSpeed, jumpSpeed);
    }

    private void PlayMovementAnimation(float horizontalSpeed, float jumpSpeed)
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

        if (jumpSpeed > 0)
        {
            animator.SetBool("isJump", true);
        }
        else
        {
            animator.SetBool("isJump", false);
        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            animator.SetBool("isCrouch", true);
        }
        else
        {
            animator.SetBool("isCrouch", false);
        }
    }

    private void MoveCharacter(float horizontalSpeed)
    {

    }
}
