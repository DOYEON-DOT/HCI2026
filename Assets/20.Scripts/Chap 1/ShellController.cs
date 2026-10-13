using UnityEngine;

public class ShellController : MonoBehaviour
{
    public float speed = 100f;
    int lifetime = 5;

    //private void Start()
    //{
    //    Shoot(transform.up);
    //}

    public void Shoot(Vector3 dir)
    {
        GetComponent<Rigidbody>().AddForce(dir * speed);
        Destroy(gameObject, lifetime);
    }
}
