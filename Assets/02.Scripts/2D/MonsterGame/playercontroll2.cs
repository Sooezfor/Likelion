using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class playercontroll2 : MonoBehaviour
{
    Animator anim;
    private float h, v;
    [SerializeField] GameObject hitBox; 
    [SerializeField] float moveSpeed = 3f;


    bool isAttack = false;

    private void Start()
    {
        anim = GetComponent<Animator>(); 
    }

    private void Update()
    {
        Move();
        Attack();
    }

    private void Move()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        if(h == 0 && v == 0) //�ƹ��͵� �� ���� ���� 
        {
            anim.SetBool("Run", false);
            if(Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(AttackRoutine());
            }

        }
        else // Run ���� (��� Ű�� ���� ����) 
        {
            int scaleX = h > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX, 1, 1);

            anim.SetBool("Run", true);

            var dir = new Vector3(h, v, 0).normalized; //���Ʒ��� �����ϰ� 
            transform.position += dir * moveSpeed * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(AttackRoutine());
            }
        }
    }

    void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Space)) //��Ŭ ���� ���� �ص� �����ڷ� isAttack false ���� �����
        {
            StartCoroutine(AttackRoutine());
        }
    }
    IEnumerator AttackRoutine() //�ڷ�ƾ�� �ݺ��ڸ� ����ϴ� �ϳ��� Ÿ����
    {
        isAttack = true; //��Ŭ ���� 
        hitBox.SetActive(true);
        Debug.Log("���� ��ƾ ����");
        anim.SetBool("Hit",true);

        yield return new WaitForSeconds(0.25f);
        anim.SetBool("Hit", false);
        hitBox.SetActive(false);
        isAttack = false;
    }

    private void OnTriggerEnter2D(Collider2D other) //���� ����
    {
        if(other.GetComponent<Monster>() != null) //���� ��ũ��Ʈ�� �ִ� �ֵ����׸� ����
        {
            Monster monster = other.GetComponent<Monster>();
            StartCoroutine(monster.Hit(1)); //hit �� �ڷ�ƾ�̱� ������ ��ŸƮ�ڷ�ƾ 
        }
    }

    private void OnCollisionEnter2D(Collision2D other)//������ ȹ��
    {
        if(other.gameObject.GetComponent<IItem>() != null)
        {
            IItem item = other.gameObject.GetComponent<IItem>();
            item.Get(); 
        }
    }
}
