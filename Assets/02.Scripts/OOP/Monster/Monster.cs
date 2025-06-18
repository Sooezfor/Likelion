using System.Collections;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    SpriteRenderer sRenderer;
    [SerializeField] protected float Hp = 3f;
    [SerializeField] protected float moveSpeed = 3f;
    Animator anim;
    bool isMove = true; //���ݴ������� ���߰��ϱ� ���� �����̴°� �Ǵ��ϴ� �Ұ�
    bool isHit = false; //Hit �Լ��� �������� �� �״��� ������ ������ �ϴ� ��(��Ŭ����)

    private int dir = 1;

    public abstract void Init();

    private void Start()
    {
        sRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        Init();
    }
    private void Update()
    {
        Move();
    }

    private void OnMouseDown()//���콺 Ŭ�� �� �����ϴ� �Լ�,����Ƽ �⺻ �Լ�
    {
        StartCoroutine(Hit(1)); //������ 1
    }
    IEnumerator Hit(float damage) //�׳� ���Ӻ� �󿡼� ���콺�� Ŭ���ϸ� ��ȣ�ۿ��
    {
        if (isHit)
            yield break; //isHit�� true�� ���� �ڷ�ƾ ����X �����ƾ �ı�

            isHit = true;
            isMove = false; 
            anim.SetTrigger("Hit");

            Hp -= damage;

            if(Hp <= 0)
            {
                anim.SetTrigger("Death");

                yield return new WaitForSeconds(3f);
                Destroy(gameObject);

                yield break; 
            }
            yield return new WaitForSeconds(0.5f);
            isMove = true;
            isHit = false;
    }
    private void Move()
    {
        if (!isMove) 
            return; 

            transform.position += Vector3.right * dir * moveSpeed * Time.deltaTime;

            if (transform.position.x > 8f)
            {
                dir = -1; //���� �ݴ��
                sRenderer.flipX = true;
            }
            else if (transform.position.x < -8f)
            {
                dir = 1;
                sRenderer.flipX = false;
            }
    }
}

