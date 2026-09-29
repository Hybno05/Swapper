using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackAreaScript : MonoBehaviour
{
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.transform.name+"Wurde getroffen!");
    }

    private void Update()
    {
        Vector3 mousePos =  (Vector2)_camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        float angleRad = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x);
        float angleDeg = (180 / Mathf.PI) * angleRad;
        transform.rotation = Quaternion.Euler(0, 0, angleDeg);
        Debug.DrawLine(transform.position, mousePos, Color.red, Time.deltaTime);
    }
}
