using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantDeath : MonoBehaviour {

    public float Life = 3;

        // Update is called once per frame
        void Update () {

        Life -= Time.deltaTime;

        if (Life <= 0)
        {
            Destroy(this.gameObject);
        }
	}
}
