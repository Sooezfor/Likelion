using UnityEngine;

public class StudySwtich : MonoBehaviour
{
    public enum CalculationType { PLUS, MINUS, MUTIPLY, DEVIDE} //열거형은 기본값이 0, 1,2,3 그래서 글씨로 접근
    // 열거 타입 생성(선언) 
    public CalculationType calculationType = CalculationType.PLUS; //변수에 할당하는 식

    public int input1, input2, result;

    private void Start()
    {
        Debug.Log($" 계산 결과 : {Calculation()}");
    }

    int Calculation()
    {
 
        switch (calculationType)
        {
            case CalculationType.PLUS:
                result = input1 + input2; 
                break;

            case CalculationType.MINUS:
                result = input1 - input2;
                break;

            case CalculationType.MUTIPLY:
                result = input1 * input2;
                break;

            case CalculationType.DEVIDE:
                result = input1/ input2;
                break;

            default:
                Debug.Log("다시 입력하세요");
                break;

        }
        
        return result;
    }



}
