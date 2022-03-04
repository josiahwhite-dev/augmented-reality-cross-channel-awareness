using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

    public float mouseSensitivity = 500f;
    public Transform playerBody;
    private float xRotation = 0f;
    public bool canLook = true;
    public float mouseX;
    public float mouseY;
    public string playerToLookAt;


    //Drawing Circle
    //https://gamedev.stackexchange.com/questions/192118/how-can-i-draw-a-circle-around-a-specific-object-not-necessarily-the-object-the
     
    //For distance to car & activating different warnings
    float timeToImpact;
    public GameObject car;
    public string targetCar;
    
    public bool collisionClose;

    float x = 0f;
        


    
    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        collisionClose = false;
        playerToLookAt = "Fake_Car";
       // targetCar = "Fake_Car";
    }

    // Update is called once per frame
    void Update()
    {   

        GameObject target = GameObject.Find(playerToLookAt);

      

        //Deals with looking at path 
        if(canLook){
             mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
             mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            //Flips rotation and rotates
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation,-90f,90f);

            playerBody.Rotate(Vector3.up * mouseX);
 
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }else{
                
               // transform.LookAt(target.transform.position);


               /*   Rotation idea from: https://gamedevbeginner.com/how-to-rotate-in-unity-complete-beginners-guide/#rotate_towards_object */

               //Need to change local rotation instead of global. 
               
                // float degreesPerSecond = 90 * Time.deltaTime;
                // Vector3 direction = target.transform.position - transform.position;
                //  //transform.localRotation = w(-direction.x, 0f, 0f);
                // Quaternion targetRotation = Quaternion.LookRotation(direction);
                // //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, degreesPerSecond);
                // transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, degreesPerSecond);
                // playerBody.Rotate(Vector3.up);

                float degreesPerSecond = 90 * Time.deltaTime;
                //Vector3 direction = target.transform.position - transform.position;
                Vector3 direction = target.transform.position - transform.position;
                 //transform.localRotation = Quaternion.Euler(-direction.x, 0f, 0f);
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                //transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, degreesPerSecond);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, degreesPerSecond);
                playerBody.rotation = Quaternion.RotateTowards(playerBody.transform.rotation, targetRotation, degreesPerSecond);
               // = Quaternion.RotateTowards(transform.rotation, targetRotation, degreesPerSecond).y;
               //Rotates the camera up a bit 
               //transform.rotation = Quaternion.Euler(transform.rotation.x, Quaternion.RotateTowards(transform.rotation, targetRotation, degreesPerSecond).y, transform.rotation.z);
               
          
               

                


            }

         
        car = GameObject.Find(targetCar);
        //Gets time until impact which is used in otherscripts
        //car = GameObject.Find("Car+"+playerToLookAt[playerToLookAt.Length - 1]);
        //Debug.Log("Car"+playerToLookAt[playerToLookAt.Length - 1]);
        //car = GameObject.Find("Fake_Car");
        timeToImpact = Vector3.Distance(transform.position, car.transform.position)/10;
        //Debug.Log("Distance: "+Vector3.Distance(transform.position, car.transform.position));

        if(car){
            if(timeToImpact > 6){
                collisionClose = false;
            }else{
                collisionClose = true;
            }
        }else{
            collisionClose = false;
        }
            



    }



    void fixAngles(float x,float y,float z){
        transform.localRotation = Quaternion.Euler(x, y, z);
    }
}
