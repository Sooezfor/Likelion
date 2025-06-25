using System;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.UI;

public class knightController_joyStick : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D knightRb;

    [SerializeField] Button jumpButton, attackButton;

    private Vector3 inputDir;
  
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float jumpPower = 13f;

    float attackDamage = 3f;

    private bool isGround; //기본값 false 임.
    bool isCombo;
    bool isAttack; 

    void Start()
    {
        animator = GetComponent<Animator>();
        knightRb = GetComponent<Rigidbody2D>();

        jumpButton.onClick.AddListener(Jump);
        attackButton.onClick.AddListener(Attack);
    }

    void FixedUpdate()
    {
        Move();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("isGround", true);
            isGround = true;
        }
    }

    void OnCollisionExit2D(Collision2D other)
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
    public void InputJoystick(float x, float y)
    {
        inputDir = new Vector3(x, y, 0).normalized; //날 것의 값에 노멀라이즈해서 크기 조절

        animator.SetFloat("JoystickX",inputDir.x);
        animator.SetFloat("JoystickY",inputDir.y);

        if(inputDir.x != 0)
        {
            var scaleX = inputDir.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX, 1, 1);
        }
    }

    void Move()
    {
        if (inputDir.x != 0)
            knightRb.linearVelocityX = inputDir.x * moveSpeed;
    }

    void Jump()
    {
        if (isGround)
        {
            animator.SetTrigger("Jump");
            knightRb.AddForceY(jumpPower, ForceMode2D.Impulse);
        }
    }

    void Attack()
    {
        if(!isAttack) // !isAttack 의 의미는 isAttack == false (isAttack이 false일 때만 공격이 발동)
        {
            isAttack = true;
            attackDamage = 3f;
            animator.SetTrigger("Attack"); //기본 공격
        }
        else
        {
            isCombo = true; //콤보 들어감
            Debug.Log("콤보 확인");
        }
    }

    public void CheckCombo() //강사님은 wait 콤보로 바꿈 함수 이름
    {
        if(isCombo)
        {
            attackDamage = 5f; 
            Debug.Log("콤보 실행");
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
