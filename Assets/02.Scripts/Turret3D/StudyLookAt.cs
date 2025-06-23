using System.Threading;
using UnityEngine;

public class StudyLookAt : MonoBehaviour
{

    public Transform targetTf;//오브젝트 대신 트랜스폼이 조금이라도 더 효율적(어차피 위치 접근할거니까) 
    public Transform turretHead;

    public GameObject bulletPrefab; //총알 프리팹
    public Transform firePos; //발사 위치

    public float Timer;
    public float cooldownTime;

    void Start()//무엇인가를 세팅하는 기능
    {
        targetTf = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() //무엇인가 바라보는 기능 
    {
        turretHead.LookAt(targetTf); //터렛 헤드가 타겟Tf를 바라볼 것이다.


        Timer += Time.deltaTime;
        if(Timer >= cooldownTime)
        {
            Timer = 0f;
            Instantiate(bulletPrefab, firePos.position, firePos.rotation);

            //생성하다 (생성대상, 생성위치, 회전상태)
            //(Gameobjext , vextor3, quaternion) 이렇게 들어감 
        }
    }
}
