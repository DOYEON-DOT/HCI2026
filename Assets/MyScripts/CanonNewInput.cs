using UnityEngine;
using UnityEngine.InputSystem;

public class CanonNewInput : MonoBehaviour
{
    public GameObject shellPrefab;
    public Transform fireTrans;

    GameObject shell;

    void OnFire(InputValue value)
    {
        shell = Instantiate(shellPrefab, fireTrans.position, fireTrans.rotation);
        shell.GetComponent<ShellController>().Shoot(fireTrans.up);
    }
}

//캐논에 캐논 인풋하고 파이어 포지션 적용
// 플레이어 인풋()
// fbs로..
// 가장 기본적인 sendmessage 방법
// 브로드캐스트..
// 1. 씬스 2. 스트립트 3. 모델스 4.Materials 9_Downloads Settings Tu?
//. 파일 탐색기 1. 씬스에 21_NEW====
