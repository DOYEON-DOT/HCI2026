using UnityEngine;

public class CannonController : MonoBehaviour
{
    public GameObject shellPrefab;
    public Transform fireTrans;
    GameObject shell;

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            shell = Instantiate(shellPrefab, fireTrans.position, fireTrans.rotation);
            shell.GetComponent<ShellController>().Shoot(transform.up);
        }
    }

}
