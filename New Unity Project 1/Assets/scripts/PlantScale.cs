using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScale : MonoBehaviour {

    public float ThisScale;
    public float min;
    public float max;

	// Use this for initialization
	void Start () {
        ThisScale = Random.Range(min, max);
        transform.localScale += new Vector3(ThisScale, ThisScale, ThisScale);
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
