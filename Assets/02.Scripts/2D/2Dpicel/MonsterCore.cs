using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public abstract class MonsterCore : MonoBehaviour, IDamageable
{
    public enum MonsterState { IDLE, PATROL, TRACE, ATTACK }
    public MonsterState monstate = MonsterState.IDLE;

    public ItemManager itManager;
    public Image hpBar; 

    public float hp;
    public float currHp;
    public float speed;

    protected Animator anim;
    protected Rigidbody2D monRb;
    protected Collider2D moncoll;

    protected float moveDir;
    protected float targetDist;  //목표와의 거리값
    public float attackTIme;
    public float atkDamage;
    bool isDead; 

    public Transform target;
    protected bool isTrace;

    Collider2D monsterColl;
    Rigidbody2D monsterRb;

    protected virtual void Init(float hp, float speed, float attackTime, float atkDamage)
    {
        anim = GetComponent<Animator>();
        monRb = GetComponent<Rigidbody2D>();
        moncoll = GetComponent<Collider2D>();

        target = GameObject.FindGameObjectWithTag("Player").transform;
        itManager = FindFirstObjectByType<ItemManager>();

        this.hp = hp;
        this.speed = speed;
        this.atkDamage = atkDamage;
    }

    private void Update()
    {
        if (isDead)
            return; 

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
        if(other.GetComponent<IDamageable>() != null)
        {
            other.GetComponent<IDamageable>().TakeDamage(atkDamage);
        }
    }

    public void TakeDamage(float damage)
    {
        currHp -= damage;
        hpBar.fillAmount = currHp / hp;
        if (currHp <= 0f)
            Death();
    }

    public void Death()
    {
        isDead = true;
        anim.SetTrigger("Death");
        moncoll.enabled = false;
        monRb.gravityScale = 0f;

        int itemCount = Random.Range(0, 3);

        if(itemCount >= 0)
        {
            for (int i = 0; i < itemCount; i++)
                itManager.DropItem(transform.position);
        }
    }
}
