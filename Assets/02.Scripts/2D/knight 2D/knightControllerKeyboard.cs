using UnityEngine;

public class knightControllerKeyboard : MonoBehaviour
{
    Animator animator;
    Rigidbody2D knightRb;
    bool isGround;

    Vector3 inputDir;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float jumpPower = 13f;

    float attackDamage = 3f;
    bool isCombo;
    bool isAttack;

    private void Start()
    {
        animator = GetComponent<Animator>();
        knightRb = GetComponent<Rigidbody2D>();
        
    }
    private void Update()//일반적인 작업
    {
        InputKeyboard();
        Jump();
        Attack(); 
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            Debug.Log($"{attackDamage} 공격 판정");
        }
    }

    void InputKeyboard()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        inputDir = new Vector3(h, v, 0);

        animator.SetFloat("JoystickX", inputDir.x);
        animator.SetFloat("JoystickY", inputDir.y);
    }

    private void Move()
    {
        if (inputDir.x != 0) //키를 눌렀을 때에만 움직이도록
        {
             var scaleX = inputDir.x > 0 ? 1 : -1;
             transform.localScale = new Vector3(scaleX, 1, 1);

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

    void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            if (!isAttack) // !isAttack 의 의미는 isAttack == false (isAttack이 false일 때만 공격이 발동)
            {
                isAttack = true;
                attackDamage = 3f;
                animator.SetTrigger("Attack"); //기본 공격
            }
            else
            {
                isCombo = true; //콤보 들어감

            }
        }
    }

    public void CheckCombo() //강사님은 wait 콤보로 바꿈 함수 이름
    {
        if (isCombo)
        {
            attackDamage = 5f;
            animator.SetBool("isCombo", true);
        }
        else
        {
            animator.SetBool("isCombo", false);
            isAttack = false;
        }
    }
    void EndCombo()
    {
        isAttack = false;
        isCombo = false;
        animator.SetBool("isCombo", false);
    }
}
