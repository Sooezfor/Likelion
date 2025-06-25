using UnityEngine;

public class Sword : MonoBehaviour
{
    public float damage = 10f;

    private void OnTriggerEnter2D(Collider2D other)
    {
//        if (other.GetComponenet<IDamageable>() != null) 
//{
//            other.Getcomponenet<IDamageable>().TakeDamage(damage);
//        }

    }

}
