using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

class DetectionObj {
    public string name;
    public FMOD.DSP dsp;
    public string audioPath;
    public int WindowSize = 1024;
    public FMOD.Sound sound;
    public FMOD.Channel channel;
    public FMOD.ChannelGroup channelGroup;
    public float[][] spectrum;
    public float minBeat;

    public DetectionObj(string name, string path) {
        audioPath = path;
        name = name;
        // DSP Initialization
        FMODUnity.RuntimeManager.LowlevelSystem.createDSPByType(FMOD.DSP_TYPE.FFT, out dsp);
        dsp.setParameterInt((int)FMOD.DSP_FFT.WINDOWTYPE, (int)FMOD.DSP_FFT_WINDOW.HANNING);
        dsp.setParameterInt((int)FMOD.DSP_FFT.WINDOWSIZE, WindowSize * 2);
        FMOD.RESULT result;
        result = FMODUnity.RuntimeManager.LowlevelSystem.createChannelGroup(name, out channelGroup);
        // Create Audio Sound Stream to analyse
        result = FMODUnity.RuntimeManager.LowlevelSystem.createStream("tesssttt/Assets/" + path, FMOD.MODE.CREATESTREAM, out sound);
        result = FMODUnity.RuntimeManager.LowlevelSystem.playSound(sound, channelGroup, false, out channel);
        channel.setVolume(0.0001f);
        // Create DSP
        result = channelGroup.addDSP(FMOD.CHANNELCONTROL_DSP_INDEX.HEAD, dsp);
    }

    public float[][] GetSpectrum() {
        System.IntPtr unmanagedData;
        uint length;
        dsp.getParameterData((int)FMOD.DSP_FFT.SPECTRUMDATA, out unmanagedData, out length);
        FMOD.DSP_PARAMETER_FFT fftData = (FMOD.DSP_PARAMETER_FFT)Marshal.PtrToStructure(unmanagedData, typeof(FMOD.DSP_PARAMETER_FFT));
        return fftData.spectrum;
    }
}

public class BeatDetection : MonoBehaviour {

    public GameObject[] shadedObj;
    Color colour = new Color(0, 0, 1, 1 );
    public Color[] colours;
    float beat = 0;

    // Audio Variables - Left as arrays in case further functionality is required
    public string[] AudioPaths;
    public string[] audioNames;
    public float[] minBeats;
    List<DetectionObj> _DetectionObj = new List<DetectionObj>();

    float pulse1 = 0;

    void Start() {
        shadedObj = GameObject.FindGameObjectsWithTag("Plant");

        // DSP Initialization
        for (int index = 0; index < AudioPaths.Length; ++index) {
            DetectionObj obj = new DetectionObj(audioNames[index], AudioPaths[index]);
            obj.minBeat = minBeats[index];
            _DetectionObj.Add(obj);
        }
    }

    void Update() {

        shadedObj = GameObject.FindGameObjectsWithTag("Plant");
        try {
        foreach (DetectionObj obj in _DetectionObj) {
            obj.spectrum = obj.GetSpectrum();
            for (int i = 0; i < obj.spectrum[0].Length; ++i)
                obj.spectrum[0][i] *= 10000000;
            if (obj.audioPath == AudioPaths[2] && obj.spectrum[0][50] > obj.minBeat)
                Debug.Log(string.Format("Spectrum {0}: {1}, {2}, {3}, {4}, {5}", obj.audioPath, obj.spectrum[0][0], obj.spectrum[0][50], obj.spectrum[0][100], obj.spectrum[0][150], obj.spectrum[0][200]));
        }
        } catch (System.Exception e) { }

        for (int i = 0; i < _DetectionObj.Count; ++i) {
            bool isPlaying;
            _DetectionObj[i].channel.isPlaying(out isPlaying);
            if (!isPlaying) {
                _DetectionObj[i] = new DetectionObj(_DetectionObj[i].name, _DetectionObj[i].audioPath);
                _DetectionObj[i].minBeat = minBeats[i];
            }
        }

        // Set and pass shader values
        if (pulse1 >= 0)
            pulse1 += Time.deltaTime * 2;
        else if(pulse1 > 3)
            pulse1 = -1;

        int rnd = UnityEngine.Random.Range(0, colours.Length);
        Color colour = colours[rnd];
        colour = new Color(colour.r, colour.g, colour.b, 1);
        foreach (GameObject plant in shadedObj) {
            foreach (Material mat in plant.GetComponent<Renderer>().materials) {
                try {
                if (_DetectionObj[0].spectrum[0][50] > _DetectionObj[0].minBeat) {
                    mat.SetColor("_Color", colour);
                    pulse1 = 0;
                    Debug.Log(_DetectionObj[0].spectrum[0][50] + " > " + _DetectionObj[0].minBeat);
                }
                } catch (System.Exception e) { }
                if (pulse1 > 0)
                    mat.SetFloat("_Pulse1", pulse1);
                else
                    mat.SetFloat("_Pulse1", 0);
            }
        }
    }
}
