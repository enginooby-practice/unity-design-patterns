using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Sirenix.OdinInspector;

public class InputHandler : MonoBehaviour
{
    [SerializeField] List<PlayerController> actors = new List<PlayerController>();
    [ValueDropdown("actors")] [SerializeField] PlayerController currentActor;

    MovementCommand jumpCommand, kickCommand, punchCommand, goForwardsCommand;
    List<MovementCommand> commandRecord = new List<MovementCommand>();

    /* replay command record feature */
    Coroutine replayCoroutine;
    bool isReplaying;

    private Controls controls;
    private PlayerInput playerInput;

    private void Awake()
    {
        controls = new Controls();
        playerInput = GetComponent<PlayerInput>();

        // to enable rebinding, register events in Player Input component (Unity events)
        // controls.Player.Jump.performed += ctx => PerformJump(ctx); // if(!isReplaying)
        // controls.Player.Kick.performed += ctx => PerformKick();
        // controls.Player.Punch.performed += ctx => PerformPunch();
        // controls.Player.GoForwards.performed += ctx => PerformGoForwards();

        // controls.Global.Replay.performed += ctx => PerformReplay();
        // controls.Global.UndoLast.performed += ctx => UndoLast();

    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    // TODO: Refactor movement methods
    public void PerformJump(InputAction.CallbackContext context)
    {
        // playerInput.SwitchCurrentActionMap("Player");
        // perform on key up
        if (!context.performed) return;
        // TODO: Refactor
        jumpCommand.Excecute();
        currentActor.Jump();

        commandRecord.Add(jumpCommand.Clone());
    }

    public void PerformKick(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        kickCommand.Excecute();
        currentActor.Kick();
        commandRecord.Add(kickCommand.Clone());
    }

    public void PerformPunch(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        punchCommand.Excecute();
        currentActor.Punch();
        commandRecord.Add(punchCommand.Clone());
    }

    public void PerformGoForwards(InputAction.CallbackContext context)
    {
        if (!context.performed) return;
        goForwardsCommand.Excecute();
        currentActor.GoForwards();
        commandRecord.Add(goForwardsCommand.Clone());
    }

    public void OnValidate()
    {
        UpdateActor();
    }

    private void UpdateActor()
    {
        Camera.main.GetComponent<CameraFollow360>().player = currentActor.transform;
        Animator animator = currentActor.GetComponent<Animator>();

        // TODO: Refactor
        jumpCommand = new MovementCommand(animator, "isJumping");
        kickCommand = new MovementCommand(animator, "isKicking");
        punchCommand = new MovementCommand(animator, "isPunching");
        goForwardsCommand = new MovementCommand(animator, "isWalking");
    }

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
            print(commandRecord[i].GetTrigger());
            yield return new WaitForSeconds(1f);
        }

        commandRecord.Clear();
        isReplaying = false;
    }

    public void UndoLast(InputAction.CallbackContext context)
    {
        // TODO: Switch to Global map to perform this method
        // playerInput.SwitchCurrentActionMap("Global");

        if (!context.performed) return;
        print("Undoing last commands");
        if (commandRecord.Count == 0) return;
        MovementCommand lastCommand = commandRecord[commandRecord.Count - 1];
        lastCommand.Undo();
        commandRecord.Remove(lastCommand);
    }
}
