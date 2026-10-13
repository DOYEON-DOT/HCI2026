using UnityEngine;
using UnityEngine.InputSystem;

public class PaladinController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float rotateSpeed = 40f;
    float move;
    float rotate;
    Rigidbody rb;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if(Mathf.Abs(move) > 0.1f || Mathf.Abs(rotate) > 0.1f)
        {
            Move();
            Rotate();
        }
        anim.SetFloat("Move", move);
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

    void OnFire(InputValue value)
    {
        anim.SetTrigger("IsPunching");
    }

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
