using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject spawnObject;//что спаунить

    public float offsetMultiplier = 2f;//множетель разброса
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i<5; i++) SpawnCube(i);//заспаунить пять кубов
    }

    private void SpawnCube(float yOffset)
    {
        GameObject newCube = Instantiate(spawnObject, transform.position + 
            new Vector3(offsetMultiplier*(Random.value-0.5f),yOffset, offsetMultiplier*(Random.value-0.5f)), Quaternion.identity);//заспаунить куб в случайной точке (x,z) с заданным y
        if (Random.value < 0.5f)//случайный выбор цвета 
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
