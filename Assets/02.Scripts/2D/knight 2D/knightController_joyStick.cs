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
    private void Update()//일반적인 작업
    {
   
    }

    private void FixedUpdate() //물리적인 작업 
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
        if (inputDir.x != 0) //키를 눌렀을 때에만 움직이도록
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

        if (inputDir.x != 0) //키를 눌렀을 때에만 움직이도록
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

