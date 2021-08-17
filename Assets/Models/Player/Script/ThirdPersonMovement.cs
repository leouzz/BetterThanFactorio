using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
   public CharacterController controller;
   public Animator anim;

   public float speed = 6f;
   public float turnSmoothTime = 0.1f;
   float turnSmoothVelocity;
   public float gravity = -9.81f;
   public float jumpSpeed = 8f;

   public Transform groundCheck;
   public float groundDistance = 0.4f;
   public LayerMask groundMask; 

   Vector3 velocity; 

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        anim.SetBool("Move", false);
        if (direction.magnitude >= 0.1f){
            if (horizontal == 0 && vertical == 0) anim.SetBool("Move", false);
                else anim.SetBool("Move", true);
            
            controller.Move(direction* speed * Time.deltaTime);

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);            
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);        
    }
}
