using System;
using UnityEngine;

public class StudyUnityEvent : MonoBehaviour
{

    private void Awake()
    {
        Debug.Log("Awake");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start");
    }

    private void OnEnable() //켜질 때마다 1번 실행
    {
        Debug.Log("OnEnable");
    }

    private void OnDisable() // 꺼질 때마다 1번 실행
    {
        Debug.Log("OnDisable");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
