using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerConroller : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float moveInput;
    public float health;

    public Joystick joystick;

    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public GameObject sound;

    [HideInInspector] public int _money;
    [HideInInspector] public SpriteRenderer _spriteRenderer;

    private Rigidbody2D rb;
    public bool facingRight = true;

    public int language;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        if(health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < Mathf.RoundToInt(health))
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if(i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
            if(health < 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }

        moveInput = joystick.Horizontal;
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == false && moveInput < 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput > 0)
        {
            Flip();
        }
    }

    private void Update()
    {
        float verticalMove = joystick.Vertical;

        if (verticalMove >= .5f && Mathf.Abs(rb.velocity.y) < 0.05f)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            Instantiate(sound, transform.position, Quaternion.identity);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        SceneManager.LoadScene(0);
    }

    private void Start()
    {
        language = PlayerPrefs.GetInt("language", language);

        rb = GetComponent<Rigidbody2D>();
    }
}
