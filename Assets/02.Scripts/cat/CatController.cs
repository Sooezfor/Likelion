using UnityEngine;

public class CatController : MonoBehaviour
{

    Rigidbody2D catRb;
    public float jumpPower = 10f;
    public bool isGround = false; //닿았으면 true, 떨어지면 false

    public int jumpCount = 0; 

    void Start()
    {
        catRb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //스페이스바 누르면 점프
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2) //점프 두 번 가능
        {
            catRb.AddForceY(jumpPower, ForceMode2D.Impulse);
            jumpCount++;
        }
    }     
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            jumpCount = 0; //바닥에 닿으면 점프 초기화
            isGround = true; 
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isGround = false;
        }
    }
}
