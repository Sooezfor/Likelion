using UnityEngine;

public class Potion : MonoBehaviour, IItem
{
    private InventoryM inven;
    public enum PotionType { GreenPotion, Purpleheart }
    public PotionType potionT;

    void Start()
    {
        Obj = gameObject;
        inven = FindFirstObjectByType<InventoryM>(); //��ũ��Ʈ �Ҵ�
    }
    public GameObject Obj { get; set; }

    void OnMouseDown()
    {
        Get();
    }
    public void Get()
    {
        Debug.Log($"{this.name}�� ȹ���߽��ϴ�.");
        gameObject.SetActive(false);
        inven.AddItem(this);
    }
}
