using UnityEngine;

public class TankController : MonoBehaviour
{
    public float moveSpeed = 2f;
    float move;
    float rotate;
    Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Vertical");
        rotate = Input.GetAxis("Horizontal");

        if (Mathf.Abs(move) > 0.1f)
        {
            Move();
        }    
    }

    private void Move()
    {
        Vector3 moveDir = transform.forward * move * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + moveDir);
    }
}
