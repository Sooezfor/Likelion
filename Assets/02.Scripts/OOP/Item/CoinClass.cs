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
        inven = FindFirstObjectByType<InventoryM>(); //스크립트 할당
    }

    public GameObject Obj { get; set; }

    void OnMouseDown()
    {
        Get();
    }

    public void Get()
    {
        Debug.Log($"{this.name}을 획득했습니다.");
        gameObject.SetActive(false);
        inven.AddItem(this);
    }
}
