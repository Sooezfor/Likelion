using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class StudyInheritance : MonoBehaviour
{
    public List<Person> persons = new List<Person>();

    private void Start() // �޽��� ��Ʃ��Ʈ�� ������ �� ��ӹް� �ֱ� ������ �޽� �ȿ� ��Ʃ��Ʈ�� ���� ���� �� �ִ°�. 
    {
        for(int i = 0; i < 10; i++)
        {
            Student student = new Student(); //Ŭ���� ����ȯ
            persons.Add(student);

        }
        for(int i = 0; i<10; i++)
        {
            Soldier soldier = new Soldier(); //Ŭ���� ����ȯ
            persons.Add(soldier);
        }
    }

    public void AllMove() //
    {
        foreach(var persons in persons) //var�� ������ ��������. 
            persons.Walk();
    }
}
