using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideCameraMover : MonoBehaviour
{
    // Start is called before the first frame update
    public string carToLookAt;
    public Transform player;
    public GameObject target;

   
   

    
    void Start()
    {
      
        gameObject.layer = 2;
       
    }

    // Update is called once per frame
    void Update()
    {

        target = GameObject.Find(carToLookAt);
       
       

        
       var relativePlayerCar = player.transform.InverseTransformPoint(target.transform.position);

       if(relativePlayerCar.x > 0.0f){     

            Vector3 rotation = player.transform.right;
            rotation.y = 0f;

            transform.rotation = Quaternion.LookRotation(rotation);

                //Quaternion.Euler(transform.rotation.x, 90f, transform.rotation.z);
            
       }else{
            Vector3 rotation = -1*player.transform.right;
            rotation.y = 0f;

            transform.rotation = Quaternion.LookRotation(rotation);
                  //transform.rotation = Quaternion.Euler(transform.rotation.x, 0f, transform.rotation.z);
       }
        
    }
}
