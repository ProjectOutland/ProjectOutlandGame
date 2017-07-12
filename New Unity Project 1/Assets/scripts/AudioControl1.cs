using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using UnityEngine.UI;







public class AudioControl1 : MonoBehaviour
{
    public PlantSpawn plantspawn;
    public string keytopress;
    public int plantNumber;
    public bool active;
    public float wait;
    public float volumeLevel;
    public float turndowntimer;
    public bool turndownActivate;
    public FMODUnity.StudioEventEmitter emitter;
    public Color firstcolor;
    public Image thisbutton;
    // Use this for initialization
    void Start()
    {
        wait = 1f;
       // gameObject.GetComponent<Renderer>().material.color = (Color.black);
       emitter = this.gameObject.GetComponent<FMODUnity.StudioEventEmitter>();
       thisbutton = gameObject.GetComponent<Image>();
        firstcolor = thisbutton.color;
        keytopress = gameObject.name;
    }

    // Update is called once per frame
    void Update()
    {
        emitter.SetParameter("volume", turndowntimer);

       

        if (turndownActivate == true && turndowntimer >=0.000000001)
        {
            turndowntimer = turndowntimer - Time.deltaTime / 2;
            thisbutton.color = Color.green;
           

            //  this.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - +1, gameObject.transform.position.z);
        }

        if (turndownActivate == false && turndowntimer <= 1 && emitter.enabled == true)
        {
            turndowntimer = turndowntimer + Time.deltaTime / 2;
            thisbutton.color= firstcolor;
            Debug.Log("YEP I WORK");
            // this.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y  - -1, gameObject.transform.position.z);
        }

        
      
        if (Input.GetKeyDown (keytopress) && !active )
            
        {
            plantspawn.GetComponent<PlantSpawn>().spawnPlants[plantNumber] = true;
            //YOU NEED TO ADD FMODUnity BECAUSE IN StudioEventEmitter IT IS IN A NAME SPACE
            this.gameObject.GetComponent<FMODUnity.StudioEventEmitter>().enabled = true;

         //  gameObject.GetComponent<Renderer>().material.color = (Color.green);
            wait = wait - 0.5f;
            turndownActivate = false;
            thisbutton.color = Color.green;

            // active = true;
        }


        if (Input.GetKeyDown(keytopress) && wait <= 0 && turndownActivate == false)
        {
            //    gameObject.GetComponent<Renderer>().material.color = (Color.black);


            turndowntimer = 1f;
            plantspawn.GetComponent<PlantSpawn>().spawnPlants[plantNumber] = false;
            ;            turndownActivate = true;
            thisbutton.color = Color.green;
            wait = 1f;
            //    this.gameObject.GetComponent<FMODUnity.StudioEventEmitter>().enabled = false;
        }
    }
}

