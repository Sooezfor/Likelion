using UnityEngine;

public class Study_Class
{
    public int number;

    public Study_Class(int number) // 생성자: 생성될 때 실행되는 함수
    {
        this.number = number;
    }
}

public struct Study_Struct
{
    public int number;

    public Study_Struct(int number) // 생성자, (int number) 는 매개변수라고 보면됨. 뒤에서 넣은 숫자가 여기로 오는것. 
    {
        this.number = number;
    }
}



public class Study_ClassStruct : MonoBehaviour
{


    void Start()
    {
        Debug.Log("클래스 --------------------------------- ");
        Study_Class c1 = new Study_Class(10);
        Study_Class c2 = c1;//c2에는 c1과 같다. 
        Debug.Log($"c1 : {c1.number} / c2 : {c2.number}");

        c1.number = 100;
        Debug.Log($"c1 : {c1.number} / c2 : {c2.number}");


        Debug.Log("구조체 --------------------------------- ");
        Study_Struct s1 = new Study_Struct(10);
        Study_Struct s2 = s1;
        Debug.Log($"s1 : {s1.number} / s2 : {s2.number}");

        s1.number = 100;
        Debug.Log($"s1 : {s1.number} / s2 : {s2.number}");
    }
}
