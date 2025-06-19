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

        if(h == 0 && v == 0) //아무것도 안 누른 상태 
        {
            anim.SetBool("Run", false);
            if(Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(AttackRoutine());
            }

        }
        else // Run 상태 (어떠한 키라도 누른 상태) 
        {
            int scaleX = h > 0 ? 1 : -1;
            transform.localScale = new Vector3(scaleX, 1, 1);

            anim.SetBool("Run", true);

            var dir = new Vector3(h, v, 0).normalized; //위아래로 움직일거 
            transform.position += dir * moveSpeed * Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartCoroutine(AttackRoutine());
            }
        }
    }

    void Attack()
    {
        if(Input.GetKeyDown(KeyCode.Space)) //광클 방지 위해 앤드 연산자로 isAttack false 상태 물어보기
        {
            StartCoroutine(AttackRoutine());
        }
    }
    IEnumerator AttackRoutine() //코루틴은 반복자를 사용하는 하나의 타입임
    {
        isAttack = true; //광클 방지 
        hitBox.SetActive(true);
        Debug.Log("어택 루틴 실행");
        anim.SetBool("Hit",true);

        yield return new WaitForSeconds(0.25f);
        anim.SetBool("Hit", false);
        hitBox.SetActive(false);
        isAttack = false;
    }

    private void OnTriggerEnter2D(Collider2D other) //몬스터 공격
    {
        if(other.GetComponent<Monster>() != null) //몬스터 스크립트가 있는 애들한테만 접근
        {
            Monster monster = other.GetComponent<Monster>();
            StartCoroutine(monster.Hit(1)); //hit 이 코루틴이기 때문에 스타트코루틴 
        }
    }

    private void OnCollisionEnter2D(Collision2D other)//아이템 획득
    {
        if(other.gameObject.GetComponent<IItem>() != null)
        {
            IItem item = other.gameObject.GetComponent<IItem>();
            item.Get(); 
        }
    }
}
