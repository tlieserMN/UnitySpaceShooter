using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackSpawner : MonoBehaviour
{
    public GameObject healthPrefab;
    public float maxSpawnTime = 30f;
    float spawnTime = 15;

    // Update is called once per frame
    void Update()
    {
        if(spawnTime <= 0)
        {
            spawnTime = Random.Range(15, maxSpawnTime);

            float yrange = Camera.main.orthographicSize;
            float xrange = Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height);

            float y = Random.Range(-yrange, yrange);
            float x = Random.Range(-xrange, xrange);

            Vector3 pos = new Vector3(x, y, 0);
            GameObject go = (GameObject)Instantiate(healthPrefab, pos, Quaternion.identity);
            go.name = "HealthPack";
        }
        spawnTime -= Time.deltaTime;
    }
}
