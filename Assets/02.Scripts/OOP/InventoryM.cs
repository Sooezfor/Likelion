using NUnit.Framework;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InventoryM : MonoBehaviour
{
    public List<GameObject> items = new List<GameObject>(); //���� �����۵� ���� ����Ʈ  
    /// <summary>
    /// ����Ƽ �󿡼� ���� ���ؼ� GameObject Ÿ������ �ִ� ��. �� ���� �� ���� �׳� <interface> �����ͼ� �ٷ� �޾Ƶ� �� �׷� Add(item) �ȴ�.

    public void AddItem(IItem item)// ���� Ư���� �Ű������� ����
    {
        items.Add(item.Obj); //�������̽��� �����ϱ� ����
    }
    
}
