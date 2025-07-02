using UnityEngine;

public class knightControllerKeyboard : MonoBehaviour, IDamageable
{
    Animator animator;
    Rigidbody2D knightRb;

    Vector3 inputDir;
    [SerializeField] float moveSpeed = 3f;
    [SerializeField] float jumpPower = 13f;

    public float hp = 100f;
    float attackDamage = 3f;

    bool isGround;
    bool isCombo;
    bool isAttack;
    bool isLadder;

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
        if (isAttack || isCombo)
        {
            isAttack = false;
            isCombo = false;
            animator.SetBool("isCombo", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Monster"))
        {
            Debug.Log($"{attackDamage} 공격 판정");
        }
        if(other.CompareTag("Ladder"))
        {
            isLadder = true;
            knightRb.gravityScale = 0f;
            knightRb.linearVelocity = Vector2.zero; //속도 제로 설정
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            isLadder = false;
            knightRb.gravityScale = 2f;
        }
    }
    void InputKeyboard()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        inputDir = new Vector3(h, v, 0);

        animator.SetFloat("JoystickX", inputDir.x);
        animator.SetFloat("JoystickY", inputDir.y);

        if(inputDir.y < 0) //웅크릴 때 콜라이더 줄여서 들어갈 수 있도록
        {
            GetComponent<CapsuleCollider2D>().size = new Vector2(0.7f, 0.6f);
            GetComponent<CapsuleCollider2D>().offset = new Vector2(0, 0.6f);
        }
        else
        {
            GetComponent<CapsuleCollider2D>().size = new Vector2(0.7f, 1.5f);
            GetComponent<CapsuleCollider2D>().offset = new Vector2(0, 0.8f);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 10;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 3f;
        }
    }

    private void Move()
    {
        if (inputDir.x != 0) //A나 D 키를 눌렀을 때에만 움직이도록
        {
             var scaleX = inputDir.x > 0 ? 1 : -1;
             transform.localScale = new Vector3(scaleX, 1, 1);

             knightRb.linearVelocityX = inputDir.x * moveSpeed;
        }
        if(isLadder && inputDir.y != 0) //사다리 올라가기, y축이 0이 아닐 때만
        {
            knightRb.linearVelocityY = inputDir.y * moveSpeed;
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

    public void CheckCombo() // wait 콤보와 같음.
    {
        if (isCombo)
        {
            attackDamage = 5f;
            animator.SetBool("isCombo", true);
            isAttack = false;
        }
        else
        {
            animator.SetBool("isCombo", false);
            isAttack = false;
        }
    }
    public void EndCombo()
    {
        isAttack = false;
        isCombo = false;
        animator.SetBool("isCombo", false);
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0f)
        {
            Death();
        }
    }

    public void Death()
    {
        Debug.Log("YOU DIED");
    }
}
