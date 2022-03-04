using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningMove : MonoBehaviour
{
    // Start is called before the first frame update
    bool shouldLoom = false;
    public Transform player;
    Vector3 OGPos;
    float minDistance;
    GameObject CurrentCar;
    public GameObject WarningSphere;
    float OGSize;
    public string carToLookAt;

    void Start()
    {
       //minDistance = Vector3.Distance(transform.position, player.position);
       
       //OGPos = player.position + (Vector3.forward.x * 1.21 new Vector3(1.21f,0.1f,1.45f));
       carToLookAt =  "Fake_Car";
       
       OGPos = player.position + player.forward;
       OGSize = 4;
    }

    // Update is called once per frame
    void Update()
    {
      /*  if (Input.GetKeyDown("space")){
            TranslateLoom();
        }

        // Car to look at 
        CurrentCar = GameObject.Find(carToLookAt);
        //Debug.Log(carToLookAt);
        

        if(Input.GetKeyDown("b")){
            TranslateTranslate();
        }
       if( Vector3.Distance(transform.position, OGPos) > 0.001f){
        transform.position = Vector3.MoveTowards(transform.position, OGPos, 20*Time.deltaTime);  
       }

       if( WarningSphere.transform.localScale.x > OGSize){
            Vector3 tempScale = WarningSphere.transform.localScale;
            tempScale.x -= (180/Vector3.Distance(transform.position, OGPos)) * Time.deltaTime;
            tempScale.y -= (180/Vector3.Distance(transform.position, OGPos)) * Time.deltaTime;
            tempScale.z -= (180/Vector3.Distance(transform.position, OGPos)) * Time.deltaTime;
            WarningSphere.transform.localScale = tempScale;
       }

       OGPos =  player.position + (player.forward*2);*/


    }

    void TranslateLoom(){

        //OGPos  = transform.position;
        ///////////transform.Translate(Vector3.forward * 15);
        //Debug.Log(transform.position);

        transform.position = CurrentCar.transform.position;
        WarningSphere.transform.localScale = new Vector3(20f, 20f, 20f);

        shouldLoom = true;
       //transform.position = transform.position + new Vector3(0, 0, 2);
    }

    void TranslateTranslate(){
        transform.Translate(Vector3.right * 15);
    }
}
