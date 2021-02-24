using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCommand : Command
{
    private Animator _animator;
    private string _trigger;

    public MovementCommand(Animator animator, string trigger)
    {
        this._animator = animator;
        this._trigger = trigger;
    }
    public override void Excecute()
    {
        if (_animator != null) _animator.SetTrigger(_trigger);
    }
    public override void ExecuteReversely()
    {
        Debug.Log(">>> Execute reversely");
        if (_animator != null) _animator.SetTrigger(_trigger);
    }

    public string GetTrigger() => this._trigger;

    public MovementCommand Clone()
    {
        return new MovementCommand(this._animator, this._trigger);
    }
}

public class JumpCommand : MovementCommand
{
    public JumpCommand(Animator animator, string trigger) : base(animator, trigger) { }
    public override void Excecute()
    {
        Debug.Log(">>> Jump");
        // if (animator != null) animator.SetTrigger(_trigger);
    }
}