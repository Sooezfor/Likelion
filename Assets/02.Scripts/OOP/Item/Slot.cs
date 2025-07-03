using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    IItemObject item; //슬롯에 들어올 아이템
    public Image itemImageUI; //먹은 아이템 이미지 
    public Button slotButton; //아이템 사용 하기 위한 버튼 

    public bool isEmpty = true;

    private void Awake()
    {
        slotButton.onClick.AddListener(UseItem);
    }
    private void OnEnable()
    {
        slotButton.interactable = !isEmpty;
        itemImageUI.gameObject.SetActive(!isEmpty);
    }
   
    public void AddItem(IItemObject newItem)
    {
        item = newItem;
        isEmpty = false; //아이템이 들어와서
        itemImageUI.sprite = newItem.Icon; //이미지 UI 안에 스프라이트 넣는 거라서 이렇게 적어야함.
        itemImageUI.SetNativeSize(); //실제 이미지 해상도
    }
    public void UseItem()
    {
        if(item != null)
        {
            item.Use();  //아이템 쓰기 
            ClearSlot(); //아이템 썻으니까 클리어
        }
    }
    public void ClearSlot()
    {
        item = null;
        isEmpty = true;
        slotButton.interactable = !isEmpty; //상호작용 기능 끄기 
        itemImageUI.gameObject.SetActive(!isEmpty); //아이콘 사라지기
    }


}
