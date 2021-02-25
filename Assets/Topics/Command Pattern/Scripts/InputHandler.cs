using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Sirenix.OdinInspector;
using Michsky.UI.ModernUIPack;

public class InputHandler : MonoBehaviour
{
    // private static readonly PlayerActionCommand TestCommand = new PlayerActionCommand(delegate (PlayerAction actor) { actor.Jump(); });
    [SerializeField] CustomDropdown actorSwitchDropdown;
    [SerializeField] List<Actor> actors = new List<Actor>();
    [ValueDropdown("actors")] [SerializeField] Actor currentActor;

    ActorCommand jumpCommand, kickCommand, punchCommand, moveForwardCommand;
    List<Command> commandRecord = new List<Command>();

    /* replay command record feature */
    Coroutine replayCoroutine;
    bool isReplaying;

    private Controls controls;

    private void Awake()
    {
        controls = new Controls();
        // SetupControlEvents();
    }

    public void HandleSwitchDropdown()
    {
        currentActor = actors[actorSwitchDropdown.selectedItemIndex];
        OnCurrentActorUpdated();
    }
    private void OnEnable() { controls.Enable(); }
    private void OnDisable() { controls.Disable(); }

    // to enable rebinding, register events in Player Input component (Unity events) instead
    private void SetupControlEvents()
    {
        controls.Player.Jump.performed += ctx => PerformJump(ctx); // if(!isReplaying)
        controls.Player.Kick.performed += ctx => PerformKick(ctx);
        controls.Player.Punch.performed += ctx => PerformPunch(ctx);
        controls.Player.MoveForward.performed += ctx => PerformMoveForward(ctx);

        controls.Player.Replay.performed += ctx => PerformReplay(ctx);
        controls.Player.UndoLast.performed += ctx => PerformUndoLast(ctx);
    }
    public void ExcecutePlayerAction(InputAction.CallbackContext context, ActorCommand command)
    {
        // perform only on key up (while not context.performed or key down anymore)
        if (!context.performed) return;

        command.Excecute();
        commandRecord.Add(command.Clone());
    }
    public void PerformJump(InputAction.CallbackContext context) => ExcecutePlayerAction(context, jumpCommand);
    public void PerformKick(InputAction.CallbackContext context) => ExcecutePlayerAction(context, kickCommand);
    public void PerformPunch(InputAction.CallbackContext context) => ExcecutePlayerAction(context, punchCommand);
    public void PerformMoveForward(InputAction.CallbackContext context) => ExcecutePlayerAction(context, moveForwardCommand);
    public void PerformReplay(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        print("Replaying commands");
        if (commandRecord.Count > 0)
        {
            if (replayCoroutine != null)
            {
                StopCoroutine(replayCoroutine);
            }
            replayCoroutine = StartCoroutine(ReplayCommands());
        }
    }

    IEnumerator ReplayCommands()
    {
        for (int i = 0; i < commandRecord.Count; i++)
        {
            commandRecord[i].Excecute();
            yield return new WaitForSeconds(1f);
        }

        commandRecord.Clear();
        isReplaying = false;
    }

    public void PerformUndoLast(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        print("Undoing last commands");
        if (commandRecord.Count == 0) return;
        Command lastCommand = commandRecord[commandRecord.Count - 1];
        lastCommand.Undo();
        commandRecord.Remove(lastCommand);
    }

    public void OnValidate() { OnCurrentActorUpdated(); }
    private void OnCurrentActorUpdated()
    {
        Camera.main.GetComponent<CameraFollow360>().player = currentActor.transform;
        Animator animator = currentActor.GetComponent<Animator>();

        // TODO: Refactor
        jumpCommand = new JumpCommand(currentActor);
        kickCommand = new KickCommand(currentActor);
        punchCommand = new PunchCommand(currentActor);
        moveForwardCommand = new MoveForwardCommand(currentActor);
    }

}
