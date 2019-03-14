using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletLocation;

    public float fireDelay = .5f;
    float cooldownTimer = 0;

    Transform player;

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            GameObject go = GameObject.Find("PlayerShip");

            if (go != null)
            {
                player = go.transform;
            }
        }

        cooldownTimer -= Time.deltaTime;

        if (cooldownTimer <= 0 && player != null)
        {
            cooldownTimer = fireDelay;

            Instantiate(bulletPrefab, bulletLocation.transform.position, transform.rotation);
        }
    }
}
