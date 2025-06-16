using UnityEngine;

//player 
public class Study_Overloading : MonoBehaviour
{
    private void Start()
    {
        Attack();
        Attack(true);
        Attack(3.5f);
        Attack(10f, new GameObject("몬스터"));   //여기서 빈게임오브젝트 몬스터라고 만든 거임.
      //GameObject monsterObj = new GameObject("몬스터"); 이렇게 만든거랑 똑같은거임.
    }
    void Attack()
    {
        Debug.Log("공격");
    }
    void Attack(bool isMagic)
    {
        if (isMagic)
            Debug.Log("마법 공격");
    }
    void Attack(float damage)
    {
        Debug.Log($"{damage} 데미지 만큼의 공격");
    }
    void Attack(float damage, GameObject target)
    {
        Debug.Log($"{target.name} 에게 {damage} 데미지 만큼 공격");
    }
}
