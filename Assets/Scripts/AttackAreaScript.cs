using System;
using UnityEngine;

public class AttackAreaScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Wurde getroffen!");
    }
}
