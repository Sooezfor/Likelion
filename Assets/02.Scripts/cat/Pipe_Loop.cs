using UnityEngine;

public class Pipe_Loop : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float returnPosX = 15f;

    public float randomPosY; 


    void Update()
     { 
        transform.position += Vector3.left * moveSpeed * Time.fixedDeltaTime;
 
        if (transform.position.x <= -returnPosX) //�̹����� x�� ���� -30�� �Ѵ� ���� ����
        {
            randomPosY = Random.Range(-8f, -6.8f);
            transform.position = new Vector3(returnPosX, randomPosY, 0);
        }
    }
}
