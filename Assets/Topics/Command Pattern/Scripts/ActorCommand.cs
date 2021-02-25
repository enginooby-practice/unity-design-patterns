using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ActorCommand : Command
{
    protected Actor actor;
    public ActorCommand(Actor actor) { this.actor = actor; }
    public void SetActor(Actor newActor) => this.actor = newActor;
}

// REFACTOR: duplicate, maybe better create static instance
public class JumpCommand : ActorCommand
{
    public JumpCommand(Actor actor) : base(actor) { }
    public override void Excecute() => actor.Jump();
    public override void Undo() => actor.Jump(ActionModes.REVERSED);
    public override Command Clone() => new JumpCommand(actor);
}
public class PunchCommand : ActorCommand
{
    public PunchCommand(Actor actor) : base(actor) { }
    public override void Excecute() => actor.Punch();
    public override void Undo() => actor.Punch(ActionModes.REVERSED);
    public override Command Clone() => new PunchCommand(actor);

}
public class KickCommand : ActorCommand
{
    public KickCommand(Actor actor) : base(actor) { }
    public override void Excecute() => actor.Kick();
    public override void Undo() => actor.Kick(ActionModes.REVERSED);
    public override Command Clone() => new KickCommand(actor);

}
public class MoveForwardCommand : ActorCommand
{
    public MoveForwardCommand(Actor actor) : base(actor) { }
    public override void Excecute() => actor.MoveForward();
    public override void Undo() => actor.MoveForward(ActionModes.REVERSED);
    public override Command Clone() => new MoveForwardCommand(actor);

}

