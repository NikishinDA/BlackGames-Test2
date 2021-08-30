using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject spawnObject;

    public float offsetMultiplier = 2f;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i<5; i++) SpawnCube(i);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SpawnCube(1);
        }
    }

    private void SpawnCube(float yOffset)
    {
        GameObject newCube = Instantiate(spawnObject, transform.position + 
            new Vector3(offsetMultiplier*(Random.value-0.5f),yOffset, offsetMultiplier*(Random.value-0.5f)), Quaternion.identity);
        if (Random.value < 0.5f)
        {
            newCube.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            newCube.tag = "Red";

        }
        else
        {
            newCube.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            newCube.tag = "Blue";
        }
    }
}
