using UnityEngine;

public class StudyLog : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start 함수 실행");
        Debug.LogWarning("Start 함수 실행");
        Debug.LogError("Start 함수 실행");
    }

  
    void Update()
    {
        Debug.Log("Update 함수 실행");
    }
}
