using UnityEngine;

public class RouletteController : MonoBehaviour
{
    public float rotSpeed = 5f;

    public bool isStop; //�⺻�� false �� 

     void Start()
    {
        rotSpeed = 0f; 
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotSpeed);

        // ���콺 ���� ��ư�� ������ �� ȸ���ϴ� ��� 
        if (Input.GetMouseButtonDown(0)) // �� �� �����. Ű �ٿ��̶�. ������ ����
        {
            rotSpeed = 5f;
        }

        if(Input.GetKeyDown(KeyCode.Space)) //�����̽��� ������ �� ���߱�. �� �� ����.
        {
            isStop = true;
   
        }

       if(isStop == true)
         {
            rotSpeed *= 0.98f; //�ӵ��� ��� ���̳ʽ� �ϰ� �ϱ� ���� ������Ʈ���� �����ؾ���. 
                               // ���� �ӵ����� Ư�� ����ŭ ���̴� ����̴�. 
         }

            if (rotSpeed < 0.01f)
            {
                rotSpeed = 0f;
            isStop = false;
            }
      
    }
}