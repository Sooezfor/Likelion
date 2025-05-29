using UnityEngine;

public class ColliderEvent : MonoBehaviour
{

    /// <summary>
    /// 상호작용을 하는 둘 다 isTrigger = false 일 경우 호출 
    /// </summary>
    /// <param name="other"></param>

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("Collision Enter");
    }

    /// <summary>
    /// 상호작용하는 둘 중 하나라도 isTrigger = true 일 겨우 호출
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Enter");
    }

}
