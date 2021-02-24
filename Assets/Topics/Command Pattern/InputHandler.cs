using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class InputHandler : MonoBehaviour
{
    [SerializeField] List<GameObject> actors = new List<GameObject>();
    [ValueDropdown("actors")] [SerializeField] GameObject currentActor;

    MovementCommand jumpCommand, kickCommand, punchCommand, goForwardsCommand;
    List<MovementCommand> commandRecord = new List<MovementCommand>();

    /* replay command record feature */
    Coroutine replayCoroutine;
    bool replayTriggered; // to insure replaying happens only once in Update()
    bool isReplaying;

    void Start()
    {
    }

    void Update()
    {
        if (!isReplaying) ProcessInput();
        if (replayTriggered) TryReplaying();
    }

    private void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpCommand.Excecute();
            commandRecord.Add(jumpCommand.Clone());
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            kickCommand.Excecute();
            commandRecord.Add(kickCommand.Clone());

        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            punchCommand.Excecute();
            commandRecord.Add(punchCommand.Clone());

        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            goForwardsCommand.Excecute();
            commandRecord.Add(goForwardsCommand.Clone());
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            replayTriggered = true;
        }
    }
    private void OnValidate()
    {
        Camera.main.GetComponent<CameraFollow360>().player = currentActor.transform;
        Animator animator = currentActor.GetComponent<Animator>();

        jumpCommand = new MovementCommand(animator, "isJumping");
        kickCommand = new MovementCommand(animator, "isKicking");
        punchCommand = new MovementCommand(animator, "isPunching");
        goForwardsCommand = new MovementCommand(animator, "isWalking");
    }

    private void TryReplaying()
    {
        if (commandRecord.Count > 0)
        {
            replayTriggered = false;

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
            yield return new WaitForSeconds(1.5f);
        }

        commandRecord.Clear();
        isReplaying = false;
    }
}
