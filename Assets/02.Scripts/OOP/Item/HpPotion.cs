using UnityEngine;

public class HpPotion : MonoBehaviour, IItemObject
{
    public ItemManager Inventory { get; set; }
    public GameObject Obj { get; set; }
    public string ItemName { get; set; }
    public Sprite Icon { get; set; }

    void Start()
    {
        Inventory = FindFirstObjectByType<ItemManager>(); 

        Obj = this.gameObject; //hppotion 말하는것. 그 위에 상속도 포함
        ItemName = this.gameObject.name;
        Icon = this.GetComponent<SpriteRenderer>().sprite; 
    }
    public void Get()
    {
        gameObject.SetActive(false); //먹은 것처럼 보이기 

        Inventory.GetItem(this); //인벤토리한테 먹은 정보 넘기기
    }

    public void Use()
    {
        Debug.Log("아이템 사용");
    }
    void OnCollisionEnter2D(Collision2D other) //충돌 이벤트
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Get();
        }
    }
}
