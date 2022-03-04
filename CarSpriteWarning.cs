using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarSpriteWarning : MonoBehaviour
{

    //Car sprite
    Image image;
    public string carToLookAt;
    public Transform player;
    public GameObject target;

    //For collision
    GameObject cam ;
    MouseLook mouseLook;

    // Start is called before the first frame update
    void Start()
    {
        carToLookAt =  "Fake_Car";

        image = GetComponent<Image>();
        //Material material = new Material(Shader.Find("Unlit/Texture"));

        cam = GameObject.Find("Main Camera");
        mouseLook = cam.GetComponent<MouseLook>();

    }

    // Update is called once per frame
    void Update()
    {

        //target = GameObject.Find(carToLookAt);
        
        target = mouseLook.car;
        //Debug.Log(target.name);
        float distanceToTest = Vector3.Distance(player.transform.position, target.transform.position);

        //Debug.Log(distanceToTest);a

        image.color = new Color32((byte) (255/(distanceToTest/4)), 0 ,0,100);
        image.rectTransform.sizeDelta = new Vector2(300/(distanceToTest/12), 200/(distanceToTest/12));

        if(target.transform.position.z < player.transform.position.z){
            image.rectTransform.anchoredPosition = new Vector2(500, 0);
            
        }else{
            image.rectTransform.anchoredPosition = new Vector2(-500, 0);
           
        }
    }
}

