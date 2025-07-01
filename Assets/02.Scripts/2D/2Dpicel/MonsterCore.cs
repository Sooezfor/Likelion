using System.Diagnostics;
using UnityEngine;

public abstract class MonsterCore : MonoBehaviour
{
    public enum MonsterState { IDLE, PATROL, TRACE, ATTACK }
    public MonsterState monstate = MonsterState.IDLE;

    public float hp;
    public float speed;

    protected Animator anim;
    protected Rigidbody2D rigidRb;
    protected Collider2D moncoll;


    protected virtual void Init(float hp, float speed)
    {
        anim = GetComponent<Animator>();

        this.hp = hp;
        this.speed = speed;
    }

    private void Update()
    {
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

}
