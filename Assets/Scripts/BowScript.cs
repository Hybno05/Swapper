using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class BowScript : MonoBehaviour
{
    public int damage = 15;
    private Vector2 targetPos;
    private Camera  _camera;
    public LayerMask destroyLayer;

    private void Start()
    {
        _camera = Camera.main;
        targetPos =  _camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, 10  * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer != destroyLayer & collision.gameObject.transform.name != "Player")
        {
            HealthManger health = collision.gameObject.GetComponent<HealthManger>();
            if (health != null)
            {
                health.ReduceHealth(damage);
                collision.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            }
            
        }
        
        
        if(collision.gameObject.layer == destroyLayer){
            Destroy(this.gameObject);
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
