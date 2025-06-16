using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public float hp;
    public float moveSpeed;

    public abstract void Move();

    public abstract void Hit(); 
}
