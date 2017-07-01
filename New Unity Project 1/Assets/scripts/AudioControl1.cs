using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using UnityEngine.UI;







public class AudioControl1 : MonoBehaviour
{
    public string keytopress;
    public bool active;
    public float wait;
    public float volumeLevel;
    public float turndowntimer;
    public bool turndownActivate;
    public FMODUnity.StudioEventEmitter emitter;
    public Color randomcolor;
    public Image thisbutton;
    // Use this for initialization
    void Start()
    {
        wait = 1f;
       // gameObject.GetComponent<Renderer>().material.color = (Color.black);
       emitter = this.gameObject.GetComponent<FMODUnity.StudioEventEmitter>();
        randomcolor = (new Color(Random.value, Random.value, Random.value, 1));
        thisbutton = gameObject.GetComponent<Image>();
        keytopress = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        emitter.SetParameter("volume", turndowntimer);

       

        if (turndownActivate == true && turndowntimer >=0.000000001)
        {
            turndowntimer = turndowntimer - Time.deltaTime / 2;
            this.gameObject.transform.position = new Vector3(gameObject.transform.position.x, -50, gameObject.transform.position.z);
        }

        if (turndownActivate == false && turndowntimer <= 1 && emitter.enabled == true)
        {
            turndowntimer = turndowntimer + Time.deltaTime / 2;
            thisbutton.color= randomcolor;
            this.gameObject.transform.position = new Vector3(gameObject.transform.position.x, -8, gameObject.transform.position.z);
        }

        if (active)
        {
            



        }
      
        if (Input.GetKeyDown (keytopress) && !active )
            
        {
            
            //YOU NEED TO ADD FMODUnity BECAUSE IN StudioEventEmitter IT IS IN A NAME SPACE
            this.gameObject.GetComponent<FMODUnity.StudioEventEmitter>().enabled = true;

        //    gameObject.GetComponent<Renderer>().material.color = (Color.green);
            wait = wait - 0.5f;
            turndownActivate = false;
           // active = true;
        }


        if (Input.GetKeyDown(keytopress) && wait <= 0 && turndownActivate == false)
        {
        //    gameObject.GetComponent<Renderer>().material.color = (Color.black);
            wait = 1f;
            Debug.Log("YEP I WORK");
            

            ;            turndownActivate = true;
            //    this.gameObject.GetComponent<FMODUnity.StudioEventEmitter>().enabled = false;
        }
    }
}

