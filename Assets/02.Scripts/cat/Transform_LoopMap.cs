using UnityEngine;

public class Transform_LoopMap : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float height = 1.5f;

    public Vector3 returnPos;


    private void Start()
    {
        
    //배경 이미지의 길이가 30이기 때문에 x= 30f 
     returnPos = new Vector3(27.80f, height, 0f);
    }

    void Update()
    {
        //배경 왼쪽으로 이동하는 기능
        //transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        transform.position += Vector3.left * moveSpeed * Time.fixedDeltaTime;
        Debug.Log(Time.fixedDeltaTime);

        if(transform.position.x <= -30f) //이미지의 x축 값이 -30을 넘는 순간 리턴
        {
            transform.position = returnPos;
        }

    }
    
    

}
