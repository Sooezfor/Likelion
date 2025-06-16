using UnityEngine;

public class Player : Character
{
    public override void Attack()
    {
        Debug.Log("Player 공격");
    }
    public override void Move()
    {
        Debug.Log("Player 이동");
    }
}
