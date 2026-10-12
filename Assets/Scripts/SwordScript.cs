using System;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public int damage = 10;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.GetMask("Ground"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }

        
        HealthManger health = collision.gameObject.GetComponent<HealthManger>();
        if (health != null)
        {
            health.ReduceHealth(damage);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer != LayerMask.GetMask("Ground"))
        {
            collision.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
