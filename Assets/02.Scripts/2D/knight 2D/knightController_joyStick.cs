using UnityEngine;

public class knightController_joyStick : MonoBehaviour
{
    Animator animator;
    Rigidbody2D knightRb;
    bool isGround;

    Vector3 inputDir;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float jumpPower = 13f;

    private void Start()
    {
        animator = GetComponent<Animator>();
        knightRb = GetComponent<Rigidbody2D>();

    }
    private void Update()//�Ϲ����� �۾�
    {
   
    }

    private void FixedUpdate() //�������� �۾� 
    {
        Move();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isGround", true);
            isGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isGround", false);
            isGround = false;
        }
    }

    private void Move()
    {
        if (inputDir.x != 0) //Ű�� ������ ������ �����̵���
        {
            knightRb.linearVelocityX = inputDir.x * moveSpeed;
        }
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            animator.SetTrigger("Jump");
            knightRb.AddForceY(jumpPower, ForceMode2D.Impulse);
        }
    }
    void SetAnim()
    {

        if (inputDir.x != 0) //Ű�� ������ ������ �����̵���
        {
            animator.SetBool("isRun", true);
        }
        else if (inputDir.x == 0)
            animator.SetBool("isRun", false);

        if (inputDir.x != 0)
        {
            var scaleX = inputDir.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX, 1, 1);
        }

    }
}

