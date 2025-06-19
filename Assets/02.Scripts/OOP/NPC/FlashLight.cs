using UnityEngine;

public class FlashLight : MonoBehaviour, IDropItem
{
    public GameObject lightObj;
    public bool isLight;

    public void Grab(Transform grabpos)
    {
        transform.SetParent(grabpos);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
        Debug.Log("�������� �ֿ���.");
    }

    public void Use()
    {
        lightObj.SetActive(!lightObj.activeSelf);
        Debug.Log("����Ʈ�� �Ҵ�.");
    }

    public void Drop()
    {
        transform.SetParent(null);
        transform.position = Vector3.zero;
        Debug.Log("�������� ���ȴ�.");
    }
}