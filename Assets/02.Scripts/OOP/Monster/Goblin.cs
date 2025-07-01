using UnityEngine;

public class Goblin : MonsterCore
{
    private float timer;
    private float ranDir;
    float idleTime, patrolTime;

    float percent; 

    Vector3 startPos, endPos;
    
    void Start()
    {
        Init(10f, 3f);

    }

    protected override void Init(float hp, float speed)
    {
        base.Init(hp, speed);
    }

    public override void Idle()
    {

        timer += Time.deltaTime;
        if (timer >= idleTime)
        {
            timer = 0f;
            ranDir = Random.Range(0, 2) == 1 ? 1 : -1;
            transform.localScale = new Vector3(ranDir, 1, 1);
            anim.SetBool("isRun", true); //바뀌기 직전에 불 값 바꿔줌

            patrolTime = Random.Range(1f, 5f); //패트롤 상태 유지할 시간 미리 설정. 1초부터 5초 이내

            startPos = transform.position;
            endPos = startPos + Vector3.right * ranDir * patrolTime; //??

            ChangeState(MonsterState.PATROL);
        }
    }

    public override void Patrol()
    {
        timer += Time.deltaTime;
        percent = timer / patrolTime;

        transform.position = Vector3.Lerp(startPos, endPos, percent); //스타트 포지션부터 엔드포즈까지 speed * 타임 곱한 비율만큼)
        
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
        
    }

    public override void Attack()
    {
        
    }
}