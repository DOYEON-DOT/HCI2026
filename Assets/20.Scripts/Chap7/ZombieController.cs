using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class ZombieController : MonoBehaviour
{
    public Transform targetTR;          // 쫓아갈 대상 (Tank)
    public float stopDistance = 1.5f;   // 이 거리까지 다가가면 멈춤

    [Header("랜덤 리스폰")]
    public float safeDistance = 10f;    // 탱크로부터 최소 이만큼 떨어진 곳에서만 생성
    public bool respawnOnCatch = true;  // 탱크를 잡으면 다른 곳에서 다시 생성
    public float respawnDelay = 2f;     // 잡은 뒤 다시 생성될 때까지 대기 시간(초)

    NavMeshAgent nav;
    Animator anim;
    Bounds mapBounds;
    float catchTimer;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        nav.stoppingDistance = stopDistance;

        // 구워진 NavMesh 전체 범위를 구한다
        NavMeshTriangulation tri = NavMesh.CalculateTriangulation();
        mapBounds = new Bounds(tri.vertices.Length > 0 ? tri.vertices[0] : transform.position, Vector3.zero);
        foreach (Vector3 v in tri.vertices) mapBounds.Encapsulate(v);

        Respawn();
    }

    void Update()
    {
        if (targetTR == null) return;

        // 좀비는 탱크를 계속 따라간다
        nav.SetDestination(targetTR.position);

        // 움직일 때만 걷는 애니메이션 재생
        if (anim != null)
        {
            anim.speed = nav.velocity.magnitude > 0.1f ? 1f : 0f;
        }

        // 탱크를 잡으면 잠시 뒤 다른 곳에서 다시 나타난다
        if (respawnOnCatch && Vector3.Distance(transform.position, targetTR.position) <= stopDistance + 0.5f)
        {
            catchTimer += Time.deltaTime;
            if (catchTimer >= respawnDelay)
            {
                Respawn();
            }
        }
        else
        {
            catchTimer = 0f;
        }
    }

    // NavMesh 위의 랜덤 위치 중, 탱크와 safeDistance 이상 떨어진 곳으로 이동
    public void Respawn()
    {
        catchTimer = 0f;
        for (int i = 0; i < 50; i++)
        {
            Vector3 p = new Vector3(
                Random.Range(mapBounds.min.x, mapBounds.max.x),
                mapBounds.center.y,
                Random.Range(mapBounds.min.z, mapBounds.max.z));

            if (NavMesh.SamplePosition(p, out NavMeshHit hit, 2f, NavMesh.AllAreas))
            {
                if (targetTR == null || Vector3.Distance(hit.position, targetTR.position) >= safeDistance)
                {
                    nav.Warp(hit.position);
                    return;
                }
            }
        }
        Debug.LogWarning("탱크에서 충분히 떨어진 리스폰 위치를 못 찾았어요. Safe Distance를 줄여보세요.");
    }
}
