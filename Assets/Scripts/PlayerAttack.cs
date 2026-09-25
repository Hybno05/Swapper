using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public InputActionReference attackAction;
    private GameObject attackArea;
    private bool _isattacking;

    private float _timeToAttack = 1f;

    private float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (attackAction.action.WasPressedThisFrame())
        {
            Attack();
        }

        if (_isattacking)
        {
            timer += Time.deltaTime;

            if (timer >= _timeToAttack)
            {
                timer = 0;
                _isattacking = false;
                attackArea.SetActive(_isattacking);
            }
        }
    }

    private void Attack()
    {
        _isattacking = true;
        attackArea.SetActive(_isattacking);
    }
}
