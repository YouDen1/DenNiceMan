using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public int damage;
    public int time;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Enemy")
        {
           collision.GetComponent<EnemyController>().TakeDamage(damage);
        }

        if (collision.name == "Player")
        {
            collision.GetComponent<PlayerConroller>().TakeDamage(damage);
        }
    }

    private void Update()
    {
        Destroy(gameObject, time);
    }
}
