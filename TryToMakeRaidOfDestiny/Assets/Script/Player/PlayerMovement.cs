using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    Vector3 velocity;
    bool isGrounded;
    bool crouching;
    bool lerpCrouch;
    bool sprinting;
    float crouchTimer;
    [SerializeField]float speed = 5;
    [SerializeField]float sprintingSpeed = 8;
    [SerializeField]float normalSpeed = 5;
    [SerializeField]float crouchSpeed = 4;
    [SerializeField]float gravity = 9.8f;
    [SerializeField]float jumpHeigh = 3f;
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = controller.isGrounded;
        if (lerpCrouch) 
        {
            crouchTimer += Time.deltaTime;
            float p = crouchTimer / 1;
            if (crouching) 
            {
                controller.height = Mathf.Lerp(controller.height, 1, p);
            }
            //if (sprinting) 
            //{
            //    controller.height = Mathf.Lerp(controller.height, 2, p);
            //}
            else 
            {
                controller.height = Mathf.Lerp(controller.height, 2, p);
            }

            if (p > 1) 
            {
                lerpCrouch = false;
                crouchTimer = 0;
            }
        }
    }

    public void Movement(Vector2 input) 
    {
        Vector3 direction = Vector3.zero;
        direction.x = input.x;
        direction.z = input.y;
        controller.Move(transform.TransformDirection(direction) * speed * Time.deltaTime);
        velocity.y -= gravity * Time.deltaTime;
        if(isGrounded && velocity.y < 0) 
        {
            velocity.y = -2f;
        }
        controller.Move(velocity * Time.deltaTime);
        Debug.Log(speed);
    }

    public void jump() 
    {
        if (isGrounded) 
        {
            velocity.y = Mathf.Sqrt(jumpHeigh * 3.06f * gravity);
        }
    }

    public void Crouch() 
    {
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;
        if (crouching) 
        {
            speed = crouchSpeed;
        }
        else { speed = normalSpeed; }
    }

    public void Sprint()
    {
        sprinting = !sprinting;
        if(crouching && sprinting) 
        {
            Crouch();
            speed = sprintingSpeed;
        }
        if (sprinting)
        {
            speed = sprintingSpeed;
        }
        else { speed = normalSpeed; }
    }
}
