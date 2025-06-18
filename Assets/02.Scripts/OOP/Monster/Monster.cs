using System.Collections;
using UnityEngine;

public abstract class Monster : MonoBehaviour
{
    SpriteRenderer sRenderer;
    [SerializeField] protected float Hp = 3f;
    [SerializeField] protected float moveSpeed = 3f;
    public SpawnManager spManager;

    Animator anim;
    bool isMove = true; //공격당했을때 멈추게하기 위해 움직이는거 판단하는 불값
    bool isHit = false; //Hit 함수가 돌고있을 때 그다음 공격은 막도록 하는 것(광클방지)

    private int dir = 1;

    public abstract void Init();

    private void Start()
    {
        spManager = FindFirstObjectByType<SpawnManager>(); //갖고있는게 하나뿐인 오브젝트라서 찾을수있음.
                                                           //스폰매니저라는 타입을 가진 애에게 할당한다는 뜻.
                                                           //(딱 하나만 갖고있는애 찾을떄 쓰는 함수) 

        sRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        Init();
    }
    private void Update()
    {
        Move();
    }

    private void OnMouseDown()//마우스 클릭 시 반응하는 함수,유니티 기본 함수
    {
        StartCoroutine(Hit(1)); //데미지 1
    }
    IEnumerator Hit(float damage) //그냥 게임뷰 상에서 마우스로 클릭하면 상호작용됨
    {
        if (isHit)
            yield break; //isHit이 true면 현재 코루틴 실행X 현재루틴 파괴

            isHit = true;
            isMove = false; 
            anim.SetTrigger("Hit");

            Hp -= damage;

            if(Hp <= 0)
            {
                    anim.SetTrigger("Death");
                    yield return new WaitForSeconds(2f);
                    spManager.DropCoin(transform.position);//여기서 위치는 몬스터가 죽은 위치

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
                dir = -1; //방향 반대로
                sRenderer.flipX = true;
            }
            else if (transform.position.x < -8f)
            {
                dir = 1;
                sRenderer.flipX = false;
            }
    }
}

