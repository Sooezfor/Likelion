using UnityEngine;

public class ColliderEvent : MonoBehaviour
{

    /// <summary>
    /// ��ȣ�ۿ��� �ϴ� �� �� isTrigger = false �� ��� ȣ�� 
    /// </summary>
    /// <param name="other"></param>

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision Enter");
    }

    /// <summary>
    /// ��ȣ�ۿ��ϴ� �� �� �ϳ��� isTrigger = true �� �ܿ� ȣ��
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter");
    }

}
