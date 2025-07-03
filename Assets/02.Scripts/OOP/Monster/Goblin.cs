using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Goblin : MonsterCore
{
    private float timer;
    float idleTime, patrolTime;
    public bool isAttack;

    float traceDist = 8f; //추격거리
    float attackDist = 1.5f;     
    void Start()
    {
        Init(30f, 3f, 2f, 10f);
        StartCoroutine(FindPlayerRoutine());
    }
    protected override void Init(float hp, float speed, float attackTime, float atkDamage)
    {
        base.Init(hp, speed, attackTime, atkDamage);
        idleTime = Random.Range(1f, 5f);
    }
    IEnumerator FindPlayerRoutine()
    {
        while(true)
        {
            yield return null; //update 와 횟수 똑같음. 1프레임 늦게 시작할 뿐 횟수 동일. 
            targetDist = Vector3.Distance(transform.position, target.position);

            if(monstate == MonsterState.IDLE || monstate == MonsterState.PATROL)
            { 
                Vector3 monsterDIr = Vector3.right * moveDir;
                Vector3 playerDir = (transform.position - target.position).normalized;
                float dotValue = Vector3.Dot(monsterDIr, playerDir);
                isTrace = dotValue < -0.5f && dotValue >= -1f;
               
                if(targetDist <= traceDist && isTrace)
                {
                    anim.SetBool("isRun", true);
                    ChangeState(MonsterState.TRACE);
                }
            }
            else if(monstate == MonsterState.TRACE)
            {
                if (targetDist > traceDist)
                {
                    timer = 0f;
                    idleTime = Random.Range(1f, 5f);
                    anim.SetBool("isRun", false);

                    ChangeState(MonsterState.IDLE);
                }
                if (targetDist < attackDist)
                {
                    ChangeState(MonsterState.ATTACK);
                }
            }
        }
    }

    public override void Idle()
    {
        timer += Time.deltaTime;
        if (timer >= idleTime)
        {
            timer = 0f;
            moveDir = Random.Range(0, 2) == 1 ? 1 : -1;
            transform.localScale = new Vector3(moveDir, 1, 1);
            hpBar.transform.localScale = new Vector3(moveDir, 1, 1); //체력 바는 반대로 되어야 해서 -moveDir 됨
        
            patrolTime = Random.Range(1f, 5f); //패트롤 상태 유지할 시간 미리 설정. 1초부터 5초 이내
            anim.SetBool("isRun", true); //바뀌기 직전에 불 값 바꿔줌
            
            ChangeState(MonsterState.PATROL);
        }
    }

    public override void Patrol()
    {
        transform.position += Vector3.right * moveDir * speed * Time.deltaTime;

        timer += Time.deltaTime;
        if (timer >= patrolTime)
        {
            timer = 0f;
            idleTime = Random.Range(1f, 5f); //아이들 상태에서 기다리는 값을 미리 설정
            anim.SetBool("isRun", false); //바뀌기 직전에 불 값 바꿔줌
            
            ChangeState(MonsterState.IDLE);
        }

    }
    public override void Trace()
    {
        var targetDir = (target.position - transform.position).normalized; //목적지 - 현재 위치 
        transform.position += Vector3.right * targetDir.x * speed * Time.deltaTime; // 2D라서 x축 값에만 적용 

        var scaleX = targetDir.x > 0 ? 1 : -1;
        transform.localScale = new Vector3(scaleX, 1, 1);
        hpBar.transform.localScale = new Vector3(scaleX, 1, 1); //체력 바는 반대로 되어야 해서 로컬스케일
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
        anim.SetTrigger("Attack"); //공격 애니메이션 실행 
        float currAnimLength = anim.GetCurrentAnimatorStateInfo(0).length; //현재 실행 중인 애니메이션의 길이.
        yield return new WaitForSeconds(currAnimLength);

        anim.SetBool("isRun", false); //idle 애니메이션 실행 
        var targetDir = (target.position - transform.position).normalized; //타겟 바라보도록 좌우반전하는 기능 추가
        var scaleX = targetDir.x > 0 ? 1 : -1;
        transform.localScale = new Vector3(scaleX, 1, 1);
        hpBar.transform.localScale = new Vector3(scaleX, 1, 1); //체력 바는 반대로 되어야 해서
    
        yield return new WaitForSeconds(attackTIme - 1f);//공격 쿨다운

        isAttack = false; //다시 공격 가능하도록 false 로 초기화
        anim.SetBool("isRun", true);
        ChangeState(MonsterState.TRACE);
    }
}