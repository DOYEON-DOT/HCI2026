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
        // 포신(Cylinder)은 길이 방향이 Y축(초록 화살표)이라 firePoint.up 방향으로 쏜다
        Vector3 dir = firePoint.up;
        // 포신 끝에서 생성 (기본 Cylinder 높이 2 → 중심에서 끝까지 = Y 스케일)
        Vector3 spawnPos = firePoint.position + dir * firePoint.lossyScale.y;

        // 총알 생성
        GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.LookRotation(dir));

        // 총알에 속도 부여
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = dir * bulletSpeed;
        }

        // 5초 후 자동 삭제
        Destroy(bullet, 5f);
    }
}