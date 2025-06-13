using UnityEngine;

public class Factory<T> : MonoBehaviour
{
    public T prefab;

    public Factory()
    {
        Debug.Log($"현재 factory는 {typeof(T)} 타입 입니다."); 
    }

}
