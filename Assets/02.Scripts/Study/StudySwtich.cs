using UnityEngine;

public class StudySwtich : MonoBehaviour
{
    public enum CalculationType { PLUS, MINUS, MUTIPLY, DEVIDE} //�������� �⺻���� 0, 1,2,3 �׷��� �۾��� ����
    // ���� Ÿ�� ����(����) 
    public CalculationType calculationType = CalculationType.PLUS; //������ �Ҵ��ϴ� ��

    public int input1, input2, result;

    private void Start()
    {
        Debug.Log($" ��� ��� : {Calculation()}");
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
                Debug.Log("�ٽ� �Է��ϼ���");
                break;

        }
        
        return result;
    }



}
