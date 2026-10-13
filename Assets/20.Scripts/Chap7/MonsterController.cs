using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class MonsterController : MonoBehaviour
{
    public Transform npcTR;        // 쫓아갈 대상 (NPC)
    public float catchDistance = 1.2f; // 이 거리 안에 들어오면 잡힘
    NavMeshAgent nav;

    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (npcTR == null) return;

        // 몬스터는 NPC를 계속 쫓아간다
        nav.SetDestination(npcTR.position);

        // NPC를 잡았는지 확인
        if (Vector3.Distance(transform.position, npcTR.position) < catchDistance)
        {
            Debug.Log("NPC가 몬스터에게 잡혔다!");
            npcTR.GetComponent<NavMeshAgent>().isStopped = true; // NPC 멈춤
            nav.isStopped = true;                                // 몬스터도 멈춤
            enabled = false;
        }
    }
}
