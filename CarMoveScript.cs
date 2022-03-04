using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarMoveScript : MonoBehaviour
{

    //Spawning car direction left and right
    public float direction;
    public GameObject player;
    PlayerMovement playerMovement;
    public Vector3 moveDirection;
    public Quaternion carRotation;
    GameObject triggerLocation;
    bool shouldMove;
    public Text distractionText;

    public bool carIsSeen = false;

    //Visibility
    Renderer m_Renderer;

    //Visibility #2 - CullingGroup
    CullingGroup group;
    BoundingSphere[] carSphereArray;

    // Start is called before the first frame update
    void Start()
    {
        //Stops when car hits
        shouldMove =true;

        //Cull
        group = new CullingGroup();
        carSphereArray = new BoundingSphere[1];
        group.targetCamera = Camera.main;
        carSphereArray[0] = new BoundingSphere(Vector3.zero, 1f);
        group.SetBoundingSpheres(carSphereArray);
        group.SetBoundingSphereCount(1);
        group.onStateChanged = StateChangedMethod;

        //Isvisible
        m_Renderer = GetComponent<Renderer>();

        //distractionText
         distractionText= GameObject.Find("DistractionText").GetComponent<Text>(); 


        player = GameObject.Find("FirstPersonCharacter");
        playerMovement = player.GetComponent<PlayerMovement>();
        //Debug.Log("Name: "+this.name);        
        moveDirection = transform.forward;

        //Finding the trigger to determine which direction
        triggerLocation = GameObject.Find("CarCollisionTrigger" + this.name[this.name.Length - 1]);


        //If forward is closer, move forward (want to get closer to the trigger initially)
      
        if(Vector3.Distance(transform.position + transform.forward, triggerLocation.transform.position) < Vector3.Distance(transform.position + (transform.forward*-1), triggerLocation.transform.position)){
            moveDirection = transform.forward;
        }else{
            moveDirection = transform.forward * -1;
            carRotation = Quaternion.Euler(0,0,0);
        }

        //Rotation
        transform.rotation = Quaternion.LookRotation (moveDirection);



        
    }

    // Update is called once per frame
    void Update()
    {

        //Updating Boundingsphere
        carSphereArray[0] = new BoundingSphere(transform.position, 2f);

        if(shouldMove){
        transform.position += moveDirection * Time.deltaTime*10;
        }
       // transform.rotation = carRotation;

        for(int i = 0; i < 4; i++){
        transform.GetChild(i).transform.Rotate(Vector3.right * (Time.deltaTime*500));
        }

      
      /*  if (m_Renderer.isVisible)
        {
            Debug.Log("Object is visible");
        }
        else Debug.Log("Object is no longer visible");*/

       // group.Dispose();
        
    }

    private void StateChangedMethod(CullingGroupEvent evt){
        if(evt.hasBecomeVisible){
            //Debug.Log("Car has become visible!");
            carIsSeen = true;
        }
        if(evt.hasBecomeInvisible){
           // Debug.Log("Car has become INVISIBLE!");
            carIsSeen = false;
        }
    }

     private void OnTriggerEnter(Collider other) {
        
         shouldMove = false;
         playerMovement.canMove = false;


          StartCoroutine(HitByCarCoroutine());
        
       
     }


     private IEnumerator HitByCarCoroutine(){

         for(int i = 10; i > 0; i--){
             distractionText.text = "Hit by car! \n Next test in "+i.ToString()+" seconds.";
             yield return new WaitForSeconds(1f);
         }
         //yield return new WaitForSeconds(5f);
         player.transform.position = new Vector3(12.55f, 1f, -169.2f); 

     }
     
           


      

}
