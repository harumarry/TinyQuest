using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    PlayerController controller;
    Animator animator;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // x 조건을 먼저 검사해서 대각선 이동 시 수평 애니메이션을 우선해서 실행
        if (controller.x > 0)
        {
            WalkRight();
        }
        else if (controller.x < 0)
        {
            WalkLeft();
        }
        else if (controller.y > 0)
        {
            WalkUP();
        }
        else if (controller.y < 0)
        {
            WalkDown();
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }
    }

    void WalkRight()
    {
        // flip : 스프라이트 좌우 반전
        spriteRenderer.flipX = false;
        animator.SetBool("IsMoving", true);
        animator.SetFloat("MoveX", 1f);
        animator.SetFloat("MoveY", 0f);
    }

    void WalkLeft()
    {
        spriteRenderer.flipX = true;
        animator.SetBool("IsMoving", true);
        animator.SetFloat("MoveX", -1f);
        animator.SetFloat("MoveY", 0f);
    }

    void WalkUP()
    {
        spriteRenderer.flipX = false;
        animator.SetBool("IsMoving", true);
        animator.SetFloat("MoveX", 0f);
        animator.SetFloat("MoveY", 1f);
    }

    void WalkDown()
    {
        spriteRenderer.flipX = false;
        animator.SetBool("IsMoving", true);
        animator.SetFloat("MoveX", 0f);
        animator.SetFloat("MoveY", -1f);
    }
}
