using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BowScript : MonoBehaviour
{
    public int damage = 15;
    private Vector2 targetPos;

    private void Start()
    {
        targetPos =  Mouse.current.position.ReadValue();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, 10 * Time.deltaTime);
    }

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
