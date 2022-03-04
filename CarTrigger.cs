using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CarTrigger : MonoBehaviour
{

 
    public Text distractionText;
    public bool CarTriggerHit;
    public Transform newCar;
    public GameObject carLocation;
    string carLocationFindString;
    Transform carName;




 


    // Start is called before the first frame update
    void Start()
    {
        //Gets ready to change text if trigger hit
        distractionText = GameObject.Find("DistractionText").GetComponent<Text>(); 
        CarTriggerHit = false;


        //Finds relevent car
        carLocationFindString = "CarSpawnLocation" + this.name[this.name.Length - 1];
        carLocation = GameObject.Find(carLocationFindString); 

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    //If not already hit, the pad spawns the car
    private void OnTriggerEnter(Collider other) {
                
    
        if( !CarTriggerHit){
 
            if(carLocation)
            carName = Instantiate(newCar, carLocation.transform.position + new Vector3(0,-0.5f,0), carLocation.transform.rotation);
            carName.name = "Car"+this.name[this.name.Length - 1];
           
        }

        CarTriggerHit = true;
       

    }


    
}
