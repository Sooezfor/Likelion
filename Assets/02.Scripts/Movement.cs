using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;//속도 변수
 
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");// 부드럽게 증감하는 값 

        Vector3 dir = new Vector3(h, 0, v);
        Vector3 normalDir = dir.normalized;

        transform.position += normalDir * moveSpeed * Time.deltaTime; // 여기까지는 이동하는 기능 

        transform.LookAt(transform.position + normalDir); //이동하는 방향으로 회전하는 기능

    }
}

