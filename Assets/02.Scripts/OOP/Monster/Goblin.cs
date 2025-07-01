using System.Collections;
using UnityEngine;

public class Goblin : MonsterCore
{
    private float timer;
    float idleTime, patrolTime;
    bool isAttack;

    //float percent;

    float traceDist = 5f; //추격거리
    float attackDist = 1.5f; 
    //Vector3 startPos, endPos;
    
    void Start()
    {
        Init(10f, 3f, 2f);
    }

    protected override void Init(float hp, float speed, float attackTime)
    {
        base.Init(hp, speed, attackTime);
    }

    public override void Idle()
    {
        timer += Time.deltaTime;
        if (timer >= idleTime)
        {
            timer = 0f;
            moveDir = Random.Range(0, 2) == 1 ? 1 : -1;
            transform.localScale = new Vector3(moveDir, 1, 1);
            patrolTime = Random.Range(1f, 5f); //패트롤 상태 유지할 시간 미리 설정. 1초부터 5초 이내
            anim.SetBool("isRun", true); //바뀌기 직전에 불 값 바꿔줌

            //startPos = transform.position;
            //endPos = startPos + Vector3.right * moveDir * patrolTime; //??

            ChangeState(MonsterState.PATROL);

            if(targetDist <= traceDist)
            {
                Vector3 monsterDir = Vector3.right * moveDir; // (1,0,0) 인데 moveDir 을 통해서 왼쪽 보는지 오른쪽 보는지 확인 가능

                Vector3 pTmDir = (transform.position - target.position).normalized; //플레이어가 몬스터 바라보는 방향

                float dotValue = Vector3.Dot(monsterDir, pTmDir);
                Debug.Log(dotValue);

                timer = 0f;
                anim.SetBool("isRun", true);
                ChangeState(MonsterState.TRACE);

            }
        }
    }

    public override void Patrol()
    {

        transform.position += Vector3.right * moveDir * speed * Time.deltaTime;

        timer += Time.deltaTime;
        //percent = timer / patrolTime;

        //transform.position = Vector3.Lerp(startPos, endPos, percent); //스타트 포지션부터 엔드포즈까지 speed * 타임 곱한 비율만큼)
        
        if (timer >= patrolTime)
        {
            timer = 0f;

            idleTime = Random.Range(1f, 5f); //아이들 상태에서 기다리는 값을 미리 설정
            anim.SetBool("isRun", false); //바뀌기 직전에 불 값 바꿔줌
            ChangeState(MonsterState.IDLE);
        }
        if (targetDist <= traceDist)
        {
            timer = 0f;
            ChangeState(MonsterState.TRACE);
        }
    }

    public override void Trace()
    {
        var targetDir = (target.position - transform.position).normalized; //목적지 - 현재 위치 
        transform.position += Vector3.right * targetDir.x * speed * Time.deltaTime; // 2D라서 x축 값에만 적용 

        var scaleX = targetDir.x > 0 ? 1 : -1;
        transform.localScale = new Vector3(scaleX, 1, 1); 
            
        if (targetDist > traceDist)
        {
            anim.SetBool("isRun", false);
            ChangeState(MonsterState.IDLE);
        }
        if(targetDist <= attackDist)
        {
            ChangeState(MonsterState.ATTACK);
        }
    }

    public override void Attack()
    {
        if(!isAttack) //만약 isAttack 이 false 라면
        {
            StartCoroutine(AttackRoutine());
        }
    }

    IEnumerator AttackRoutine()
    {
        isAttack = true;
        anim.SetTrigger("Attack");

        yield return new WaitForSeconds(1f);
        anim.SetBool("isRun", false);

        yield return new WaitForSeconds(attackTIme - 1f);
        isAttack = false;
        ChangeState(MonsterState.IDLE);
    }

}