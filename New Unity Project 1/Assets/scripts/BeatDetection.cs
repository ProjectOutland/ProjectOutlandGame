using System.Collections;
using System.Collections.Generic;
using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class BeatDetection : MonoBehaviour {

    [StructLayout(LayoutKind.Sequential)]
    class TimelineInfo {
        public int currentMusicBar = 0;
        public FMOD.StringWrapper lastMarker = new FMOD.StringWrapper();
    }

    public int bar = 0;
    public float beat = 0;
    public GameObject shadedObj;
    Material mat;
    Color colour = new Color(0, 0, 1, 1 );

    TimelineInfo timelineInfo;
    GCHandle timelineHandle;

    FMOD.Studio.EVENT_CALLBACK beatCallback;
    FMOD.Studio.EventInstance musicInstance;

    void Start() {
        mat = shadedObj.GetComponent<Renderer>().materials[0];
        //Debug.Log(String.Format("R: {0}, G: {1}, B: {2}, A: {3}", colour[0], colour[1], colour[2], colour[3]));
        //timelineInfo = new TimelineInfo();

        //beatCallback = new FMOD.Studio.EVENT_CALLBACK(BeatEventCallback);
        //musicInstance = FMODUnity.RuntimeManager.CreateInstance("event:/music/music");
        //timelineHandle = GCHandle.Alloc(timelineInfo, GCHandleType.Pinned);
        //musicInstance.setUserData(GCHandle.ToIntPtr(timelineHandle));
        //musicInstance.setCallback(beatCallback, FMOD.Studio.EVENT_CALLBACK_TYPE.TIMELINE_BEAT | FMOD.Studio.EVENT_CALLBACK_TYPE.TIMELINE_MARKER);
        //musicInstance.start();
    }

    void Update() {
        //if (timelineInfo.currentMusicBar > bar) {
        //    bar = timelineInfo.currentMusicBar;
        //    Debug.Log(String.Format("Current Bar: {0}, Last Marker: {1}", timelineInfo.currentMusicBar, (string)timelineInfo.lastMarker));
        //}
        beat += Time.deltaTime * 3;
        if (beat > 3) {
            beat = 0;
            colour[0] = UnityEngine.Random.Range(0f, 1f);
            colour[1] = UnityEngine.Random.Range(0f, 1f);
            colour[2] = UnityEngine.Random.Range(0f, 1f);
            colour[3] = 1;
            //Debug.Log(String.Format("R: {0}, G: {1}, B: {2}, A: {3}", colour[0], colour[1], colour[2], colour[3]));
        }
        mat.SetFloat("_Music", beat - 1.0f);
        mat.SetColor("_Color", colour);
    }

    void OnDestroy() {
        //musicInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
        //musicInstance.release();
        //timelineHandle.Free();
    }

    void OnGUI() {
       // GUILayout.Box(String.Format("Current Bar = {0}, Last Marker = {1}", timelineInfo.currentMusicBar, (string)timelineInfo.lastMarker));
    }

    [AOT.MonoPInvokeCallback(typeof(FMOD.Studio.EVENT_CALLBACK))]
    static FMOD.RESULT BeatEventCallback(FMOD.Studio.EVENT_CALLBACK_TYPE type, IntPtr instancePtr, IntPtr parameterPtr) {
        FMOD.Studio.EventInstance instance = new FMOD.Studio.EventInstance(instancePtr);

        IntPtr timelineInfoPtr;
        instance.getUserData(out timelineInfoPtr);

        GCHandle timelineHandle = GCHandle.FromIntPtr(timelineInfoPtr);
        TimelineInfo timelineInfo = (TimelineInfo)timelineHandle.Target;

        switch(type) {
            case FMOD.Studio.EVENT_CALLBACK_TYPE.TIMELINE_BEAT: {
                    var parameter = (FMOD.Studio.TIMELINE_BEAT_PROPERTIES)Marshal.PtrToStructure(parameterPtr, typeof(FMOD.Studio.TIMELINE_BEAT_PROPERTIES));
                    timelineInfo.currentMusicBar = parameter.bar;
                }
                break;
            case FMOD.Studio.EVENT_CALLBACK_TYPE.TIMELINE_MARKER: {
                    var parameter = (FMOD.Studio.TIMELINE_MARKER_PROPERTIES)Marshal.PtrToStructure(parameterPtr, typeof(FMOD.Studio.TIMELINE_MARKER_PROPERTIES));
                    timelineInfo.lastMarker = parameter.name;
                }
                break;
        }
        return FMOD.RESULT.OK;
    }

}
