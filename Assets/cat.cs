using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cat : MonoBehaviour
{
    public Animator animator;
    public CharacterController character;
    Vector3 movement_input;
    bool isJumping;

    public float walking_speed;
    public float running_speed;
    public float jump_speed;
    public float gravity;

    // Use this for initialization
    void Start()
    {
        isJumping = false;
        movement_input = Vector3.zero;
        walking_speed = 3.0f;
        running_speed = 5.0f;
        //jump_speed = 3.0f;
        //gravity = 2.4f;
    }

    // FixedUpdate is used for Physics
    void FixedUpdate()
    {
        float speed = 0.0f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = running_speed;
        }
        else
        {
            speed = walking_speed;
        }
        print(Input.GetAxis("Horizontal"));
        movement_input.x = Input.GetAxis("Horizontal") * speed;
        movement_input.z = Input.GetAxis("Vertical") * speed;
        //if (character.isGrounded)
        //{
        //    animator.SetBool("isJumping", false);
        //    if (Input.GetKeyDown(KeyCode.Space))
        //    {
        //        movement_input.y = jump_speed;
        //    }
        //}
        //else
        //{
        //    movement_input.y = movement_input.y - gravity * Time.deltaTime;
        //    animator.SetBool("isJumping", true);
        //}
        print(movement_input);
        if (movement_input.x != 0 || movement_input.z != 0)
        {
            print("LOL");
            character.Move(movement_input * Time.deltaTime);
            character.transform.rotation = Quaternion.LookRotation(new Vector3(movement_input.x, 0.0f, movement_input.z));
            animator.SetBool("isWalking", true);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("isRunning", true);
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isWalking", false);
        }

    }
}
