using UnityEngine;

//player 
public class Study_Overloading : MonoBehaviour
{
    private void Start()
    {
        Attack();
        Attack(true);
        Attack(3.5f);
        Attack(10f, new GameObject("����"));   //���⼭ ����ӿ�����Ʈ ���Ͷ�� ���� ����.
      //GameObject monsterObj = new GameObject("����"); �̷��� ����Ŷ� �Ȱ�������.
    }
    void Attack()
    {
        Debug.Log("����");
    }
    void Attack(bool isMagic)
    {
        if (isMagic)
            Debug.Log("���� ����");
    }
    void Attack(float damage)
    {
        Debug.Log($"{damage} ������ ��ŭ�� ����");
    }
    void Attack(float damage, GameObject target)
    {
        Debug.Log($"{target.name} ���� {damage} ������ ��ŭ ����");
    }
}
