using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD.Studio;
using UnityEngine.UI;
using System.Runtime.InteropServices;







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
    public Color randomcolor;
    public Image thisbutton;
    public Color firstColor;

    // DSP
    FMOD.Studio.EventInstance[] ev;
    FMOD.DSP dsp;
    int WindowSize = 1024;

    // Use this for initialization
    void Start()
    {
       
        wait = 1f;
        // gameObject.GetComponent<Renderer>().material.color = (Color.black);

        emitter = this.gameObject.GetComponent<FMODUnity.StudioEventEmitter>();
        randomcolor = (new Color(Random.value, Random.value, Random.value, 1));
        thisbutton = gameObject.GetComponent<Image>();
        firstColor = thisbutton.color;
        keytopress = gameObject.name;

        // DSP Initialization
        FMODUnity.RuntimeManager.LowlevelSystem.createDSPByType(FMOD.DSP_TYPE.FFT, out dsp);
        dsp.setParameterInt((int)FMOD.DSP_FFT.WINDOWTYPE, (int)FMOD.DSP_FFT_WINDOW.HANNING);
        dsp.setParameterInt((int)FMOD.DSP_FFT.WINDOWSIZE, WindowSize * 2);
        FMOD.ChannelGroup channelGroup;
        // Change to uniqe channel groups
        FMODUnity.RuntimeManager.LowlevelSystem.getMasterChannelGroup(out channelGroup);

        channelGroup.addDSP(FMOD.CHANNELCONTROL_DSP_INDEX.HEAD, dsp);
        FMODUnity.RuntimeManager.GetEventDescription(emitter.Event).getInstanceList(out ev);
    }

    // Update is called once per frame
    void Update()
    {
        emitter.SetParameter("volume", turndowntimer);

       

        if (turndownActivate == true && turndowntimer >=0.000000001)
        {
            turndowntimer = turndowntimer - Time.deltaTime / 2;
            thisbutton.color = firstColor;
       //     this.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - +1, gameObject.transform.position.z);
        }

        if (turndownActivate == false && turndowntimer <= 1 && emitter.enabled == true)
        {
            turndowntimer = turndowntimer + Time.deltaTime / 2;
            thisbutton.color= randomcolor;

       //     this.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y  - -1, gameObject.transform.position.z);
        }

        if (active)
        {
            



        }
      
        if (Input.GetKeyDown (keytopress) && !active )
            
        {
            plantspawn.GetComponent<PlantSpawn>().spawnPlants[plantNumber] = true;
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

            plantspawn.GetComponent<PlantSpawn>().spawnPlants[plantNumber] = false;
            ;            turndownActivate = true;
            //    this.gameObject.GetComponent<FMODUnity.StudioEventEmitter>().enabled = false;
        }

        // DSP Stuff
        float[][] spectrum = GetSpectrumData();
        try {
            for (int i = 0; i < spectrum[0].Length; ++i) {
                Debug.DrawLine(new Vector3(transform.position.x + i, transform.position.y, transform.position.z), new Vector3(transform.position.x + i, transform.position.y + spectrum[0][i], transform.position.z));
            }
            float[] dSpectrum = {0, 0, 0, 0, 0};
            for (int i = 0; i <= 4; ++i) {
                if (spectrum[0][i * 200] > 0.001f)
                    dSpectrum[i] = spectrum[0][i * 200];
            }
            Debug.Log(string.Format("Spectrum {5}: {0} {1} {2} {3} {4}", dSpectrum[0], dSpectrum[1], dSpectrum[2], dSpectrum[3], dSpectrum[4], this.name));
        }
        catch (System.Exception e) {
            // Debug.Log(e);
        }
            

    }

    float[][] GetSpectrumData() {
        System.IntPtr unmanagedData;
        uint length;
        dsp.getParameterData((int)FMOD.DSP_FFT.SPECTRUMDATA, out unmanagedData, out length);
        FMOD.DSP_PARAMETER_FFT fftData = (FMOD.DSP_PARAMETER_FFT)Marshal.PtrToStructure(unmanagedData, typeof(FMOD.DSP_PARAMETER_FFT));
        return fftData.spectrum;
    }
}

