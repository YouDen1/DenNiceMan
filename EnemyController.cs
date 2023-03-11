using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody2D physic;

    private Transform player;

    public float speed;
    public float agroDistance;
    public int health;
    public float damage;
    private ScoreManager sm;

    public GameObject effect;
    public int timeEffect;

    public HealthBar healthBar;

    void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        physic = GetComponent<Rigidbody2D>();
        physic.velocity = transform.right * speed;

        sm = FindObjectOfType<ScoreManager>();

        healthBar.SetHealth(health);
        healthBar.maxHealth = health;
    }

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < agroDistance)
        {
            StartHunting();
        }
        else
        {
            StopHunting();
        }
    }

    void StartHunting()
    {
        if (player.position.x < transform.position.x)
        {
            physic.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector2(0.3f, 0.3f);
        }
        else if (player.position.x > transform.position.x)
        {
            physic.velocity = new Vector2(+speed, 0);
            transform.localScale = new Vector2(-0.3f, 0.3f);
        }
    }

    void StopHunting()
    {
        physic.velocity = new Vector2(0, 0);
    }

    public void TakeDamage(int damage)
    {
        healthBar.SetHealth(health);

        health -= damage;

        if (health <= 0f)
        {
            Die();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(effect, transform.position, Quaternion.identity);

        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

        if (other.name == "Player")
        {
            other.GetComponent<PlayerConroller>().TakeDamage(damage);
        }
    }
    void Effect()
    {
        Instantiate(effect, transform.position, Quaternion.identity);
        Destroy(effect, timeEffect);
    }

    private void Die()
    {
        sm.Kill();
        Destroy(gameObject);
    }
}
