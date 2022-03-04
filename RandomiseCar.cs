using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomiseCar : MonoBehaviour
{
    // Start is called before the first frame update

    //Each Area
    public GameObject CarLoc1;
    public GameObject CarLoc2;
    public GameObject CarLoc3;
    public GameObject CarLoc4;
    public GameObject CarLoc5;
    public GameObject CarLoc6;

    //Left & Right Locations
    public GameObject CL1_L;
    public GameObject CL1_R;
    public GameObject CL2_L;
    public GameObject CL2_R;
    public GameObject CL3_L;
    public GameObject CL3_R;
    public GameObject CL4_L;
    public GameObject CL4_R;
    public GameObject CL5_L;
    public GameObject CL5_R;
    public GameObject CL6_L;
    public GameObject CL6_R;

    //Hiding Loations
    public Material transparent;

    //Trigger points
    public GameObject Trigger1;
    public GameObject Trigger2;
    public GameObject Trigger3;
    public GameObject Trigger4;
    public GameObject Trigger5;
    public GameObject Trigger6;

    List<GameObject> CarSpawnPositionList;
    List<GameObject> CarSpawnAreaL;
    List<GameObject> CarSpawnAreaR;
    List<GameObject> triggerList;


    List<Vector3> VerticeList = new List<Vector3>(); //List of global vertices on the plane
    List<Vector3> VerticeListToShow = new List<Vector3>();//Ones to show



   
    void Start()
    {

       
        //Grouping for the loop
        CarSpawnPositionList = new List<GameObject>();
        CarSpawnPositionList.AddRange(new List<GameObject>{

            CarLoc1,
            CarLoc2,
            CarLoc3,
            CarLoc4,
            CarLoc5,
            CarLoc6,

        });





        CarSpawnAreaL = new List<GameObject>();
        CarSpawnAreaL.AddRange(new List<GameObject>{

            CL1_L,
           
            CL2_L,
         
            CL3_L,
           
            CL4_L,
            
            CL5_L,
            
            CL6_L,
           

        });

        CarSpawnAreaR = new List<GameObject>();
        CarSpawnAreaR.AddRange(new List<GameObject>{

           
            CL1_R,
           
            CL2_R,
           
            CL3_R,
            
            CL4_R,
           
            CL5_R,
            
            CL6_R,


        });

        //First, changing the locations to be x seconds away from the trigger point
        triggerList = new List<GameObject>();
        triggerList.AddRange(new List<GameObject>{
            Trigger1,
            Trigger2,
            Trigger3,
            Trigger4,
            Trigger5,
            Trigger6,
        });

        //10 Units per Second
        int carSpeed = 10;
        //Want 6 seconds away
        int x = 4;
        for(int i = 0; i < triggerList.Count; i++){
            
            //Shifting it speed*time units in right direction
            //Note: Read forward as left/right, right as forward/back. 
            //New Position                      =  Trigger position                  +      Trigger right/left * speed * time            +      Trigger.forawrd (so on road)
            CarSpawnAreaR[i].transform.position =  triggerList[i].transform.position + (triggerList[i].transform.right * carSpeed * x) + (triggerList[i].transform.forward * 5);
            CarSpawnAreaL[i].transform.position =  triggerList[i].transform.position + ((triggerList[i].transform.right * -1) * carSpeed * x) + (triggerList[i].transform.forward * 5);

        }

        //Getting rid of position colours:
        for(int i = 0; i < CarSpawnAreaL.Count; i++){
           CarSpawnAreaL[i].GetComponent<Renderer>().material = transparent;
            CarSpawnAreaR[i].GetComponent<Renderer>().material = transparent;
        
        
        }





        //For each area
        for(int i = 0; i < CarSpawnPositionList.Count; i++){
             int test = Random.Range(1,3);
             Debug.Log(test);

            //If 1 do Left
             if(test == 1){
                VerticeList = new List<Vector3>(CarSpawnAreaL[i].GetComponent<MeshFilter>().sharedMesh.vertices);
                VerticeListToShow.Add(CarSpawnAreaL[i].transform.TransformPoint(VerticeList[0]));
                VerticeListToShow.Add(CarSpawnAreaL[i].transform.TransformPoint(VerticeList[10]));
                VerticeListToShow.Add(CarSpawnAreaL[i].transform.TransformPoint(VerticeList[110]));
                VerticeListToShow.Add(CarSpawnAreaL[i].transform.TransformPoint(VerticeList[120]));

                CarSpawnPositionList[i].transform.position = new Vector3(Random.Range(VerticeListToShow[0].x,VerticeListToShow[1].x),0.5f,Random.Range(VerticeListToShow[0].z,VerticeListToShow[3].z));
             }else{
                VerticeList = new List<Vector3>(CarSpawnAreaR[i].GetComponent<MeshFilter>().sharedMesh.vertices);
                VerticeListToShow.Add(CarSpawnAreaR[i].transform.TransformPoint(VerticeList[0]));
                VerticeListToShow.Add(CarSpawnAreaR[i].transform.TransformPoint(VerticeList[10]));
                VerticeListToShow.Add(CarSpawnAreaR[i].transform.TransformPoint(VerticeList[110]));
                VerticeListToShow.Add(CarSpawnAreaR[i].transform.TransformPoint(VerticeList[120]));

                CarSpawnPositionList[i].transform.position = new Vector3(Random.Range(VerticeListToShow[0].x,VerticeListToShow[1].x),0.5f,Random.Range(VerticeListToShow[0].z,VerticeListToShow[3].z));
             }

             VerticeListToShow.Clear();
             
        }
        

       

        //Getting borders of plane:
        //https://medium.com/@Scriptie/how-to-find-corners-of-a-plane-in-unity-9de20efec7d

        //Gets bounds of Left of CL3

        ///This now has all positions of the corners of the Left of CL3
      /*  VerticeList = new List<Vector3>(CL3_R.GetComponent<MeshFilter>().sharedMesh.vertices); //get vertice points from the mesh of the object
        VerticeListToShow.Add(CL3_R.transform.TransformPoint(VerticeList[0]));
        VerticeListToShow.Add(CL3_R.transform.TransformPoint(VerticeList[10]));
        VerticeListToShow.Add(CL3_R.transform.TransformPoint(VerticeList[110]));
        VerticeListToShow.Add(CL3_R.transform.TransformPoint(VerticeList[120]));
        Debug.Log("Top Left: "+VerticeListToShow[0]);
        Debug.Log("Top Right: "+VerticeListToShow[1]);
        Debug.Log("Bottom Left: "+VerticeListToShow[2]);
        Debug.Log("Bottom Right: "+VerticeListToShow[3]);*/


        //CarLoc3.transform.position = new Vector3(Random.Range(VerticeListToShow[0].x,VerticeListToShow[1].x),0.5f,Random.Range(VerticeListToShow[0].z,VerticeListToShow[3].z));
        // Debug.Log("HEY: "+CarLoc3.transform.position);
        
        ///////////////////////////////////////////////////////////////////
        //This can be automated using a for loop and the names of the planes 
        //Then just take the .x coordinates for the random ranges and should be good to go. 



        //CarLoc1.transform.position = new Vector3(Random.Range(-55f,-51f),0.5f,Random.Range(26f,60f));
        //CarLoc2.transform.position = new Vector3(Random.Range(-41f,-16f),0.5f,Random.Range(0,6));


        //Testing the Car Range
        
       // CarLoc4.transform.position = new Vector3(Random.Range(-90f,-60f),0.5f,Random.Range(2,6));
      //  CarLoc5.transform.position = new Vector3(Random.Range(24f,34f),0.5f,Random.Range(-49,-13));    
       // CarLoc6.transform.position = new Vector3(Random.Range(26f,60f),0.5f,Random.Range(0,6));    
    
    }

    // Update is called once per frame
    void Update()
    {
         
       
    }
}
