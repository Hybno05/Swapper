using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponSwitch : MonoBehaviour
{
    private GameObject Longsword;
    private GameObject Bow;
    
    public InputActionReference switchSword;
    public InputActionReference switchBow;
    public InputActionReference switchShield;
    public InputActionReference switchPole;
    private char weapon;


    private void Start()
    {
        Longsword = transform.GetChild(0).gameObject;
        Bow = transform.GetChild(1).gameObject;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public char GetCurrentWeapon()
    {
        return weapon;
    }

    // Update is called once per frame
    void Update()
    {
        if (switchSword.action.WasPressedThisFrame())
        {
            weapon = 'L';
            Longsword.SetActive(true);
            Bow.SetActive(false);
            Debug.Log("Sword Pressed");
        }
        if (switchBow.action.WasPressedThisFrame())
        {
            weapon = 'B';
            Bow.SetActive(true);
            Longsword.SetActive(false);
            Debug.Log("Bow Pressed");
        }
        if (switchShield.action.WasPressedThisFrame())
        {
            weapon = 'S';
            Debug.Log("Shield Pressed");
        }
        if (switchPole.action.WasPressedThisFrame())
        {
            weapon = 'P';
            Debug.Log("Polearm Pressed");
        }
    }
}
