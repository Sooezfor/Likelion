using UnityEngine;

public class Transform_LoopMap : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float height = 1.5f;

    public Vector3 returnPos;


    private void Start()
    {
        
    //��� �̹����� ���̰� 30�̱� ������ x= 30f 
     returnPos = new Vector3(27.80f, height, 0f);
    }

    void Update()
    {
        //��� �������� �̵��ϴ� ���
        //transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        transform.position += Vector3.left * moveSpeed * Time.fixedDeltaTime;
        Debug.Log(Time.fixedDeltaTime);

        if(transform.position.x <= -30f) //�̹����� x�� ���� -30�� �Ѵ� ���� ����
        {
            transform.position = returnPos;
        }

    }
    
    

}
