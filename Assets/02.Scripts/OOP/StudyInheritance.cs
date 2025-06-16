using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class StudyInheritance : MonoBehaviour
{
    public List<Person> persons = new List<Person>();

    private void Start() // 펄슨이 스튜던트와 솔져를 다 상속받고 있기 때문에 펄슨 안에 스튜던트와 솔져 넣을 수 있는것. 
    {
        for(int i = 0; i < 10; i++)
        {
            Student student = new Student(); //클래스 형변환
            persons.Add(student);

        }
        for(int i = 0; i<10; i++)
        {
            Soldier soldier = new Soldier(); //클래스 형변환
            persons.Add(soldier);
        }
    }

    public void AllMove() //
    {
        foreach(var persons in persons) //var는 각각의 지역변수. 
            persons.Walk();
    }
}
