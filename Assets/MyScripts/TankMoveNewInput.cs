using UnityEngine;
using UnityEngine.InputSystem;

public class TankMoveNewInput : MonoBehaviour
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

    private void Update()
    {
        if (Mathf.Abs(move) > 0.1f || Mathf.Abs(rotate) > 0.1f)
        {
            Move();
            Rotate();
        }
    }

    void OnMove(InputValue value)
    {
        move = value.Get<float>();
    }

    void OnRotate(InputValue value)
    {
        rotate = value.Get<float>();
    }

    void Move()
    {
        Vector3 moveDir = transform.forward * move * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + moveDir);
    }

    void Rotate()
    {
        float rotSpeed = rotate * rotateSpeed * Time.deltaTime;
        rb.rotation = Quaternion.Euler(0, rotSpeed, 0) * rb.rotation;
    }
}
// rotate를 포함하여 button이 아니라 value를 눌러줘야함
// 속도가 느리면 Rotate Speed 값을 증가시키기(인스펙터 창, 30까지 올려보기)
// 탱크 이동하는 코드
// behavior를 send message로 변경(인스펙터창)
//인풋시스템에서 이벤트를 만들면 유니티 시스템이 자동으로 동작시켜줌: 유니티 핸들링
