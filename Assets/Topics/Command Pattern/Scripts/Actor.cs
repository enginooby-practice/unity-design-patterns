using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ActionModes { NORMAL, REVERSED }
public class Actor : MonoBehaviour // contains all actions of the game object
{
    private Animator animator;
    private string currentTrigger;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    private void TestLateUpdate()
    {
        float speed = 2.0f;
        float rotationSpeed = 100.0f;
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) ||
            Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            animator.SetBool("isWalking", false);
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("isWalking", true);
            transform.Translate(0, 0, translation);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("isWalking", true);
            transform.Rotate(0, rotation, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
            animator.SetTrigger("isJumping");
        else if (Input.GetKeyDown(KeyCode.P))
            animator.SetTrigger("isPunching");
        else if (Input.GetKeyDown(KeyCode.K))
            animator.SetTrigger("isKicking");

    }

    private void OnTriggerUpdated()
    {
        animator.SetTrigger(currentTrigger);
        print(gameObject.name + " " + currentTrigger);
    }
    public void Jump(ActionModes mode = ActionModes.NORMAL)
    {
        currentTrigger = (mode == ActionModes.NORMAL) ? "isJumping" : "isJumpingR";
        OnTriggerUpdated();
    }
    public void Punch(ActionModes mode = ActionModes.NORMAL)
    {
        currentTrigger = (mode == ActionModes.NORMAL) ? "isPunching" : "isPunchingR";
        OnTriggerUpdated();
    }

    public void Kick(ActionModes mode = ActionModes.NORMAL)
    {
        currentTrigger = (mode == ActionModes.NORMAL) ? "isKicking" : "isKickingR";
        OnTriggerUpdated();
    }
    public void MoveForward(ActionModes mode = ActionModes.NORMAL)
    {
        currentTrigger = (mode == ActionModes.NORMAL) ? "isWalking" : "isWalking";
        OnTriggerUpdated();

        // fix y offset of animation
        transform.position = new Vector3(transform.position.x, -6.06f, transform.position.z);
    }
}


