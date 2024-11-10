using UnityEngine;

public class HeroAnimator
{
    public HeroAnimator(Animator animator)
    {
        _animator = animator;
    }

    public Animator _animator { get; private set; }

    private string _nameState = "State";

    private States State
    {
        get { return (States)_animator.GetInteger(_nameState); }
        set { _animator.SetInteger(_nameState, (int)value); }
    }

    public void EnableAnimationIdle()
    {
        State = States.idle;
    }

    public void EnableAnimationRun()
    {
        State = States.run;
    }

    public void EnableAnimationJump()
    {
        State = States.jump;
    }
}

public enum States
{
    idle,
    run,
    jump
}