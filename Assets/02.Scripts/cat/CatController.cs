using Unity.VisualScripting;
using UnityEngine;
using Cat;

public class CatController : MonoBehaviour
{
    public SoundManager soundManager;
    Animator catAnim; 
    Rigidbody2D catRb;
    public float jumpPower = 10f;
    public bool isGround = false; //������� true, �������� false
    public int jumpCount = 0; 

    void Start()
    {
        catRb = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();
    }
    void Update()
    {
        //�����̽��� ������ ����
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2) //���� �� �� ����
        {
            catAnim.SetTrigger("Jump"); //�ִϸ����� �Ķ���Ϳ� �����ϱ�
            catAnim.SetBool("IsGround", false); //������ �� ���� �޽��� �����

            catRb.AddForceY(jumpPower, ForceMode2D.Impulse);
            jumpCount++;

            soundManager.OnJumpSound();
        }
    }     
    private void OnCollisionEnter2D(Collision2D other) //�ٴڿ� ����� �� 
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            catAnim.SetBool("IsGround", true);
            jumpCount = 0; //�ٴڿ� ������ ���� �ʱ�ȭ
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
