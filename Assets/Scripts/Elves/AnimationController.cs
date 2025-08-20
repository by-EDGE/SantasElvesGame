using UnityEngine;

public class AnimatorController : IAnimationController
{
    private Animator _animator;

    public AnimatorController(Animator animator)
    {
        _animator = animator;
    }

    public void SetWalking(bool isWalking)
    {
        _animator.SetBool("Walk", isWalking);
    }

    public void SetSpeed(float speed)
    {
        _animator.SetFloat("Speed", speed);
    }
}