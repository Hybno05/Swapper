using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    public InputActionReference attackAction;
    private GameObject attackArea = default;
    private bool _isattacking = false;

    private float _timeToAttack = 3f;

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
        gameObject.SetActive(_isattacking);
    }
}
