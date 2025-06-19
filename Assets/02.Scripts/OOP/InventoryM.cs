using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InventoryM : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>(); //먹은 아이템들 들어가는 리스트  
    /// <summary>
    /// 유니티 상에서 보기 위해서 GameObject 타입으로 넣는 것. 안 봐도 될 때는 그냥 <interface> 가져와서 바로 받아도 됨 그럼 Add(item) 된다.

    public void AddItem(IItem item)// 공통 특성을 매개변수로 가짐
    {
        items.Add(item.Obj); //인터페이스에 접근하기 위함
    }
    
}
