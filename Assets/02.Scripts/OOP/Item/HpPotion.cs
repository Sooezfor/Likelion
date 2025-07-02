using UnityEngine;

public class HpPotion : MonoBehaviour, IItemObject
{
    public ItemManager Inventory { get; set; }
    public GameObject Obj { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public string ItemName { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public Sprite Icon { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    void Start()
    {
        Inventory = FindFirstObjectByType<ItemManager>(); 

        Obj = this.gameObject; //hppotion 말하는것. 그 위에 상속도 포함
        ItemName = name;
        Icon = GetComponent<SpriteRenderer>().sprite; 
    }
    public void Get()
    {
        gameObject.SetActive(true); //인벤토리 시스템 작동

        Inventory.GetItem(this);
    }

    public void Use()
    {
        Debug.Log("포션 사용");
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Get();
        }
    }
}
