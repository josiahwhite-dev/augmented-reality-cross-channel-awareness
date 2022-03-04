using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimingScript : MonoBehaviour
{
   
    private float startTime;
    public bool triggerHit;
    public Text distractionText;
    float t;
    float t2;

    CarTrigger carTrigger;
    GameObject carTrig;

     string findString;

    void Start()
    {
        startTime = Time.time;
        t = 0;
        t2 = 0;
        distractionText = GameObject.Find("DistractionText").GetComponent<Text>(); 
        triggerHit = false;

         findString = "CarCollisionTrigger" + this.name[this.name.Length - 1];
        
        carTrig = GameObject.Find(findString);
        carTrigger = carTrig.GetComponent<CarTrigger>();
    }

    // Update is called once per frame
    void Update()
    {
        
        ////Debug.Log(carTrigger.CarTriggerHit + "  "+ findString + this.name);
        //Run as normal until trigger hit
        ////Debug.Log(carTrigger.CarTriggerHit);
        if(!carTrigger.CarTriggerHit){

        //t = Time.time - startTime;

            t+= Time.deltaTime;
            float secondsToAdd = ((int)(t%60));
            //
            
            switch (secondsToAdd){
                case 0:
                    distractionText.text = "";
                    break;
                case 5:
                    //Debug.Log("Start Movement");
                    break;
                case 10:
                makeMaths();
                    break;
                case 15:
                    //Debug.Log("Ans 1");
                    distractionText.text = "True or false?";
                    break;
                case 18: 
                    makeMaths();
                    break;
                case 23:
                    //Debug.Log("Car in View + Answer");
                    distractionText.text = "True or false?";
                    break;
                case 25:
                    makeMaths();
                    break;

                case 30:
                    ////Debug.Log("Collision Time");
                     distractionText.text = "True or false?";
                    break;
                case 40:
                    //Debug.Log("ff Road");
                    break;
                case 45:
                    //Debug.Log("DONE");
                    break;

                }
        }else{

            t2 += Time.deltaTime; 
            
            float secondsToAdd = ((int)(t2%60));

            switch (secondsToAdd){
                case 0:
                    makeMaths();
                    break;
                case 3:
                    distractionText.text = "True or false?";
                    break;
            }
        }
       
    }

   void makeMaths(){

        int n1 = (int)(Random.Range(0f,100f));
        int n2 = (int)(Random.Range(0f,100f));
                
        int ans = n1+n2;

        string textTrue = n1.ToString() + "+" +n2.ToString()+" = "+ans.ToString();
        string textFalse = n1.ToString() + "+" +n2.ToString()+" = "+((int)(Random.Range(ans-10,ans+10))).ToString();

        if(Random.Range(0f,1f) > 0.5f){
            distractionText.text = textTrue; //n1.ToString() + "+" +n2.ToString()+" = "+ans.ToString();
        }else{
            distractionText.text = textFalse;//n1.ToString() + "+" +n2.ToString()+" = "+((int)(Random.Range(ans-10,ans+10))).ToString();
        }

   }
}
