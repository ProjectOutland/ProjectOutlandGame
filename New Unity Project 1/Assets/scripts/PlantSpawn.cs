using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawn : MonoBehaviour {

    public Transform[] Plants;
    public Transform randomLocation;
    public float minDistance = 4;
    public float spawnRange = 20;

    public bool[] spawnPlants;

    [SerializeField]
    float spawnInterval = 2;
    Collider myCollider;

    // Use this for initialization
    void Start () {
        myCollider = this.gameObject.GetComponent<SphereCollider>();
	}

    public bool checkIfPosEmpty(Vector3 targetPos)
    {
        GameObject[] allPlantThings = GameObject.FindGameObjectsWithTag("Plant");
        foreach (GameObject current in allPlantThings)
        {
            if (current.GetComponent<SphereCollider>().bounds.Contains(targetPos))
                return false;
            if (this.gameObject.GetComponent<SphereCollider>().bounds.Contains(targetPos))
            {
                Debug.Log("near player");
                return false;
            }
        }
        return true;
    } 

    // Update is called once per frame
    void Update () {
        spawnInterval -= Time.deltaTime;

        if (spawnInterval <= 0)
        {
            spawnInterval = 0.01f;
     
            if (spawnPlants[0] == true)
            {
                randomLocation.position = new Vector3(Random.Range(this.gameObject.transform.position.x -spawnRange, this.gameObject.transform.position.x + spawnRange), 19, (Random.Range(this.gameObject.transform.position.z - spawnRange, this.gameObject.transform.position.z + spawnRange)));
                if (checkIfPosEmpty(randomLocation.position))
                {
                    Instantiate(Plants[0].gameObject, randomLocation.position, new Quaternion(90,0,0,0));
                }
            }
            if (spawnPlants[1] == true)
            {
                randomLocation.position = new Vector3(Random.Range(this.gameObject.transform.position.x - spawnRange, this.gameObject.transform.position.x + spawnRange), 19, (Random.Range(this.gameObject.transform.position.z - spawnRange, this.gameObject.transform.position.z + spawnRange)));
                if (checkIfPosEmpty(randomLocation.position))
                {
                    Instantiate(Plants[1].gameObject, randomLocation.position, new Quaternion(90, 0, 0, 0));
                }
            }
            if (spawnPlants[2] == true)
            {
                randomLocation.position = new Vector3(Random.Range(this.gameObject.transform.position.x - spawnRange, this.gameObject.transform.position.x + spawnRange), 19, (Random.Range(this.gameObject.transform.position.z - spawnRange, this.gameObject.transform.position.z + spawnRange)));
                if (checkIfPosEmpty(randomLocation.position))
                {
                    Instantiate(Plants[2].gameObject, randomLocation.position, new Quaternion(90, 0, 0, 0));
                }
            }
            if (spawnPlants[3] == true)
            {
                randomLocation.position = new Vector3(Random.Range(this.gameObject.transform.position.x - spawnRange, this.gameObject.transform.position.x + spawnRange), 19, (Random.Range(this.gameObject.transform.position.z - spawnRange, this.gameObject.transform.position.z + spawnRange)));
                if (checkIfPosEmpty(randomLocation.position))
                {
                    Instantiate(Plants[3].gameObject, randomLocation.position, new Quaternion(90, 0, 0, 0));
                }
            }

            else return;
        }
	}
}
