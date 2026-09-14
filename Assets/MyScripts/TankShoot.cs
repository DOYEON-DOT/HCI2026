using UnityEngine;

public class TankShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("클릭됨!");
            Shoot();
        }
    }

    void Shoot()
    {
        // 총알 생성
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // 총알에 속도 부여
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = firePoint.forward * bulletSpeed;
        }

        // 5초 후 자동 삭제
        Destroy(bullet, 5f);
    }
}