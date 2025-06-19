using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;//�ӵ� ����
 
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");// �ε巴�� �����ϴ� �� 

        Vector3 dir = new Vector3(h, 0, v);
        Vector3 normalDir = dir.normalized;

        transform.position += normalDir * moveSpeed * Time.deltaTime; // ��������� �̵��ϴ� ��� 

        transform.LookAt(transform.position + normalDir); //�̵��ϴ� �������� ȸ���ϴ� ���

    }
}

