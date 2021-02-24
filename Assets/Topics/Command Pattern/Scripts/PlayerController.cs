using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator anim;
    float speed = 2.0f;
    float rotationSpeed = 100.0f;

    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    private void TestLateUpdate()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) ||
            Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
            anim.SetBool("isWalking", false);
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("isWalking", true);
            transform.Translate(0, 0, translation);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("isWalking", true);
            transform.Rotate(0, rotation, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
            anim.SetTrigger("isJumping");
        else if (Input.GetKeyDown(KeyCode.P))
            anim.SetTrigger("isPunching");
        else if (Input.GetKeyDown(KeyCode.K))
            anim.SetTrigger("isKicking");

    }

    public void Jump()
    {
        print(gameObject.name + " is jumping");
    }
    public void Kick()
    {
        print(gameObject.name + " is kicking");
    }
    public void Punch()
    {
        print(gameObject.name + " is punching");
    }
    public void GoForwards()
    {
        print(gameObject.name + " is going forwards");
    }
}
