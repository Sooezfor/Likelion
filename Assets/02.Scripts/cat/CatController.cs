using UnityEngine;

public class CatController : MonoBehaviour
{

    Rigidbody2D catRb;
    public float jumpPower = 10f;
    public bool isGround = false; //������� true, �������� false

    public int jumpCount = 0; 

    void Start()
    {
        catRb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //�����̽��� ������ ����
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2) //���� �� �� ����
        {
            catRb.AddForceY(jumpPower, ForceMode2D.Impulse);
            jumpCount++;
        }
    }     
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
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
