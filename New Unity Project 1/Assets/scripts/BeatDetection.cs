using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

public class BeatDetection : MonoBehaviour {

    public GameObject[] shadedObj;
    Color colour = new Color(0, 0, 1, 1 );
    float beat = 0;

    FMOD.Studio.EventInstance[][] musicInstances = new FMOD.Studio.EventInstance[64][];

    FMOD.DSP dsp;
    int WindowSize = 1024;

    void Start() {
        shadedObj = GameObject.FindGameObjectsWithTag("Plant");
        
        //musicInstance = FMODUnity.RuntimeManager.CreateInstance("event:/f");

        // Create Spectrum
        //FMODUnity.RuntimeManager.LowlevelSystem.createDSPByType(FMOD.DSP_TYPE.FFT, out dsp);
        //dsp.setParameterInt((int)FMOD.DSP_FFT.WINDOWTYPE, (int)FMOD.DSP_FFT_WINDOW.HANNING);
        //dsp.setParameterInt((int)FMOD.DSP_FFT.WINDOWSIZE, WindowSize * 2);

        //FMOD.ChannelGroup channelGroup;
        //FMODUnity.RuntimeManager.LowlevelSystem.getMasterChannelGroup(out channelGroup);
        
        //channelGroup.addDSP(FMOD.CHANNELCONTROL_DSP_INDEX.HEAD, dsp);
        //FMODUnity.StudioEventEmitter[] emitters = FindObjectsOfType<FMODUnity.StudioEventEmitter>();
        //for (int ev = 0; ev < emitters.Length; ++ev) {
        //    FMODUnity.RuntimeManager.GetEventDescription(emitters[ev].Event).getInstanceList(out musicInstances[ev]);
        //}

    }

    void Update() {

        shadedObj = GameObject.FindGameObjectsWithTag("Plant");
        //float[][] spectrum = GetSpectrumData();
        //try
        //    {
        //    for (int i = 0; i < spectrum[0].Length; ++i) {
        //        Debug.DrawLine(new Vector3(transform.position.x + i, transform.position.y, transform.position.z), new Vector3(transform.position.x + i, transform.position.y + spectrum[0][i], transform.position.z));
        //    }
        //    float[] dSpectrum = {0, 0, 0, 0, 0 };
        //        for (int i = 0; i <= 4; ++i) {
        //            if (spectrum[0][i * 200] > 0.001f)
        //                dSpectrum[i] = spectrum[0][i * 200];

        //        }
                
        //    Debug.Log(string.Format("Spectrum: {0} {1} {2} {3} {4}", dSpectrum[0], dSpectrum[1], dSpectrum[2], dSpectrum[3], dSpectrum[4]));
        //    //if (dSpectrum[1] > 0.01f)
        //        //Debug.Log("Done a beat");
        //}
        //catch (System.Exception e) {
        //   // Debug.Log(e);
        //}

        // Set and pass shader values
        beat += Time.deltaTime * 3;
        if (beat > 3) {
            beat = 0;
            colour[0] = UnityEngine.Random.Range(0f, 1f);
            colour[1] = UnityEngine.Random.Range(0f, 1f);
            colour[2] = UnityEngine.Random.Range(0f, 1f);
            colour[3] = 1;
            //Debug.Log(String.Format("R: {0}, G: {1}, B: {2}, A: {3}", colour[0], colour[1], colour[2], colour[3]));
        }
        foreach (GameObject plant in shadedObj) {
            foreach (Material mat in plant.GetComponent<Renderer>().materials) {
                    mat.SetFloat("_Music", beat);
                    mat.SetColor("_Color", colour);
            }
        }
    }

    //float[][] GetSpectrumData() {
    //    IntPtr unmanagedData;
    //    uint length;
    //    dsp.getParameterData((int)FMOD.DSP_FFT.SPECTRUMDATA, out unmanagedData, out length);
    //    FMOD.DSP_PARAMETER_FFT fftData = (FMOD.DSP_PARAMETER_FFT)Marshal.PtrToStructure(unmanagedData, typeof(FMOD.DSP_PARAMETER_FFT));
    //    float[][] spectrum = fftData.spectrum;
    //    return spectrum;

    //    // Drawing the Spectrum - Not important - Useful to visualize values
    //    /*
    //    if (fftData.numchannels > 0) {
    //        LineRenderer lineRenderer;
    //        float Width = 10;
    //        float Height = 0.1f;

    //        Vector3 pos = Vector3.zero;
    //        pos.x = Width * -0.5f;

    //        for (int i = 0; i < WindowSize; ++i) {
    //            pos.x += (Width / WindowSize);
    //            float level = Mathf.Clamp(Mathf.Log10(spectrum[0][i]) * 20, -80, 0);
    //            pos.y = (80 + level) * Height;

    //            lineRenderer.SetPosition(i, pos);
    //        }
    //    }
    //    */
    //}

}
