using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour
{

    public GameObject carToHighlight;
    public string carToLookAt;
    public GameObject sphere;
    public GameObject player;

    //For collision
    GameObject cam ;
    MouseLook mouseLook;
    public bool isEnabled;


    // Start is called before the first frame update
    void Start()
    {
        //Distance
        cam = GameObject.Find("Main Camera");
        mouseLook = cam.GetComponent<MouseLook>();
        isEnabled = false;
        carToLookAt = "Fake_Car";


        /*//Flipping normals so inside of sphere can be seen
        Mesh mesh = this.GetComponent<MeshFilter>().mesh;
        Vector3[] normals = mesh.normals;
        for(int i = 0; i < normals.Length; i++){
            normals[i] = -1*normals[i];
        }
        mesh.normals = normals;

        //Now changing triangle order to anticlockwise order
        for (int i = 0; i < mesh.subMeshCount; i++){
            int[] meshTriangles = mesh.GetTriangles(i);
            for(int j = 0; j < meshTriangles.Length; j++){
                //Swapping order
                int temp = meshTriangles[j];
                meshTriangles[j] = meshTriangles[j+1];
                meshTriangles[j+1] = temp;
            }
            mesh.SetTriangles(meshTriangles, i);
        }*/

    }

    // Update is called once per frame
    void Update()
    {

        carToHighlight = GameObject.Find(carToLookAt);
        sphere.transform.position = carToHighlight.transform.position;


    // Debug.Log(Vector3.Distance(player.transform.position, sphere.transform.position));

    //Only shows if curently selected
    if(isEnabled){
        if(mouseLook.collisionClose == false){
            sphere.GetComponent<Renderer>().enabled = false;
        }else{
            sphere.GetComponent<Renderer>().enabled = true;

            float distance = Vector3.Distance(player.transform.position, sphere.transform.position);
            float radius = distance/(1.3f);

            radius = Mathf.Min(radius, 15);

            var sphereRenderer = sphere.GetComponent<Renderer>();
  
            sphere.transform.localScale = new Vector3(Mathf.Max(radius,10),Mathf.Max(radius,10),Mathf.Max(radius,10));

             sphereRenderer.material.SetColor("_Color", new Color32( (byte)( 255/(Mathf.Max(1,distance/8)) ),0,0,  132));
            
        }
    }else{
        sphere.GetComponent<Renderer>().enabled = false;
    }
        
    }
}
