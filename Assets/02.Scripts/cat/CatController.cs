using Unity.VisualScripting;
using UnityEngine;
using Cat;

public class CatController : MonoBehaviour
{
    public SoundManager soundManager;
    Animator catAnim; 
    Rigidbody2D catRb;
    public float jumpPower = 10f;
    public bool isGround = false; //닿았으면 true, 떨어지면 false
    public int jumpCount = 0; 

    void Start()
    {
        catRb = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();
    }
    void Update()
    {
        //스페이스바 누르면 점프
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2) //점프 두 번 가능
        {
            catAnim.SetTrigger("Jump"); //애니메이터 파라미터에 접근하기
            catAnim.SetBool("IsGround", false); //점프할 때 논리값 펄스로 만들기

            catRb.AddForceY(jumpPower, ForceMode2D.Impulse);
            jumpCount++;

            soundManager.OnJumpSound();
        }
    }     
    private void OnCollisionEnter2D(Collision2D other) //바닥에 닿았을 때 
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            catAnim.SetBool("IsGround", true);
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
