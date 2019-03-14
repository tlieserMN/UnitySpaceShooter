using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    float spawnRate = 5f;
    float nextEnemy = 1f;

    // Update is called once per frame
    void Update()
    {
        nextEnemy -= Time.deltaTime;
        if(nextEnemy <= 0)
        {
            nextEnemy = spawnRate;

            float yrange = Camera.main.orthographicSize;
            float xrange = Camera.main.orthographicSize * ((float)Screen.width / (float)Screen.height);

            float y = Random.Range(-yrange, yrange);
            float x = Random.Range(-xrange, xrange);

            GameObject player = GameObject.Find("PlayerShip");

            // always spawn away from player
            if(player != null)
            {
                if (player.transform.position.x - x < PlayerMovement.shipBoundaryRadius * 3)
                    x += PlayerMovement.shipBoundaryRadius * 3;
                if (player.transform.position.y - y < PlayerMovement.shipBoundaryRadius * 3)
                    y += PlayerMovement.shipBoundaryRadius * 3;
            }

            Vector3 pos = new Vector3(x, y, 0);
            GameObject go = (GameObject)Instantiate(enemyPrefab, pos, Quaternion.identity);
            go.name = "EnemyShip";
        }
    }
}
