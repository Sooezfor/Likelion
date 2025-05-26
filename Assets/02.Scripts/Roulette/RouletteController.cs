using UnityEngine;

public class RouletteController : MonoBehaviour
{
    public float rotSpeed = 5f;

    public bool isStop; //기본값 false 임 

     void Start()
    {
        rotSpeed = 0f; 
    }

    void Update()
    {
        transform.Rotate(Vector3.forward * rotSpeed);

        // 마우스 왼쪽 버튼을 눌렀을 때 회전하는 기능 
        if (Input.GetMouseButtonDown(0)) // 한 번 실행됨. 키 다운이라서. 누르는 순간
        {
            rotSpeed = 5f;
        }

        if(Input.GetKeyDown(KeyCode.Space)) //스페이스바 눌렀을 때 멈추기. 한 번 실행.
        {
            isStop = true;
   
        }

       if(isStop == true)
         {
            rotSpeed *= 0.98f; //속도를 계속 마이너스 하게 하기 위해 업데이트에서 실행해야함. 
                               // 현재 속도에서 특정 값만큼 줄이는 기능이다. 
         }

            if (rotSpeed < 0.01f)
            {
                rotSpeed = 0f;
            isStop = false;
            }
      
    }
}