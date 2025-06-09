using Unity.VisualScripting;
using UnityEngine;

public class Study_Foreach : MonoBehaviour
{
    public string[] persons = new string[5] { "철수", "영희", "동수", "마이클", "존" };
    public string findName; 

    private void Start()
    {
        FindPerson(findName);
    }

    void FindPerson(string name)
    {
        bool isFind = false;
        foreach(var person in persons) //person 은 foreach 에서 잠깐 쓰는 지역변수
        {
            if(person == name)
            {
                isFind = true;
                Debug.Log($"인원 중에 {name}이 존재합니다.");
                break;
            }
            if(!isFind)
            {
                Debug.Log($"{name}을 찾지 못했습니다.");
            }    
        }
    }
}
