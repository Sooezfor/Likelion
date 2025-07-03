using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private GameObject[] items;
    public Slot[] slots; 

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