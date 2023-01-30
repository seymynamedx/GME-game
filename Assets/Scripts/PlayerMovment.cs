using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovment : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveVector;
    private float speed = 10.0f;
    private float vertical = 0.0f;
    private float gravity = 12.0f;
    private bool smierc = false;
    

    void Start()
    {
        controller = GetComponent<CharacterController>();

        
    }

    
    void Update()
    {
        if (smierc == true)
            return;

        moveVector = Vector3.zero;
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        moveVector.z = speed;


        if (controller.isGrounded) 
        {
            vertical = -1.0f;


        }
        else 
        {
            vertical -= gravity * Time.deltaTime;

        }

        moveVector.y = vertical;


        controller.Move(moveVector * Time.deltaTime);


       

    }

    public void SetSpeed(float mod)
    {
        speed = 10.0f + mod;



    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.point.y > transform.position.y + controller.radius)
            Death();
        
    }
    private void Death()
    {
        smierc = true;
        GetComponent<Score>().OnDeath();
    }

     





}
