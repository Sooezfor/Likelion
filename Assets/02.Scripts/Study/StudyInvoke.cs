using UnityEngine;

public class StudyInvoke : MonoBehaviour
{
    public int count = 10; 

    private void Start()
    {
        //�κ�ũ �ݺ� ("�Լ���", ó�� �����ð�, �� ���ķ� ���ʸ��� (�ֱ�) 
        InvokeRepeating("Bomb", 0f, 1f);

    }
    void Bomb()
    {
        Debug.Log($"���� ���� �ð� : {count}��");
        count--; 

        if(count == 0)
        {
            Debug.Log("��ź�� �������ϴ�.");
            CancelInvoke("Bomb");
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CancelInvoke("Bomb");
            Debug.Log("��ź�� �����Ǿ����ϴ�.");
        }
        
    }
}
