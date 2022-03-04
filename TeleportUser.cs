
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportUser : MonoBehaviour
{

    //Locations where user spawns at
    public Transform L1;
    public Transform L2;
    public Transform L3;
    public Transform L4;
    public Transform L5;
    public Transform L6;
    public GameObject user;

    //Times events for current experiment
    public Transform timerStarter;

    //List for random picking, not duplicating locations
    public List<Transform> Locations = new List<Transform>();
    static public List<int> SeenLocations = new List<int>();

    //Deals with player not moving & looking at end
    GameObject player;
    PlayerMovement playerMovement;

    //Sphere (old)
    //GameObject UI;
    //WarningMove warningMove;

    //Sphere (real)
    GameObject sphere;
    SphereScript sphereScript;

    //Move head when start
    GameObject cam ;
    MouseLook mouseLook;

    //Sets up timer
    Transform timerWithName;

    //Arrow
    GameObject pyramid;
    ArrowScript arrowScript;


    //Circle
    GameObject circle;
    CircleRadius circleRadius;

    //Side Camera
    GameObject sideCam;
    SideCameraMover sideCameraMover;

    //Side Camera View
    GameObject sideCamViewer;
    SideCamViewScript sideCamViewScript;


    //Showing path to locations
    public Transform LocationPath1;
    public Transform LocationPath2;
    public Transform LocationPath3;
    public Transform LocationPath4;
    public Transform LocationPath5;
    public Transform LocationPath6;
    //Seeing which path/location
    int rand;

  

    void Start(){
        Locations.Add(L1);
        Locations.Add(L2);
        Locations.Add(L3);
        Locations.Add(L4);
        Locations.Add(L5);
        Locations.Add(L6);

        player = GameObject.Find("FirstPersonCharacter");
        playerMovement = player.GetComponent<PlayerMovement>();

       // UI = GameObject.Find("UI");
       // warningMove = UI.GetComponent<WarningMove>();

        pyramid = GameObject.Find("pyramid");
        arrowScript = pyramid.GetComponent<ArrowScript>();

        circle = GameObject.Find("CircleController");
        circleRadius = circle.GetComponent<CircleRadius>();

        sphere = GameObject.Find("WarningSphere");
        sphereScript=sphere.GetComponent<SphereScript>();
    

        cam = GameObject.Find("Main Camera");
        mouseLook = cam.GetComponent<MouseLook>();

        sideCam = GameObject.Find("SideCamera");
        sideCameraMover = sideCam.GetComponent<SideCameraMover>();

        sideCamViewer = GameObject.Find("SideCameraViewerController");
        sideCamViewScript = sideCamViewer.GetComponent<SideCamViewScript>();
    }
   



    private void OnTriggerEnter(Collider other) {

        Debug.Log("Collided With"+ gameObject.name);



        if(SeenLocations.Count == Locations.Count){
            return;
        }

        //Picking Location
        rand = RandomNumber(1,7);
        while(SeenLocations.Contains(rand)){
            rand = RandomNumber(1,7);
        }

  //      rand = 2;
   
        SeenLocations.Add(rand);       


        if( rand == 1){
            mouseLook.playerToLookAt = "LocationMarker1";
            mouseLook.targetCar = "Car1";
            sphereScript.carToLookAt = "Car1";
            arrowScript.carToLookAt ="Car1";
            circleRadius.carToLookAt ="Car1";
            sideCameraMover.carToLookAt ="Car1";
            sideCamViewScript.carToLookAt ="Car1";
        }else if (rand == 2){
            mouseLook.playerToLookAt = "LocationMarker2";
               mouseLook.targetCar = "Car2";
             sphereScript.carToLookAt = "Car2";
             arrowScript.carToLookAt ="Car2";
             circleRadius.carToLookAt ="Car2";
                sideCameraMover.carToLookAt ="Car2";
                     sideCamViewScript.carToLookAt ="Car2";
        }else if (rand == 3){
            mouseLook.playerToLookAt = "LocationMarker3";
               mouseLook.targetCar = "Car3";
             sphereScript.carToLookAt = "Car3";
             arrowScript.carToLookAt ="Car3";
             circleRadius.carToLookAt ="Car3";
            sideCameraMover.carToLookAt ="Car3";
            sideCamViewScript.carToLookAt ="Car3";
        }else if (rand == 4){
            mouseLook.playerToLookAt = "LocationMarker4";
               mouseLook.targetCar = "Car4";
             sphereScript.carToLookAt = "Car4";
              arrowScript.carToLookAt = "Car4";
              circleRadius.carToLookAt ="Car4";
                 sideCameraMover.carToLookAt ="Car4";
                      sideCamViewScript.carToLookAt ="Car4";
        }else if (rand == 5){
            mouseLook.playerToLookAt = "LocationMarker5";
               mouseLook.targetCar = "Car5";
             sphereScript.carToLookAt = "Car5";
             arrowScript.carToLookAt ="Car5";
             circleRadius.carToLookAt ="Car5";
                sideCameraMover.carToLookAt ="Car5";
                     sideCamViewScript.carToLookAt ="Car5";
        }else if (rand == 6){
            mouseLook.playerToLookAt = "LocationMarker3";
               mouseLook.targetCar = "Car6";
             sphereScript.carToLookAt = "Car6";
             arrowScript.carToLookAt ="Car6";
             circleRadius.carToLookAt ="Car6"; 
                sideCameraMover.carToLookAt ="Car6";
                     sideCamViewScript.carToLookAt ="Car6";
        }


               
       //Picking Warning Signal
        //int rand2 = RandomNumber(1,5);
        int rand2 = 3;
      
       
       //If 1, only want circle
       if( rand2 == 1){
            Debug.Log("CIRCLE!");
            circleRadius.isEnabled = true;
            arrowScript.isEnabled = false;
            sphereScript.isEnabled = false;
            sideCamViewScript.isEnabled = false;

        //If 2, only want sphere
       }else if(rand2 == 2){
            Debug.Log("SPHERE!");
            circleRadius.isEnabled = false;
            arrowScript.isEnabled = false;
            sphereScript.isEnabled = true;
             sideCamViewScript.isEnabled = false;
           
        //If 3, only want arrow
       }else if(rand2 == 3){
            Debug.Log("ARROW!");
           circleRadius.isEnabled = false;
            arrowScript.isEnabled = true;
            sphereScript.isEnabled = false;
             sideCamViewScript.isEnabled = false;

        //If 4, only want screen
       }else if(rand2 == 4){
            circleRadius.isEnabled = false;
            arrowScript.isEnabled = false;
            sphereScript.isEnabled = false;
            sideCamViewScript.isEnabled = true;
            Debug.Log("SideCam! En? "+sideCamViewScript.isEnabled.ToString());



       }else{
           circleRadius.isEnabled = false;
            arrowScript.isEnabled = false;
            sphereScript.isEnabled = false;
             sideCamViewScript.isEnabled = false;
       }


        //Debug.Log("Rand: "+rand+" LOC: "+mouseLook.playerToLookAt);
        user.transform.position = Locations[rand-1].transform.position;

        timerWithName = Instantiate(timerStarter, new Vector3(2.0f, 0, 0), Quaternion.identity);
        timerWithName.name = "Timer"+rand.ToString();//+rand.ToString();
        
        //Timer for non-moving grace period   
       
        StartCoroutine(TimerCoroutine());


    }

    private IEnumerator TimerCoroutine(){
       

        playerMovement.canMove = false;
        mouseLook.canLook = false;
      
        Quaternion originalRotation = mouseLook.transform.rotation;

        //Moving up path
        GameObject currentPath = GameObject.Find("PathToEnd"+rand.ToString());
        while(currentPath.transform.position.y < 0){
            currentPath.transform.position += new Vector3(0,0.02f,0);
            yield return new WaitForSeconds(0.05f);
        }


        yield return new WaitForSeconds(5.0f);
        //yield return new WaitForSeconds(0.5f);

        while(currentPath.transform.position.y > -0.5){
            currentPath.transform.position += new Vector3(0,-0.02f,0);
             yield return new WaitForSeconds(0.05f);
        }

       // Quaternion newLocalRotation = mouseLook.transform.localRotation;
        playerMovement.canMove = true;
        mouseLook.canLook = true;
       // mouseLook.playerBody.Rotate(Vector3.up);
        //mouseLook.transform.localRotation = newLocalRotation;



     
        
    }

    private int RandomNumber(int min, int max){
        float a = Random.Range(min,max);
        int z = (int)a;

        return z;
    }

}
