using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class LookAtMouse : MonoBehaviour
{
    private Camera _camera;
    public Vector3 mousePos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _camera = Camera.main;
    }


    private void Update()
    {
        transform.rotation = GetCurrentMouseRotation();
        Debug.DrawLine(transform.position, mousePos, Color.red, Time.deltaTime);
    }

    
    public Quaternion GetCurrentMouseRotation()
    {
        mousePos =  (Vector2)_camera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        float angleRad = Mathf.Atan2(mousePos.y - transform.position.y, mousePos.x - transform.position.x);
        float angleDeg = ((180 / Mathf.PI) * angleRad);
        return Quaternion.Euler(0, 0, angleDeg);
    }
}
