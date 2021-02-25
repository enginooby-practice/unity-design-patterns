using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorCommand : Command
{
    protected Actor actor;

    public ActorCommand(Actor actor)
    {
        this.actor = actor;
    }

    public void SetActor(Actor newActor) => this.actor = newActor;
    public override void Excecute() { }
    public override void Undo() { }

    public ActorCommand Clone() => new ActorCommand(actor);
}

// REFACTOR: duplicate, maybe better create static instance
public class JumpCommand : ActorCommand
{
    public JumpCommand(Actor actor) : base(actor) { }
    public override void Excecute() => actor.Jump();
    public override void Undo() => actor.Jump(ActionModes.REVERSED);
}
public class PunchCommand : ActorCommand
{
    public PunchCommand(Actor actor) : base(actor) { }
    public override void Excecute() => actor.Punch();
    public override void Undo() => actor.Punch(ActionModes.REVERSED);
}
public class KickCommand : ActorCommand
{
    public KickCommand(Actor actor) : base(actor) { }
    public override void Excecute() => actor.Kick();
    public override void Undo() => actor.Kick(ActionModes.REVERSED);
}
public class MoveForwardCommand : ActorCommand
{
    public MoveForwardCommand(Actor actor) : base(actor) { }
    public override void Excecute() => actor.MoveForward();
    public override void Undo() => actor.MoveForward(ActionModes.REVERSED);
}

