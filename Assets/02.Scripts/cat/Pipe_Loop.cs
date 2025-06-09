using UnityEngine;

public class Pipe_Loop : MonoBehaviour
{
    public float moveSpeed = 3;
    public float returnPosX = 15f;

    public float randomPosY;

    private void Start()
    {
        randomPosY = Random.Range(-8, -3); 
        transform.position = new Vector3(transform.position.x, randomPosY, 0);

    }

    void Update()
     { 
        transform.position += Vector3.left * moveSpeed * Time.fixedDeltaTime;
 
        if (transform.position.x <= -returnPosX) //이미지의 x축 값이 -30을 넘는 순간 리턴
        {
            randomPosY = Random.Range(-8, -4);
            transform.position = new Vector3(returnPosX, randomPosY, 0);
        }
    }
}
