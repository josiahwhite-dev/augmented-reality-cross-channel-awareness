using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{

    //For changing what should be looked at
    public string carToLookAt;
    public Transform player;
    public GameObject target;
    public GameObject arrow;
    GameObject car;

    //For collision
    GameObject cam ;
    MouseLook mouseLook;
    public bool isEnabled;


    

    // Start is called before the first frame update
    void Start()
    {
        carToLookAt =  "Fake_Car";
        arrow.GetComponent<Renderer>().enabled = false;
        
       
        //Distance
        cam = GameObject.Find("Main Camera");
        mouseLook = cam.GetComponent<MouseLook>();
        //isEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        target = GameObject.Find(carToLookAt);

        if(!target){
             arrow.GetComponent<Renderer>().enabled = false;
        }


        car = GameObject.Find(carToLookAt);
        transform.LookAt(target.transform.position);
       

        
       var relativePlayerCar = player.transform.InverseTransformPoint(target.transform.position);

       if(relativePlayerCar.x > 0.0f){
             while(transform.localPosition.x < 200){
                transform.localPosition += Vector3.right;
            }
       }else{
             while(transform.localPosition.x > -200){
                transform.localPosition += Vector3.left;
            }
       }

        /*if(target.transform.position.z < player.transform.position.z){

            while(transform.localPosition.x < 200){
                transform.localPosition += Vector3.right;
            }
            
        }else{

             while(transform.localPosition.x > -200){
                transform.localPosition += Vector3.left;
            }
            
        }*/

        
        
        if(isEnabled){
                if(mouseLook.collisionClose == false){
                    arrow.GetComponent<Renderer>().enabled = false;
                }else{
                    Debug.Log("arrow visible!");
                    arrow.GetComponent<Renderer>().enabled = true;
                }
        }else{
            arrow.GetComponent<Renderer>().enabled = false;
        }

       
      

    }
}
