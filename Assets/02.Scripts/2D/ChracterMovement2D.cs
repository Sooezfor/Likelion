using UnityEngine;

public class ChracterMovement2D : MonoBehaviour
{
    Rigidbody2D chaRb;
    public SpriteRenderer[] renderers;

    public float jumpPower = 10f;
    public float moveSpeed;
    float h;
    public bool isGround;

    private void Start()
    {
        chaRb = GetComponent<Rigidbody2D>();
        renderers = GetComponentsInChildren<SpriteRenderer>(true);
        //�ڽĵ� �ȿ��� ��������Ʈ �������� �ִ� �ֵ��� �������ڴ�. ture�� Ȱ����Ȱ�� ���¸� �����ϰ� ������ true�� �ٲٰڴ� ��
    }

    private void Update()
    {
        h = Input.GetAxis("Horizontal");//-1���� 1�� ������.
        Jump();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D other) //���鿡 ���� ����
    {
        isGround = true;

        renderers[2].gameObject.SetActive(false); //jump
    }
    private void OnCollisionExit2D(Collision2D other) //���鿡 ���� ���� ����
    {
        isGround = false;

        renderers[0].gameObject.SetActive(false); //idle.
        renderers[1].gameObject.SetActive(false); //run.
        renderers[2].gameObject.SetActive(true); //jump
    }
    /// <summary>
    /// ĳ���� �����ӿ� ���� �̹����� Flip ���°� ���ϴ� ���
    /// </summary>
    private void Move()
    {
        if (!isGround) //���� isGround�� �޽��϶� �ش� �Լ� ���� ����
            return;

        if(h != 0) //h�� 0�� �ƴ� ����(������ ��)/ �Է� Ű�� ���� �� 
        {
            renderers[0].gameObject.SetActive(false);//idle
            renderers[1].gameObject.SetActive(true);//run

             //������ٵ� �̿��� �������� �̵��̱� ������ Fixed update���� 
            chaRb.linearVelocityX = h * moveSpeed;

            if(h > 0) // �����ʺ���
            {
                renderers[0].flipX = false;
                renderers[1].flipX = false;
                renderers[2].flipX = false;

            }
            else if( h < 0)//���ʺ���
            {
                renderers[0].flipX = true;
                renderers[1].flipX = true;
                renderers[2].flipX = true;
            }
        }
        else if( h == 0)// h�� 0�� ����(�� ������ ��)/Ű�� ������ ���� ��
        {
            renderers[0].gameObject.SetActive(true);//idle
            renderers[1].gameObject.SetActive(false); //run
        }
    }

    /// <summary>
    /// ĳ���Ͱ� +Y �������� �����ϴ� ��� 
    /// </summary>
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))  //Input.GetKeyDown(KeyCode.Space) �� �Ȱ���
        {
            chaRb.AddForceY(jumpPower, ForceMode2D.Impulse);
        }
    }
}
