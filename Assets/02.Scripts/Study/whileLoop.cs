using UnityEngine;

public class whileLoop : MonoBehaviour
{
    public int count = 0;
    
    void Start()
    {
        while(count <= 10)
        {
            count++; 

            if(count % 3 == 0) // count�� 3���� ������ ���������� 0�� �� (3�� ���)
            {           
                Debug.Log("�ڼ� ¦!");
                continue;
            }

            Debug.Log($"���� {count}�Դϴ�.");          
        }

    }
}
