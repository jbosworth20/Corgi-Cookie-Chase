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
    public float rotation_speed;
    public float jump_speed;
    public float gravity;

    // Use this for initialization
    void Start()
    {
        //isJumping = false;
        movement_input = Vector3.zero;
        // walking_speed = 5.0f;
        // running_speed = 7.0f;
        // rotation_speed = 10f;
        // jump_speed = 7.5f;
        // gravity = 4.5f;
    }

    // FixedUpdate is used for Physics
    void Update()
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
        movement_input.x = Input.GetAxisRaw("Horizontal") * speed;
        movement_input.z = Input.GetAxis("Vertical") * speed;

        print(movement_input.y);

        if(movement_input.y <= 0)
        {
            //animator.SetBool("isJumping", false);

            if (Input.GetKeyDown(KeyCode.Space))
                {
                    movement_input.y = jump_speed;
                }
        }
        
        if (movement_input.y > 0)
        {
            movement_input.y -= gravity * Time.deltaTime;
            character.Move(Vector3.up * movement_input.y * Time.deltaTime);
            //animator.SetBool("isJumping", true);
        }

        animator.SetFloat("movement_speed", (float) movement_input.z);

        if (movement_input.x != 0)
        {
            //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(0, 0, movement_input.z)), Time.deltaTime * 7);
            transform.Rotate(Vector3.up, Time.deltaTime * rotation_speed * movement_input.x);
        }

        if (movement_input.z != 0)
        {
            character.Move(transform.forward * movement_input.z * speed * Time.deltaTime);
            //Vector3 look_rot = Quaternion.LookRotation(new Vector3(movement_input.x, 0.0f, movement_input.z).normalized).eulerAngles;
            //animator.SetBool("isWalking", true);
            // if (Input.GetKey(KeyCode.LeftShift))
            // {
            //     animator.SetBool("isRunning", true);
            // }
        }
        // else
        // {
        //     print("NOT WALKING");
        //     //animator.SetBool("isRunning", false);
        //     //animator.SetBool("isWalking", false);
        // }

        //character.Move(new Vector3(0, movement_input.y, 0) * Time.deltaTime);
    }
}
