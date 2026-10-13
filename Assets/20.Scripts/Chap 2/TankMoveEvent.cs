using UnityEngine;
using UnityEngine.InputSystem;

public class TankMoveEvent : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float rotateSpeed = 40f;
    float move;
    float rotate;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(Mathf.Abs(move) > 0.1f || Mathf.Abs(rotate) > 0.1f)
        {
            Move();
            Rotate();
        }
    }

    void OnMove(InputValue value)
    {
        // Debug.Log("Input value :" + value.Get<float>());    
        move = value.Get<float>();
    }

    void OnRotate(InputValue value)
    {
        rotate = value.Get<float>();
    }

    // public void OnTankMove(InputAction.CallbackContext context)
    // {
    //     // Debug.Log("Move value: " + context.ReadValue<float>());    
    //     move = context.ReadValue<float>();
    // }

    // public void OnTankRotate(InputAction.CallbackContext context)
    // {
    //     // Debug.Log("Rotate value: " + context.ReadValue<float>());    
    //     rotate = context.ReadValue<float>();
    // }

    void Move()
    {
        Vector3 moveDir = transform.forward * move * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + moveDir);
    }

    void Rotate()
    {
        float rotSpeed = rotate * rotateSpeed *Time.deltaTime;
        rb.rotation = Quaternion.Euler(0, rotSpeed, 0) * rb.rotation;
    }
}
