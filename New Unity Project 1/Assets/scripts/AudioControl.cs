using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;


public class AudioControl : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1) )
        {
            //YOU NEED TO ADD FMODUnity BECAUSE IN StudioEventEmitter IT IS IN A NAME SPACE
            this.gameObject.GetComponent<FMODUnity.StudioEventEmitter>().enabled = true;

            gameObject.GetComponent<Renderer>().material.color = (Color.green);
        }


    }
}
