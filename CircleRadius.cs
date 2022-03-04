using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleRadius : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject go1;
    public string carToLookAt;

    //For collision
    GameObject cam ;
    MouseLook mouseLook;
    public bool isEnabled;
    GameObject carToHighlight;
    CarMoveScript carMoveScript;



    void Start()
    {
        carToLookAt = "aasdd";
        go1 = new GameObject { name = "Circle" };

        go1.transform.position = new Vector3(0,-100,0);
        DrawCircle(go1, 10, 0.2f);
        //go1.transform.Rotate(90f, 0, 90f);
        go1.transform.Rotate(0, 0, 90f);

       
        

       
        //Distance
        cam = GameObject.Find("Main Camera");
        mouseLook = cam.GetComponent<MouseLook>();
        
    }

    // Update is called once per frame
    void Update()
    {

        carToHighlight = GameObject.Find(carToLookAt);

      

        carMoveScript = carToHighlight.GetComponent<CarMoveScript>();
        if(isEnabled){
            if(mouseLook.collisionClose == false){
                go1.GetComponent<Renderer>().enabled = false;
            }else{
                go1.GetComponent<Renderer>().enabled = true;
            }
        }else{
            go1.GetComponent<Renderer>().enabled = false;
        }

          if(carToHighlight){
        go1.transform.position = carToHighlight.transform.position;
          }else{
              go1.transform.position = new Vector3(0,-30,0);
          }
       

        //go1.transform.rotation = Quaternion.Euler(go1.transform.rotation.x, go1.transform.rotation.y, 90);
        // go1.transform.LookAt(carToHighlight.transform);

        /* if(carMoveScript.moveDirection.x > 0){
              go1.transform.Rotate(0, 0, 90f);
         }else{
              go1.transform.Rotate(0, 90f, 90f);
         }*/
       
       
    }

    //From https://www.loekvandenouweland.com/content/use-linerenderer-in-unity-to-draw-a-circle.html

    public  void DrawCircle( GameObject container, float radius, float width){
        var segments = 360;
        var line = container.AddComponent<LineRenderer>();
        line.useWorldSpace = false;
        line.startWidth = width;
        line.endWidth = width;
        line.positionCount = segments + 1;

        //Makes start and end points overlap
        var pointCount = segments+1;
        var points = new Vector3[pointCount];

        for (int i = 0; i < pointCount; i++){
            var rad = Mathf.Deg2Rad * (i*360f / segments);
            points[i] = new Vector3(Mathf.Sin(rad) * radius, 0, Mathf.Cos(rad) * radius);
        }


        
            line.SetPositions(points);
        
    }
}
