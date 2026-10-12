using System;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float moveSpeed;
    public GameObject player; 
    public Rigidbody2D rb;
    private int followx;
    private int followy;

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (transform.tag)
        {
            case "TopDown":
                rb.gravityScale = 0;
                moveSpeed = 7.5f;
                Vector3 velocity = new Vector3((player.transform.position.x - transform.position.x), (player.transform.position.y - transform.position.y), 0);
                velocity = velocity.normalized * moveSpeed * Time.deltaTime;
                transform.position += velocity;
            break;
            
            case "2D":
                rb.gravityScale = 10;
                moveSpeed = 2f;
                transform.position += new Vector3((player.transform.position.x - transform.position.x)* moveSpeed * Time.deltaTime, 0, 0);
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer != LayerMask.NameToLayer("Ground"))
        {
            //Bei Schaden soll der Player nach hinten geschubst werden
            HealthManger health = collision.gameObject.GetComponent<HealthManger>();
            health.ReduceHealth(5);
        }
    }
}
