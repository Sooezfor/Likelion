using UnityEngine;

public class goldBox : MonoBehaviour, IItemObject, IDamageable
{
    ItemManager itManager;
    Collider2D boxcoll; 

    public ItemManager Inventory { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public GameObject Obj { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public string ItemName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public Sprite Icon { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    int hp = 1; 
    public void Death()
    {
        itManager.DropItem(transform.position);
        boxcoll.enabled = false; 
    }

    public void Get()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(float damage)
    {
        if (damage > 0)
            Death();
    }

    public void Use()
    {
        throw new System.NotImplementedException();
    }
}
