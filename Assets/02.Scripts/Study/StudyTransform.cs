using UnityEngine;

public class StudyTransform : MonoBehaviour
{
    public float moveSpeed = 10f;
    public float rotateSpeed = 70f; 

    // Update is called once per frame
    void Update()

    {
        //float angle = transform.rotation.eulerAngles.y + rotateSpeed * Time.deltaTime; //�̷��� ������ �̸� �����ϰ� ȸ�����ٰ� �־ ��.
        //float localX = transform.eulerAngles.x;
        //float localZ = transform.eulerAngles.z;


        // ���� �������� �̵� 
        //transform.position += Vector3.forward * moveSpeed * Time.deltaTime;

        //���� �������� �̵� 2��° ���
        //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime, Space.World);

        // ���� �������� �̵� 
        //transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        //���� �������� ȸ�� 
        //transform.rotation = Quaternion.Euler(localX,angle,localZ);

        //���� �������� ȸ��
        //transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime);//Space.slef �����Ȱ���.

        //�� �ڵ忡�� ���� �������� ȸ���ϴ� ���
        //transform.Rotate(Vector3.up, rotateSpeed * Time.deltaTime, Space.World);

        //Ư�� ��ġ�� �ֺ��� ȸ�� (���⼭�� zero�� �������� ����) 
        transform.RotateAround(Vector3.zero, Vector3.up, rotateSpeed * Time.deltaTime);
        transform.RotateAround(new Vector3(0, 0, 0), new Vector3(0, 1, 0), rotateSpeed * Time.deltaTime);

        transform.LookAt(Vector3.zero); 
      
    }
}
