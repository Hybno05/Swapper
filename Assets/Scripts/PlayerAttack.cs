using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public InputActionReference attackAction;
    public WeaponSwitch WeaponSwitch;
    
    private GameObject swordAttack;
    private GameObject bowAttack;
    private bool _isattacking;
    private char weapon;

    private float _timeToAttack = 0.1f;
    private float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        swordAttack = transform.GetChild(0).gameObject;
        bowAttack  =  transform.GetChild(1).GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
        

        if (attackAction.action.WasPressedThisFrame())
        {
            weapon = WeaponSwitch.GetCurrentWeapon();
            switch (weapon)
            {
                case 'L': //L für Longsword
                    SwordAttack();
                    break;
                case 'B': //B für Bow
                    BowAttack();
                    break;
                case 'S': //S für Shortsword und Shield
                    break;
                case 'P': //P für Polearm, als Lanze
                    break;
            }
        }

        if (_isattacking)
        {
            timer += Time.deltaTime;

            if (timer >= _timeToAttack)
            {
                timer = 0;
                _isattacking = false;
                swordAttack.SetActive(_isattacking);
            }
        }
    }
    

    private void SwordAttack()
    {
        _isattacking = true;
        swordAttack.SetActive(_isattacking);
    }

    private void BowAttack()
    {
        _isattacking = true;
        bowAttack.SetActive(_isattacking);
    }
}
