using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxColor : MonoBehaviour
{

    // used to track the index of the background to display
    public int cycleIndex = 0;
    Color[] skyColors = new Color[5];
    float curRot = 0;
    float timer = 3;
    void Start()
    {
        // init the sky colors array
        skyColors[0] = new Color(110, 54, 103);    
        skyColors[1] = new Color(87, 188, 144);    
        skyColors[2] = new Color(3, 117, 180);    
        skyColors[3] = new Color(0, 255, 255);    
        skyColors[4] = new Color(0, 255, 0);
        RenderSettings.skybox.SetColor("_Tint", skyColors[cycleIndex]);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            // cycle the camera background color
            cycleIndex++;
            cycleIndex %= skyColors.Length;
            RenderSettings.skybox.SetColor("_Tint", skyColors[cycleIndex]);

            timer = 3;
        }
        curRot += 6 * Time.deltaTime;
        curRot %= 360;
        RenderSettings.skybox.SetFloat("_Rotation", curRot);
    }
}


