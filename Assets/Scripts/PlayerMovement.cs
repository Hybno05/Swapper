using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    private Vector2 _movement;
    public Rigidbody2D rb;
    public InputActionReference moveAction;
    public InputActionReference jumpAction;
    public float moveSpeed;
    public float jumpSpeed;
    public LayerMask layerMask;
    public float maxRange = 1f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _movement = moveAction.action.ReadValue<Vector2>();
        switch (transform.tag)
        {
            case "TopDown":
                rb.linearVelocity = new Vector2(0,0);
                rb.gravityScale = 0;
                gameObject.transform.position += new Vector3(_movement.x * moveSpeed * Time.deltaTime, _movement.y * moveSpeed * Time.deltaTime, 0);
                break;
            
            
            case "2D":
                rb.gravityScale = 10;
                if (jumpAction.action.WasPressedThisFrame() && GetIsGrounded())
                {
                    Jump();
                }
                gameObject.transform.position += new Vector3(_movement.x * moveSpeed * Time.deltaTime, 0,0); 
                break;
        }
    }

    bool GetIsGrounded()
    {
        return Physics2D.Raycast(gameObject.transform.position, Vector2.down, maxRange, layerMask);
    }

    void Jump()
    {
        rb.linearVelocity = Vector2.up * jumpSpeed;
    }
}
