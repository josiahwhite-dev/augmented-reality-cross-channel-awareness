using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideCamViewScript : MonoBehaviour
{

    public string carToLookAt;
    public Transform player;
    public GameObject target;

    public bool isEnabled;
    GameObject cam ;
    CarMoveScript carMoveScript;
    MouseLook mouseLook;
    public Image disableBoarder;
    public RawImage disableScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera");
        mouseLook = cam.GetComponent<MouseLook>();
        isEnabled = false;
    
    
        
    }

    // Update is called once per frame
    void Update()
    {

        RectTransform thisRectTransform = GetComponent<RectTransform>();
       


        target = GameObject.Find(carToLookAt);

        if(!target){
            disableBoarder.enabled = false;
            disableScreen.enabled = false;
        }
        carMoveScript = target.GetComponent<CarMoveScript>();

       

        
       var relativePlayerCar = player.transform.InverseTransformPoint(target.transform.position);

      if(relativePlayerCar.x > 0.0f){
            
              thisRectTransform.anchoredPosition = new Vector3(640, 290, 0);
        }else{
            
               thisRectTransform.anchoredPosition = new Vector3(-640, 290, 0);
             
        }


        Debug.Log("IE: "+isEnabled.ToString());


        if(isEnabled){
                if(mouseLook.collisionClose == false ){
                    disableBoarder.enabled = false;
                    disableScreen.enabled = false;
                }else{
                    if(carMoveScript.carIsSeen){
                        disableBoarder.enabled = false;
                        disableScreen.enabled = false;
                    }else{
                        disableBoarder.enabled = true;
                        disableScreen.enabled = true;
                    }
                }
        }else{
            disableBoarder.enabled = false;
             disableScreen.enabled = false;
        }


    }
}
