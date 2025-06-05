using UnityEngine;

public class whileLoop : MonoBehaviour
{
    public int count = 0;
    
    void Start()
    {
        while(count <= 10)
        {
            count++; 

            if(count % 3 == 0) // count를 3으로 나머지 연산했을때 0이 됨 (3의 배수)
            {           
                Debug.Log("박수 짝!");
                continue;
            }

            Debug.Log($"현재 {count}입니다.");          
        }

    }
}
