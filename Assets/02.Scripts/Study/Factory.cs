using UnityEngine;

public class Factory<T> : MonoBehaviour
{
    public T prefab;

    public Factory()
    {
        Debug.Log($"���� factory�� {typeof(T)} Ÿ�� �Դϴ�."); 
    }

}
