using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class InputHandler : MonoBehaviour
{
    [SerializeField] List<GameObject> actors = new List<GameObject>();
    [ValueDropdown("actors")] [SerializeField] GameObject currentActor;
    MovementCommand jumpCommand, kickCommand, punchCommand, goForwardsCommand, goBackwardsCommand, turnLeftCommand, turnRightCommand;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpCommand.Excecute();
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            kickCommand.Excecute();
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            punchCommand.Excecute();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            goForwardsCommand.Excecute();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            goBackwardsCommand.Excecute();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            turnLeftCommand.Excecute();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            turnRightCommand.Excecute();
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
        goBackwardsCommand = new MovementCommand(animator, "isWalking");
        turnLeftCommand = new MovementCommand(animator, "isWalking");
        turnRightCommand = new MovementCommand(animator, "isWalking");
    }
}
