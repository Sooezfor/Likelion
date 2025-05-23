using System.Threading;
using UnityEngine;

public class StudyLookAt : MonoBehaviour
{

    public Transform targetTf;//������Ʈ ��� Ʈ�������� �����̶� �� ȿ����(������ ��ġ �����ҰŴϱ�) 
    public Transform turretHead;

    public GameObject bulletPrefab; //�Ѿ� ������
    public Transform firePos; //�߻� ��ġ

    public float Timer;
    public float cooldownTime;

    void Start()//�����ΰ��� �����ϴ� ���
    {
        targetTf = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update() //�����ΰ� �ٶ󺸴� ��� 
    {
        turretHead.LookAt(targetTf); //�ͷ� ��尡 Ÿ��Tf�� �ٶ� ���̴�.


        Timer += Time.deltaTime;
        if(Timer >= cooldownTime)
        {
            Timer = 0f;
            Instantiate(bulletPrefab, firePos.position, firePos.rotation);

            //�����ϴ� (�������, ������ġ, ȸ������)
            //(Gameobjext , vextor3, quaternion) �̷��� �� 
        }
    }
}
