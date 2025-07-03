using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    [SerializeField] Transform slotGroup;
    [SerializeField] private GameObject[] items;
    public Slot[] slots;

    public GameObject inventoryUI;
    public Button inventoryButton;

    private void Start()
    {
        slots = slotGroup.GetComponentsInChildren<Slot>(true);
        //자신과 자식 중에서 슬롯 컴포넌트가 있는 대상을 모두 가져오는 기능 
        inventoryButton.onClick.AddListener(OnInventory);
    }
    void OnInventory()
    {
        inventoryUI.SetActive(!inventoryUI.activeSelf);
        //현재 액티브 상태를 반전시켜줌
    }
    public void DropItem(Vector3 dropPos)
    {
        var randomIndex = Random.Range(0, items.Length);

        GameObject item = Instantiate(items[randomIndex], dropPos, Quaternion.identity);

        Rigidbody2D itemRb = item.GetComponent<Rigidbody2D>();

        itemRb.AddForceX(Random.Range(-2f, 2f), ForceMode2D.Impulse);
        itemRb.AddForceY(3f, ForceMode2D.Impulse);

        float ranPower = Random.Range(-1.5f, 1.5f);
        itemRb.AddTorque(ranPower, ForceMode2D.Impulse);
    }

    public void GetItem(IItemObject item) //인벤토리 기능 
    {
        // 모든 슬롯 중에서 빈 슬롯을 찾아서 AddItem 
        foreach(var slot in slots) //모든 슬롯에서 
        {
            if(slot.isEmpty) //슬롯이 비어있을 경우
            {
                slot.AddItem(item);
                break;
            }
        }
    }
}