using Unity.VisualScripting;
using UnityEngine;

public class Study_Foreach : MonoBehaviour
{
    public string[] persons = new string[5] { "ö��", "����", "����", "����Ŭ", "��" };
    public string findName; 

    private void Start()
    {
        FindPerson(findName);
    }

    void FindPerson(string name)
    {
        bool isFind = false;
        foreach(var person in persons) //person �� foreach ���� ��� ���� ��������
        {
            if(person == name)
            {
                isFind = true;
                Debug.Log($"�ο� �߿� {name}�� �����մϴ�.");
                break;
            }
            if(!isFind)
            {
                Debug.Log($"{name}�� ã�� ���߽��ϴ�.");
            }    
        }
    }
}
