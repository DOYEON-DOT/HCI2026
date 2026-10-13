using UnityEngine;
using UnityEngine.InputSystem;

public class CannonNewInput : MonoBehaviour
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
