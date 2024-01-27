using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Renderer enemyRenderer;
    private Rigidbody2D rb;
    [SerializeField] private bool spawnLeft;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float floatSpeed;
    [SerializeField] private float health;
    [SerializeField] private bool reachedCastle = false;
    [SerializeField] private bool isClicked = false;
    private int direction;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyRenderer = GetComponent<Renderer>();
        if (spawnLeft)
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
        transform.position += direction*Vector3.right * Time.deltaTime * walkSpeed;



        if (isClicked)
        {
            rb.gravityScale = 0f;
            transform.position += Vector3.up * Time.deltaTime * floatSpeed;
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
