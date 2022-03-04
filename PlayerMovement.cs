using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public CharacterController controller;
    public float moveSpeed = 12;
    Vector3 velocity;
    public float gravity = -9.81f;
    public  bool canMove = true;

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown("space")){

            if(Time.timeScale == 0){
                Time.timeScale =1;
            }else{
                 Time.timeScale = 0;
            }

          
        }



        if(canMove){
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");


            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * moveSpeed * Time.deltaTime);
    
            velocity.y += gravity * Time.deltaTime;

            //Multiply again for gravity
            controller.Move(velocity * Time.deltaTime);
        }

    }
}
