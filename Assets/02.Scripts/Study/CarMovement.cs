using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float moveSpeed = 3f;

    public Rigidbody2D carRb;

    private float h;
    
    void Update()
    {
        h = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        //Rugudbody �̵�
        carRb.linearVelocityX = h * moveSpeed; 
    }

    private void OnCollisionEnter2D(Collision2D other) //�浹�ϴ� ���� �� �� ���� 
    {
        Debug.Log("Collision Enter");
    }

    private void OnCollisionStay2D(Collision2D other) //�浹 ���� ��� ��� ����
    {
        Debug.Log("Collision Stay");
    }

    private void OnCollisionExit2D(Collision2D other) // �浹�� ������ �� �� ����
    {
        Debug.Log("Collision Exit");
    }

    private void OnTriggerEnter2D(Collider2D other) //�浹�ϴ� ���� �� �� ���� 
    {
        Debug.Log("Trigger Enter");
    }

    private void OnTriggerStay2D(Collider2D other) //�浹 ���� ��� ��� ����
    {
        Debug.Log("Trigger Stay");
    }

    private void OnTriggerExit2D(Collider2D other) // �浹�� ������ �� �� ����
    {
        Debug.Log("Trigger Exit");
    }
}
