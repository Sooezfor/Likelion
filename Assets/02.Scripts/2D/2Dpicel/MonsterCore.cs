using System.Diagnostics;
using UnityEngine;

public abstract class MonsterCore : MonoBehaviour
{
    public enum MonsterState { IDLE, PATROL, TRACE, ATTACK }
    public MonsterState monstate = MonsterState.IDLE;

    public float hp;
    public float speed;

    protected Animator anim;
    protected Rigidbody2D monRb;
    protected Collider2D moncoll;
    protected float moveDir;
    protected float targetDist;  //목표와의 거리값
    public float attackTIme; 

    public Transform target;
    protected bool isTrace; 
 
   

    protected virtual void Init(float hp, float speed, float attackTime)
    {
        anim = GetComponent<Animator>();
        monRb = GetComponent<Rigidbody2D>();
        moncoll = GetComponent<Collider2D>();

        target = GameObject.FindGameObjectWithTag("Player").transform;

        this.hp = hp;
        this.speed = speed;
    }

    private void Update()
    {
        targetDist = Vector3.Distance(transform.position, target.position);

        Vector3 monsterDIr = Vector3.right * moveDir;
        Vector3 playerDir = (transform.position - target.position).normalized;

        float dotValue = Vector3.Dot(monsterDIr, playerDir);
        isTrace = dotValue < -0.5f && dotValue >= -1f;

        switch(monstate)
        {
            case MonsterState.IDLE:
                Idle();
                break;
            case MonsterState.PATROL:
                Patrol();
                break;
            case MonsterState.TRACE:
                Trace();
                break;
            case MonsterState.ATTACK:
                Attack();
                break;
        }
    }
    public abstract void Idle();
    public abstract void Patrol();
    public abstract void Trace();
    public abstract void Attack();

    public void ChangeState(MonsterState newState) //상태 변경 함수
    {

        if (monstate != newState)
            monstate = newState;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Return")) //벽에 부딪혔을 때
        {
            moveDir *= -1; //moveDir은 이동 방향만 바꾼 거고 localScale 값을 바꿔야 스프라이트 좌우반전.
            transform.localScale = new Vector3(moveDir, 1, 1);
        }
    }
}
