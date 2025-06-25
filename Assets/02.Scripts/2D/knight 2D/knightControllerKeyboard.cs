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
    private void Update()//�Ϲ����� �۾�
    {
        InputKeyboard();
        Jump();
        Attack(); 
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Monster"))
        {
            Debug.Log($"{attackDamage} ���� ����");
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
        if (inputDir.x != 0) //Ű�� ������ ������ �����̵���
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
            if (!isAttack) // !isAttack �� �ǹ̴� isAttack == false (isAttack�� false�� ���� ������ �ߵ�)
            {
                isAttack = true;
                attackDamage = 3f;
                animator.SetTrigger("Attack"); //�⺻ ����
            }
            else
            {
                isCombo = true; //�޺� ��

            }
        }
    }

    public void CheckCombo() //������� wait �޺��� �ٲ� �Լ� �̸�
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
