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

    private bool isGround; //�⺻�� false ��.
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
            Debug.Log($"{attackDamage} ���� ����");
        }
    }
    public void InputJoystick(float x, float y)
    {
        inputDir = new Vector3(x, y, 0).normalized; //�� ���� ���� ��ֶ������ؼ� ũ�� ����

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
        if(!isAttack) // !isAttack �� �ǹ̴� isAttack == false (isAttack�� false�� ���� ������ �ߵ�)
        {
            isAttack = true;
            attackDamage = 3f;
            animator.SetTrigger("Attack"); //�⺻ ����
        }
        else
        {
            isCombo = true; //�޺� ��
            Debug.Log("�޺� Ȯ��");
        }
    }

    public void CheckCombo() //������� wait �޺��� �ٲ� �Լ� �̸�
    {
        if(isCombo)
        {
            attackDamage = 5f; 
            Debug.Log("�޺� ����");
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
