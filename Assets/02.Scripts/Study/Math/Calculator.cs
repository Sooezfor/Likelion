using UnityEngine;

public class Calculator : MonoBehaviour
{
    public int number1, number2; //맴버 변수(필드)
    void Start()
    {

        int addResult = AddMethod();

        int minusResult = MinusMethod(); 


        Debug.Log($"더한 값 : {addResult} / 뺀 값 : {minusResult}");

    }

    int AddMethod()
    {
        int result = number1 + number2;
        //result 는 지역변수

        return result;
    }

    int MinusMethod()
    {
        int result = number1 - number2;

        return result;
    }

}