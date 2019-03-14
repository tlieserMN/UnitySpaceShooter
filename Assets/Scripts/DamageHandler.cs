using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour
{
    public int health = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!(collision.gameObject.tag == "Bullet" && gameObject.tag == "Bullet") && 
            !(collision.gameObject.name == "HealthPack" && gameObject.name == "PlayerShip") && 
            !(gameObject.name == "HealthPack" && 
                (collision.gameObject.tag == "Bullet" || collision.gameObject.name == "EnemyShip")) &&
                !(gameObject.name == "EnemyShip" && collision.gameObject.name == "HealthPack")
            )
        {
            // two bullets don't hit eachother
            health--;
        }
        if (collision.gameObject.name == "HealthPack" && gameObject.name == "PlayerShip")
        {
            health++;
        }
    }

    void Update()
    {
        if(gameObject.name == "PlayerShip")
        {
            HealthHandler.health = health;
        }
        if (health <= 0)
        {
            if(gameObject.name == "EnemyShip")
            {
                ScoreHandler.score += 1;
            }
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
