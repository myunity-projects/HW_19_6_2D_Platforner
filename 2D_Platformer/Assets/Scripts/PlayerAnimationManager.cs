using System.Collections;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    private const string RunAnimName = "Run";
    private const string JumpAnimName = "Jump";
    private const string IdleAnimName = "Idle";

    private string currentAnimaton;

    private Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        IdleAnim();
        RunAnim();
        JumpAnim();
    }

    void ChangeAnimationState(string newAnimation)
    {
        if (currentAnimaton == newAnimation) return;

        _animator.Play(newAnimation);
        currentAnimaton = newAnimation;
    }

    private void IdleAnim()
    {
        if (GlobalVariables.isGrounded && !GlobalVariables.playerHasHorizontalMovement)
        {
            ChangeAnimationState(IdleAnimName);
        }
    }

    private void RunAnim()
    {
        if (GlobalVariables.playerHasHorizontalMovement && GlobalVariables.isGrounded)
        {
            ChangeAnimationState(RunAnimName);
        }
    }

    private void JumpAnim()
    {
        if (!GlobalVariables.isGrounded)
        {
            ChangeAnimationState(JumpAnimName);
        }
    }
}
