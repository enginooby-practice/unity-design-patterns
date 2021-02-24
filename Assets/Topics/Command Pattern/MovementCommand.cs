using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCommand : Command
{
    protected Animator animator;
    protected string trigger;

    public MovementCommand(Animator animator, string trigger)
    {
        this.animator = animator;
        this.trigger = trigger;
    }
    public override void Excecute()
    {
        if (animator != null) animator.SetTrigger(trigger);
    }
    public override void ExecuteReversely()
    {
        Debug.Log(">>> Execute reversely");
        if (animator != null) animator.SetTrigger(trigger);
    }
}

public class JumpCommand : MovementCommand
{
    public JumpCommand(Animator animator, string trigger) : base(animator, trigger) { }
    public override void Excecute()
    {
        Debug.Log(">>> Jump");
        if (animator != null) animator.SetTrigger(trigger);
    }
}