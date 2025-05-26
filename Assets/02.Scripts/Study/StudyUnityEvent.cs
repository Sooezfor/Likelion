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

    private void OnEnable() //���� ������ 1�� ����
    {
        Debug.Log("OnEnable");
    }

    private void OnDisable() // ���� ������ 1�� ����
    {
        Debug.Log("OnDisable");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
