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
        //Rugudbody 이동
        carRb.linearVelocityX = h * moveSpeed; 
    }

    private void OnCollisionEnter2D(Collision2D other) //충돌하는 순간 한 번 실행 
    {
        Debug.Log("Collision Enter");
    }

    private void OnCollisionStay2D(Collision2D other) //충돌 중일 경우 계속 실행
    {
        Debug.Log("Collision Stay");
    }

    private void OnCollisionExit2D(Collision2D other) // 충돌이 끝나고 한 번 실행
    {
        Debug.Log("Collision Exit");
    }

    private void OnTriggerEnter2D(Collider2D other) //충돌하는 순간 한 번 실행 
    {
        Debug.Log("Trigger Enter");
    }

    private void OnTriggerStay2D(Collider2D other) //충돌 중일 경우 계속 실행
    {
        Debug.Log("Trigger Stay");
    }

    private void OnTriggerExit2D(Collider2D other) // 충돌이 끝나고 한 번 실행
    {
        Debug.Log("Trigger Exit");
    }
}
