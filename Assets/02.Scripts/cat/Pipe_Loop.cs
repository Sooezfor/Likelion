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
 
        if (transform.position.x <= -returnPosX) //�̹����� x�� ���� -30�� �Ѵ� ���� ����
        {
            randomPosY = Random.Range(-8, -4);
            transform.position = new Vector3(returnPosX, randomPosY, 0);
        }
    }
}
