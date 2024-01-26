using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private bool spawnLeft;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float floatSpeed;
    [SerializeField] private float health;
    [SerializeField] private bool reachedCastle = false;
    private int direction;



    // Start is called before the first frame update
    void Start()
    {
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


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Castle")
        {
            reachedCastle = true;
        }
    }
}
