using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArrowSpawnScript : MonoBehaviour
{
    public LookAtMouse lookAtMouse;
    public GameObject arrow;
    public InputActionReference shoot;

    private void Update()
    {
        if (shoot.action.WasPressedThisFrame())
        {
            Instantiate(arrow, transform.position, lookAtMouse.GetCurrentMouseRotation());
        }
    }
}
