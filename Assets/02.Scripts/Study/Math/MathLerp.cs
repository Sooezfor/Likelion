using UnityEngine;

public class MathLerp : MonoBehaviour
{
    public Vector3 targetPos;
    public float smoothValue;

    Vector3 startPos;
    float timer, percent; 
    public float lerpTime; 

    private void Start()
    {
        startPos = transform.position; //���� ���� ����, ��ǥ�������� ������
    }

    private void Update()
    {
        timer += Time.deltaTime; //�ð� ����
        percent = timer / lerpTime; 

        transform.position = Vector3.Lerp(startPos, targetPos, percent); //�����ϰ� ���� �̵�
    }
}
