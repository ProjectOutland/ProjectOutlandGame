using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawn : MonoBehaviour
{
    public static PlantSpawn plantspawn;


    public Transform[] Plants;
    public Transform randomLocation;
    public float minDistance = 4;
    public float spawnRange = 20;
    public int spawnAmount = 7;
    public float SpawnInterval = 3;

    public bool[] spawnPlants;

    float spawnInterval = 2;
    Collider myCollider;
    Vector3 pos;

    // Use this for initialization
    void Start()
    {
        myCollider = this.gameObject.GetComponent<SphereCollider>();
        plantspawn = this;
    }

    public bool checkIfPosEmpty(Vector3 targetPos)
    {
        GameObject[] allPlantThings = GameObject.FindGameObjectsWithTag("Plant");
        foreach (GameObject current in allPlantThings)
        {
            if (current.GetComponent<CapsuleCollider>().bounds.Contains(targetPos))
                return false;
            if (myCollider.bounds.Contains(targetPos))
                return false;
        }
        return true;
    }

    // Update is called once per frame
    void Update()
    {
        spawnInterval -= Time.deltaTime;

        if (spawnInterval <= 0)
        {
            spawnInterval = SpawnInterval;

            if (spawnPlants[0] == true)
            {
                for (int i = 0; i < spawnAmount; i++)
                {
                    randomLocation.position = new Vector3(Random.Range(this.gameObject.transform.position.x - spawnRange, this.gameObject.transform.position.x + spawnRange), 0, (Random.Range(this.gameObject.transform.position.z - spawnRange, this.gameObject.transform.position.z + spawnRange)));

                    pos.y = Terrain.activeTerrain.SampleHeight(randomLocation.position) + Terrain.activeTerrain.transform.position.y;
                    if (checkIfPosEmpty(randomLocation.position))
                    {
                        Instantiate(Plants[0].gameObject, new Vector3(randomLocation.position.x,pos.y,randomLocation.position.z), Quaternion.identity);
                    }
                }
            }
            if (spawnPlants[1] == true)
            {
                for (int i = 0; i < spawnAmount; i++)
                {
                    randomLocation.position = new Vector3(Random.Range(this.gameObject.transform.position.x - spawnRange, this.gameObject.transform.position.x + spawnRange), 0, (Random.Range(this.gameObject.transform.position.z - spawnRange, this.gameObject.transform.position.z + spawnRange)));

                    pos.y = Terrain.activeTerrain.SampleHeight(randomLocation.position) + Terrain.activeTerrain.transform.position.y;
                    if (checkIfPosEmpty(randomLocation.position))
                    {
                        Instantiate(Plants[1].gameObject, new Vector3(randomLocation.position.x, pos.y, randomLocation.position.z), Quaternion.identity);
                    }
                }
            }
            if (spawnPlants[2] == true)
            {
                for (int i = 0; i < spawnAmount; i++)
                {
                    randomLocation.position = new Vector3(Random.Range(this.gameObject.transform.position.x - spawnRange, this.gameObject.transform.position.x + spawnRange), 0, (Random.Range(this.gameObject.transform.position.z - spawnRange, this.gameObject.transform.position.z + spawnRange)));

                    pos.y = Terrain.activeTerrain.SampleHeight(randomLocation.position) + Terrain.activeTerrain.transform.position.y;
                    if (checkIfPosEmpty(randomLocation.position))
                    {
                        Instantiate(Plants[2].gameObject, new Vector3(randomLocation.position.x, pos.y, randomLocation.position.z), Quaternion.identity);
                    }
                }
            }
            if (spawnPlants[3] == true)
            {
                for (int i = 0; i < spawnAmount; i++)
                {
                    randomLocation.position = new Vector3(Random.Range(this.gameObject.transform.position.x - spawnRange, this.gameObject.transform.position.x + spawnRange), 0, (Random.Range(this.gameObject.transform.position.z - spawnRange, this.gameObject.transform.position.z + spawnRange)));

                    pos.y = Terrain.activeTerrain.SampleHeight(randomLocation.position) + Terrain.activeTerrain.transform.position.y;
                    if (checkIfPosEmpty(randomLocation.position))
                    {
                        Instantiate(Plants[3].gameObject, new Vector3(randomLocation.position.x, pos.y, randomLocation.position.z), Quaternion.identity);
                    }
                }
            }
            if (spawnPlants[4] == true)
            {
                for (int i = 0; i < spawnAmount; i++)
                {
                    randomLocation.position = new Vector3(Random.Range(this.gameObject.transform.position.x - spawnRange, this.gameObject.transform.position.x + spawnRange), 0, (Random.Range(this.gameObject.transform.position.z - spawnRange, this.gameObject.transform.position.z + spawnRange)));

                    pos.y = Terrain.activeTerrain.SampleHeight(randomLocation.position) + Terrain.activeTerrain.transform.position.y;
                    if (checkIfPosEmpty(randomLocation.position))
                    {
                        Instantiate(Plants[4].gameObject, new Vector3(randomLocation.position.x, pos.y, randomLocation.position.z), Quaternion.identity);
                    }
                }
            }
            if (spawnPlants[5] == true)
            {
                for (int i = 0; i < spawnAmount; i++)
                {
                    randomLocation.position = new Vector3(Random.Range(this.gameObject.transform.position.x - spawnRange, this.gameObject.transform.position.x + spawnRange), 0, (Random.Range(this.gameObject.transform.position.z - spawnRange, this.gameObject.transform.position.z + spawnRange)));

                    pos.y = Terrain.activeTerrain.SampleHeight(randomLocation.position) + Terrain.activeTerrain.transform.position.y;
                    if (checkIfPosEmpty(randomLocation.position))
                    {
                        Instantiate(Plants[5].gameObject, new Vector3(randomLocation.position.x, pos.y, randomLocation.position.z), Quaternion.identity);
                    }
                }
            }
            if (spawnPlants[6] == true)
            {
                for (int i = 0; i < spawnAmount; i++)
                {
                    randomLocation.position = new Vector3(Random.Range(this.gameObject.transform.position.x - spawnRange, this.gameObject.transform.position.x + spawnRange), 0, (Random.Range(this.gameObject.transform.position.z - spawnRange, this.gameObject.transform.position.z + spawnRange)));

                    pos.y = Terrain.activeTerrain.SampleHeight(randomLocation.position) + Terrain.activeTerrain.transform.position.y;
                    if (checkIfPosEmpty(randomLocation.position))
                    {
                        Instantiate(Plants[6].gameObject, new Vector3(randomLocation.position.x, pos.y, randomLocation.position.z), Quaternion.identity);
                    }
                }
            }
            if (spawnPlants[7] == true)
            {
                for (int i = 0; i < spawnAmount; i++)
                {
                    randomLocation.position = new Vector3(Random.Range(this.gameObject.transform.position.x - spawnRange, this.gameObject.transform.position.x + spawnRange), 0, (Random.Range(this.gameObject.transform.position.z - spawnRange, this.gameObject.transform.position.z + spawnRange)));

                    pos.y = Terrain.activeTerrain.SampleHeight(randomLocation.position) + Terrain.activeTerrain.transform.position.y;
                    if (checkIfPosEmpty(randomLocation.position))
                    {
                        Instantiate(Plants[7].gameObject, new Vector3(randomLocation.position.x, pos.y, randomLocation.position.z), Quaternion.identity);
                    }
                }
            }

            if (spawnPlants[8] == true) {
                for (int i = 0; i < spawnAmount; i++) {
                    randomLocation.position = new Vector3(Random.Range(this.gameObject.transform.position.x - spawnRange, this.gameObject.transform.position.x + spawnRange), 0, (Random.Range(this.gameObject.transform.position.z - spawnRange, this.gameObject.transform.position.z + spawnRange)));

                    pos.y = Terrain.activeTerrain.SampleHeight(randomLocation.position) + Terrain.activeTerrain.transform.position.y;
                    if (checkIfPosEmpty(randomLocation.position)) {
                        Instantiate(Plants[7].gameObject, new Vector3(randomLocation.position.x, pos.y, randomLocation.position.z), Quaternion.identity);
                    }
                }
            }

            if (spawnPlants[9] == true) {
                for (int i = 0; i < spawnAmount; i++) {
                    randomLocation.position = new Vector3(Random.Range(this.gameObject.transform.position.x - spawnRange, this.gameObject.transform.position.x + spawnRange), 0, (Random.Range(this.gameObject.transform.position.z - spawnRange, this.gameObject.transform.position.z + spawnRange)));

                    pos.y = Terrain.activeTerrain.SampleHeight(randomLocation.position) + Terrain.activeTerrain.transform.position.y;
                    if (checkIfPosEmpty(randomLocation.position)) {
                        Instantiate(Plants[7].gameObject, new Vector3(randomLocation.position.x, pos.y, randomLocation.position.z), Quaternion.identity);
                    }
                }
            }

            if (spawnPlants[10] == true) {
                for (int i = 0; i < spawnAmount; i++) {
                    randomLocation.position = new Vector3(Random.Range(this.gameObject.transform.position.x - spawnRange, this.gameObject.transform.position.x + spawnRange), 0, (Random.Range(this.gameObject.transform.position.z - spawnRange, this.gameObject.transform.position.z + spawnRange)));

                    pos.y = Terrain.activeTerrain.SampleHeight(randomLocation.position) + Terrain.activeTerrain.transform.position.y;
                    if (checkIfPosEmpty(randomLocation.position)) {
                        Instantiate(Plants[7].gameObject, new Vector3(randomLocation.position.x, pos.y, randomLocation.position.z), Quaternion.identity);
                    }
                }
            }
            return;
        }

    }
}