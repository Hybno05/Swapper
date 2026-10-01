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
                transform.position += new Vector3((player.transform.position.x - transform.position.x) * moveSpeed * Time.deltaTime, (player.transform.position.y - transform.position.y) * moveSpeed * Time.deltaTime, 0);
            break;
            
            case "2D":
                rb.gravityScale = 10;
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
