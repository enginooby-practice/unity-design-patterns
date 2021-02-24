using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    private void Awake()
    {
        controls = new Controls();

        controls.Player.Jump.performed += ctx => PerformJump(); // if(!isReplaying)
        controls.Player.Kick.performed += ctx => PerformKick();
        controls.Player.Punch.performed += ctx => PerformPunch();
        controls.Player.GoForwards.performed += ctx => PerformGoForwards();

        controls.Global.Replay.performed += ctx => PerformReplay();
        controls.Global.UndoLast.performed += ctx => UndoLast();

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
    private void PerformJump()
    {
        // TODO: Refactor
        jumpCommand.Excecute();
        currentActor.Jump();

        commandRecord.Add(jumpCommand.Clone());
    }

    private void PerformKick()
    {
        kickCommand.Excecute();
        currentActor.Kick();
        commandRecord.Add(kickCommand.Clone());
    }

    private void PerformPunch()
    {
        punchCommand.Excecute();
        currentActor.Punch();
        commandRecord.Add(punchCommand.Clone());
    }

    private void PerformGoForwards()
    {
        goForwardsCommand.Excecute();
        currentActor.GoForwards();
        commandRecord.Add(goForwardsCommand.Clone());
    }

    private void OnValidate()
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

    private void PerformReplay()
    {
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

    private void UndoLast()
    {
        print("Undoing last commands");
        if (commandRecord.Count == 0) return;
        MovementCommand lastCommand = commandRecord[commandRecord.Count - 1];
        lastCommand.Undo();
        commandRecord.Remove(lastCommand);
    }
}
