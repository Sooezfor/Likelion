using UnityEngine;

public class CoinClass : MonoBehaviour, IItem
{
    private InventoryM inven;
    public enum CoinType { GoldBox, Red, Blue, Coin }
    public CoinType coinType;


    public float price;
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
