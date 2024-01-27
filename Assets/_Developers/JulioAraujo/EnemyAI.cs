using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private PeasantScriptableObject peasant;
    private SpriteRenderer enemySprite;
    private SpriteRenderer enemyRenderer;
    private Rigidbody2D rb;
    private float health;
    [SerializeField] private bool reachedCastle = false;
    [SerializeField] private bool isClicked = false;
    private int direction;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemySprite = GetComponent<SpriteRenderer>();
        enemyRenderer = GetComponent<SpriteRenderer>();
        enemySprite.sprite = peasant.infected;
        health = peasant.maxHealth;
        if (peasant.spawnLeft)
        {
            direction = 1;
        }
        else
        {
            direction = -1;
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(health);
        transform.position += direction*Vector3.right * Time.deltaTime * peasant.walkSpeed;


        if (Input.GetMouseButtonDown(0))
        {
            isClicked = true;
            health -= peasant.damageTaken;
        }
        else
        {
            isClicked = false;
        }

        if(health <= 0f)
        {
            enemySprite.sprite = peasant.cured;
        }

        if (isClicked)
        {
            rb.gravityScale = 0f;
            rb.AddForce(Vector2.up * peasant.floatSpeed);
            //transform.position += Vector3.up * Time.deltaTime * floatSpeed;
        }
        else
        {
            rb.gravityScale = 1f;
        }

        if(isClicked && !enemyRenderer.isVisible)
        {
            Debug.Log("Im dead bro");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Castle")
        {
            reachedCastle = true;
        }
    }
}
